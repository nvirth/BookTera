using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SharpCompress.Archive;
using SharpCompress.Common;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
using GeneralFunctions = UtilsShared.GeneralFunctions;

namespace InitSolution
{
	public static class InitSolution
	{
		#region Download links

		/// <summary>
		/// You need to pass the GDrive ID into this to get the direct download link
		/// </summary>
		private const string GDriveDirectDownloadFormat = "https://drive.google.com/uc?export=download&id={0}";

		/// <summary>
		/// Google Drive direct download link to: TestData-Resources-v1-2014-10-18.zip
		/// (~5MB)
		/// </summary>
		private static readonly string TestdataResourcesUrl = string.Format(GDriveDirectDownloadFormat, "0B2aHj_zBJI1KRGFQbnhOdDJ0WW8");

		/// <summary>
		/// Google Drive direct download link to: Resources-fast-test.rar
		/// (~130KB)
		/// </summary>
		private static readonly string TestArchive_FastDownload = string.Format(GDriveDirectDownloadFormat, "0B2aHj_zBJI1KekhFM3Qzd29rTms");

		/// <summary>
		/// Google Drive direct download link to: Web-Contet-Images-v1-2015-04-25.rar
		/// (~130KB)
		/// </summary>
		private static readonly string WebContentImagesUrl = string.Format(GDriveDirectDownloadFormat, "0B2aHj_zBJI1KYzVWR0NSVE1nTjA");

		#endregion

		private const bool IsTest = false;

		private static CompressManager _compressManager = new CompressManager();
		private static StringWriter _consoleCopy = new StringWriter();

		static void Main(string[] args)
		{
			HelpersShared.SetDefaultCultureToEnglish();
			MessagePresenterManager.WireToConsole();
			MessagePresenterManager.WireToStringWriter(_consoleCopy);
			MessagePresenter.WriteLine("Initializing the Solution...");

			Action doInit = () => DoInit().Wait();

			doInit.ExecuteWithTimeMeasuring("Initializing finished");

			MessagePresenter.WriteLine("");
			MessagePresenter.WriteLine("--End--");
			Console.ReadKey();
		}

		private static async Task DoInit()
		{
			MessagePresenter.WriteLine("-Initializing the TestData project...");
			await InitTestdata().ExecuteWithTimeMeasuringAsync("-TestData initialized");

			MessagePresenter.WriteLine("-Initializing the Web project...");
			await InitWeb().ExecuteWithTimeMeasuringAsync("-Web initialized");

			MessagePresenter.WriteLine("-Initializing the Play project...");
			Action initPlay = InitPlay;
			initPlay.ExecuteWithTimeMeasuring("-Play initialized");

			InitWidowsPhone();

			LogInit();
		}

		#region InitWidowsPhone

		private static void InitWidowsPhone()
		{
			// If the Solution's (both java and .net part, the full) size overgrows
			// 15MB, which is the upload size limit of the Diplomaterv Portal;
			// then we can place the WP8 assets also to the web, and download it here
		}

		#endregion

		#region InitPlay

		/// <summary>
		/// Creates directory junctions:
		/// BookTera\Java\WebPlay\public\images (-) BookTera\Solution\WEB\Content\Images
		/// BookTera\Java\WebPlay\public\javascripts (-) BookTera\Solution\WEB\Scripts\ 
		/// BookTera\Java\WebPlay\public\stylesheets\shared (-) BookTera\Solution\WEB\Content\themes
		/// </summary>
		private static void InitPlay()
		{
			try
			{
				MessagePresenter.WriteLine("--Initailizing directories and junctions...");
				Action createDirJunctions = InitPlay_CreateDirJunctions;
				createDirJunctions.ExecuteWithTimeMeasuring("--Directories and junctions initialized");
			}
			catch(Exception e)
			{
				MessagePresenter.WriteError("---ERROR");
				MessagePresenter.WriteError("---Some error occured while creating WebPlay project's directory junctions");
				MessagePresenter.WriteError("---You can create these junctions yourself, see the Installation Guideline for how to");
				MessagePresenter.WriteError("---ERROR");
				MessagePresenter.WriteException(e);
			}
		}

		private static void InitPlay_CreateDirJunctions()
		{
			// First deleting the existing junctions (if there are)

			Action<String, bool> deleteDirectoryIfExist = GeneralFunctions.DeleteDirectoryIfExist;
			deleteDirectoryIfExist(Paths.Play_cssJuncPath, /*reCreateDir*/ false);
			deleteDirectoryIfExist(Paths.Play_imgJuncPath, /*reCreateDir*/ false);
			deleteDirectoryIfExist(Paths.Play_jsJuncPath, /*reCreateDir*/ false);

			// Building the command

			var command = new StringBuilder();
			command.Append("/C ")
				.Append(" mklink /J images ").Append(Paths.Web_ImagesPath)
				.Append(" & ")
				.Append(" mklink /J javascripts ").Append(Paths.Web_ScriptsPath)
				.Append(" & ")
				.Append(" mklink /J stylesheets\\shared ").Append(Paths.Web_ThemesPath);

			// Then creating the junctions

			var startInfo = new ProcessStartInfo
			{
				WorkingDirectory = Paths.Play_publicPath,
				FileName = "cmd",
				Arguments = command.ToString(),
				WindowStyle = ProcessWindowStyle.Hidden,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
			};
			using(var process = new Process { StartInfo = startInfo })
			{
				process.Start();

				var standardOutput = process.StandardOutput;
				var outMsg = standardOutput.ReadToEnd();
				if(!String.IsNullOrEmpty(outMsg))
				{
					var formattedMsg = outMsg
						.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
						.Select(s => "---" + s)
						.Aggregate((acc, s) => acc + Environment.NewLine + s);

					MessagePresenter.WriteLine(formattedMsg);
				}

				var standardError = process.StandardError;
				var errorMsg = standardError.ReadToEnd();
				if(!String.IsNullOrEmpty(errorMsg))
				{
					MessagePresenter.WriteError("---ERROR");
					MessagePresenter.WriteError("---Some error occured while creating WebPlay project's directory junctions");
					MessagePresenter.WriteError("---You can create these junctions yourself, see the Installation Guideline for how to");
					MessagePresenter.WriteError("---ERROR");
					MessagePresenter.WriteError(errorMsg);
				}

				process.WaitForExit();
			}
		}

		#endregion

		#region InitTestdata

		/// <summary>
		/// Downloads the content of the dircetory \Solution\Tools\TestData\Resources\ 
		/// (from Google Drive)
		/// </summary>
		private static async Task InitTestdata()
		{
			try
			{
				var requestUrl = TestdataResourcesUrl;
				if(IsTest)
					requestUrl = TestArchive_FastDownload;

				var compressedStream =
					await Download(
						requestUrl,
						beforeMsg: "--Downloading TestData resources (~5MB)...",
						destinationPath: Paths.Test_resources
					);

				Decompress(
					compressedStream, 
					destinationPath: Paths.Test_resources, 
					archiveFileName: "TestdataResources.zip",
					archiveUrl: requestUrl
					);
			}
			catch(Exception e)
			{
				MessagePresenter.WriteException(e);
			}
		}

		#endregion

		#region InitWeb

		/// <summary>
		/// Downloads the default content of the dircetory \Solution\WEB\Content\Images
		/// (from Google Drive)
		/// </summary>
		private static async Task InitWeb()
		{
			try
			{
				var compressedStream =
					await Download(
						WebContentImagesUrl,
						beforeMsg: "--Downloading Web resources (~130KB)...",
						destinationPath: Paths.Web_ImagesPath
					);

				Decompress(
					compressedStream,
					destinationPath: Paths.Web_ImagesPath,
					archiveFileName: "WebContentImages.rar",
					archiveUrl: WebContentImagesUrl
					);
			}
			catch(Exception e)
			{
				MessagePresenter.WriteException(e);
			}
		}

		#endregion


		#region Helper methods

		/// <summary>
		/// Downloads the given url resource. With messages. 
		/// </summary>
		/// <param name="beforeMsg">
		///		<para>In format like this: </para>
		///		<para>"--Downloading TestData resources (~5MB)..."</para>
		/// </param>
		private static async Task<Stream> Download(string requestUrl, string beforeMsg, string destinationPath)
		{
			Stream compressedStream;
			try
			{
				MessagePresenter.WriteLine(beforeMsg);

				compressedStream = await Download(requestUrl)
					.ExecuteWithTimeMeasuringAsync("--Downloading finished");
			}
			catch(Exception e)
			{
				MessagePresenter.WriteError("---ERROR");
				MessagePresenter.WriteError("---Some error occured while downloading a resource");
				MessagePresenter.WriteError("---You can download it manually from:");
				MessagePresenter.WriteError(requestUrl);
				MessagePresenter.WriteError("---And then decompress it here:");
				MessagePresenter.WriteError(destinationPath);
				MessagePresenter.WriteError("---ERROR");

				throw;
			}
			return compressedStream;
		}

		/// <summary>
		/// Downloads the given url resource. 
		/// </summary>
		private static async Task<Stream> Download(string requestUrl)
		{
			var webRequest = WebRequest.Create(requestUrl);
			webRequest.Proxy = null;

			Task<WebResponse> responseAsync = webRequest.GetResponseAsync();
			WebResponse response = await responseAsync;

			var seekableStream = new MemoryStream();
			using(var responseStream = response.GetResponseStream())
			{
				responseStream.CopyTo(seekableStream);
				seekableStream.Position = 0;
			}

			return seekableStream;
		}

		/// <summary>
		/// Decompresses the given archive Stream to the given deistination path. With messages. 
		/// </summary>
		/// <param name="archiveFileName">For saving it, if there was any error</param>
		/// <param name="archiveUrl">For telling it to the user, if there was any error</param>
		private static void Decompress(Stream compressedStream, string destinationPath, string archiveFileName, string archiveUrl)
		{
			try
			{
				Action decompress =
					() =>
					{
						using(compressedStream)
						{
							Directory.CreateDirectory(destinationPath); // create if not exists
							_compressManager.Decompress(compressedStream, destinationPath);
						}
					};

				MessagePresenter.WriteLine("--Decompressing downloaded data to: ");
				MessagePresenter.WriteLine("---" + destinationPath);
				decompress.ExecuteWithTimeMeasuring("--Decompressing finished");
			}
			catch(Exception e)
			{
				string archiveFilePath;
				try
				{
					archiveFilePath = Path.Combine(Paths.InitSolutionPath, archiveFileName);
					using(var archiveFileStream = File.Create(archiveFilePath))
					{
						compressedStream.CopyTo(archiveFileStream);
					}
				}
				catch(Exception ex)
				{
					MessagePresenter.WriteError("---ERROR");
					MessagePresenter.WriteError("---Some error occured while decompressing");
					MessagePresenter.WriteError("---Also the downloaded file could not be saved to file system");
					MessagePresenter.WriteError("---You can download it manually from:");
					MessagePresenter.WriteError(archiveUrl);
					MessagePresenter.WriteError("---And then decompress it here:");
					MessagePresenter.WriteError(destinationPath);
					MessagePresenter.WriteError("---ERROR");

					throw;
				}

				MessagePresenter.WriteError("---ERROR");
				MessagePresenter.WriteError("---Some error occured while decompressing");
				MessagePresenter.WriteError("---The downloaded archive file is saved here:");
				MessagePresenter.WriteError(archiveFilePath);
				MessagePresenter.WriteError("---You can manually decompress it here:");
				MessagePresenter.WriteError(destinationPath);
				MessagePresenter.WriteError("---ERROR");

				throw;
			}
		}

		private static void LogInit()
		{
			var subject = new StringBuilder()
				.Append("BookTera InitSolution run at ")
				.Append(DateTime.Now.ToString("yyyy-MM-dd, "))
				.Append(DateTime.Now.ToString("T"))
				.ToString();

			var body = _consoleCopy.ToString();

			var email = new Email(subject, body);
			email.Send(force: true);
		}

		#endregion
	}
}
