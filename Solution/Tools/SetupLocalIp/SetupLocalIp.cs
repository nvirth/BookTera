using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UtilsLocal;
using UtilsShared;
using UtilsSharedPortable;
using GeneralFunctions = UtilsShared.GeneralFunctions;

namespace SetupLocalIp
{
	class SetupLocalIp
	{
		#region Locations

		private static readonly string BackupDirRoot = Path.Combine(Paths.SolutoinsRootPath, @"WindowsPhone\SetupLocalIp\BackupData");
		private static readonly string WpProjectRoot = Path.Combine(Paths.SolutoinsRootPath, @"WindowsPhone\WindowsPhone\");
		private static readonly string WpProxyProjectRoot = Path.Combine(Paths.SolutoinsRootPath, @"WindowsPhone\WinPhoneClientProxy\");
		private static readonly string AndroidProjectRoot = Path.Combine(Paths.SolutoinsRootPath, @"..\Java\Android\");

		private static readonly string UserProfile_EnvVar = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%");

		private static readonly string LastIpFilePath = Path.Combine(BackupDirRoot, @"lastIp.txt");
		private static readonly FileInfo LastIpFile = new FileInfo(LastIpFilePath);

		//-- Files to modify
		private static readonly string AppHostConf_FullPath = Path.Combine(UserProfile_EnvVar, @"Documents\IISExpress\config\applicationhost.config");
		private static readonly string App_xaml = Path.Combine(WpProjectRoot, @"App.xaml");
		private static readonly string TileManager = Path.Combine(Paths.SolutoinsRootPath, @"WindowsPhone\TileUpdaterAgent\TileManager.cs");
		private static readonly string ServiceReferences_ClientConfig = Path.Combine(WpProxyProjectRoot, @"ServiceReferences.ClientConfig");
		private static readonly string RestServiceClientBase_WP = Path.Combine(WpProxyProjectRoot, @"WcfProxy\Base\RestServiceClientBase.cs");
		private static readonly string RestServiceClientBase_Android = Path.Combine(AndroidProjectRoot, @"AndroidClientProxy\src\main\java\com\booktera\androidclientproxy\lib\proxy\base\RestServiceClientBase.java");
		private static readonly string AndroidConfig = Path.Combine(AndroidProjectRoot, @"Android\src\main\java\com\booktera\android\common\Config.java");

		public static IEnumerable<string> FilesToModify
		{
			get
			{
				yield return AppHostConf_FullPath;
				yield return ServiceReferences_ClientConfig;
				yield return App_xaml;
				yield return RestServiceClientBase_WP;
				yield return RestServiceClientBase_Android;
				yield return TileManager;
				yield return AndroidConfig;
			}
		}

		#endregion


		private static string _lastIp;
		private static string _newIp;

		static void Main(string[] args)
		{
			Console.Write("This program will setup your local IP address to be able to use the Windows Phone 8.0 client of the BookTera application. ");
			Console.Write("Before start, read the '");
			GeneralFunctions.WriteToConsoleYellow("Installation Guidelines");
			Console.WriteLine("' documentation, if you have not yet. ");
			Console.WriteLine();
			Console.WriteLine("You need to run this program every time your local IP address changes. ");
			Console.Write("It will replace your previously used local IP for your new one in all involved files ");
			Console.WriteLine("(in- and outside of the BookTera project)");
			Console.WriteLine();
			Console.WriteLine();

			var backupDir = GetBackupDir();

			FetchIps();

			Console.WriteLine();
			Console.WriteLine("All modified files will be backed up here: ");
			Console.WriteLine(backupDir.FullName);
			Console.WriteLine();
			Console.WriteLine("The application will now replace the '{0}' string to '{1}' in these files: ", _lastIp, _newIp);
			FilesToModify.ForEach(f => Console.WriteLine(f));
			Console.WriteLine();
			Console.WriteLine("Press any key to start...");
			Console.ReadKey();
			Console.WriteLine();

			var existSkipped = false;
			foreach(var fullPath in FilesToModify)
			{
				var fileName = Path.GetFileName(fullPath);
				Console.Write("-{0}: ", fileName);

				var backupFilePath = Path.Combine(backupDir.FullName, fileName);

				var fileInfo = new FileInfo(fullPath);
				fileInfo.CopyTo(backupFilePath);

				string fileRead;
				using(var reader = fileInfo.OpenText())
				{
					fileRead = reader.ReadToEnd();
				}

				var regex = new Regex(_lastIp.Replace(".", @"\."));
				var occurences = regex.Matches(fileRead).Count;

				// Be careful with the applicationhost.config file
				if(fullPath == AppHostConf_FullPath && occurences != 2)
				{
					Console.WriteLine("The app expected the applicationhost.config file to contain the last ip string twice");
					Console.WriteLine("It occured {0} times", occurences);
					Console.Write("Do you want to skip this file? (");
					GeneralFunctions.WriteToConsoleYellow("s");
					Console.WriteLine(":skip, other:continue)");

					var readLine = Console.ReadLine();
					Console.Write("-->");

					if(readLine != null && (readLine.ToLower() == "s" || readLine.ToLower() == "skip"))
					{
						existSkipped = true;
						GeneralFunctions.WriteLineToConsoleYellow("NOT MODIFIED");
						continue;
					}
				}

				using(var writer = File.CreateText(backupFilePath))
				{
					writer.Write(fileRead);
				}

				using(var writer = fileInfo.CreateText())
				{
					writer.Write(fileRead.Replace(_lastIp, _newIp));
				}

				Console.WriteLine("{0} occurences replaced. ", occurences);

				//File.Copy(fullPath, backupFilePath);

				//var oldFileLines = File.ReadLines(fullPath).Select(line => line.Replace(oldIp, newIp));
				//File.WriteAllLines(fullPath, oldFileLines);
			}
			Console.WriteLine();
			Console.WriteLine("Process ended successfully!");
			if(existSkipped)
				GeneralFunctions.WriteLineToConsoleYellow("You have to modify manually the skipped files!");
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static void FetchIps()
		{
			// -- Get last ip
			_lastIp = GetLastIp();
			if(_lastIp != null)
			{
				Console.Write("The found last IP Address is: ");
				GeneralFunctions.WriteLineToConsoleYellow(_lastIp);
				Console.WriteLine("If this is not valid, please restart this app after writing your previously used local IP into this file:");
				Console.WriteLine(LastIpFilePath);
				Console.WriteLine();
			}
			else
			{
				_lastIp = PromptAndValidateIp("Can't find last IP Address. Tell me please: ");
			}
			while(_lastIp == null)
				_lastIp = PromptAndValidateIp("Invalid IP Address. Try again: ");

			// -- Get new ip
			var foundIps = GetMyLocalIPAddresses();
			if(foundIps.Count != 0)
			{
				Console.WriteLine("The potentional new IP Addresses found are:");
				foundIps.ForEach((ip, i) => Console.WriteLine("{0}: {1}", i, ip));
				Console.WriteLine();
				Console.Write("If your wanted new IP Address is among these, please give me it's index (eg '0'). ");
				_newIp = PromptAndValidateIp("Else write here the the new IP Address you want: ", foundIps);
			}

			while(_newIp == null)
				_newIp = PromptAndValidateIp("Invalid IP Address. Try again: ");

			// -- Write out new ip
			using(var writer = LastIpFile.CreateText())
			{
				writer.Write(_newIp);
			}

		}

		private static List<string> GetMyLocalIPAddresses()
		{
			return
				Dns.GetHostEntry(Dns.GetHostName()).AddressList
				.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork)
				.Select(ip => ip.ToString())
				.ToList();
		}

		private static string PromptAndValidateIp(string promptMsg, IList<string> list = null)
		{
			Console.Write(promptMsg);

			string readLine = "";
			GeneralFunctions.WithConsoleColor(ConsoleColor.Yellow, () => readLine = Console.ReadLine());

			if(string.IsNullOrWhiteSpace(readLine))
				return null;

			//-- Index based use
			if(readLine.Length == 1)
			{
				if(list == null)
					return null;

				int idx;
				try
				{
					idx = int.Parse(readLine);
				}
				catch(Exception)
				{
					return null;
				}

				if(list.Count < idx)
					return null;

				return list[idx];
			}

			//-- The user had to give an IP address
			return TryParseIp(readLine);
		}

		private static string GetLastIp()
		{
			if(!LastIpFile.Exists)
			{
				LastIpFile.Create().Close();
				return null;
			}

			string lastIpStr;
			using(var reader = LastIpFile.OpenText())
			{
				lastIpStr = reader.ReadToEnd().Trim();
			}

			return TryParseIp(lastIpStr);
		}

		private static string TryParseIp(string lastIpStr)
		{
			IPAddress dontCare;
			var successfulParsed = IPAddress.TryParse(lastIpStr, out dontCare);
			if(successfulParsed)
				return lastIpStr;
			else
				return null;
		}

		private static DirectoryInfo GetBackupDir()
		{
			var backupDirStart = DateTime.Now.ToString("yyyy-MM-dd");

			var lastDir = new DirectoryInfo(BackupDirRoot).EnumerateDirectories()
				.Where(dir => dir.Name.StartsWith(backupDirStart))
				.OrderByDescending(dir => dir.CreationTime)
				.FirstOrDefault();

			const string separateStr = " - ";
			int num = 0;
			if(lastDir != null)
				num = int.Parse(lastDir.Name.Substring(backupDirStart.Length + separateStr.Length));
			num++;

			var backupDirName = string.Format("{0}{1}{2}", backupDirStart, separateStr, num);
			var backupDir = new DirectoryInfo(Path.Combine(BackupDirRoot, backupDirName));

			if(backupDir.Exists)
				throw new Exception("Error while calculating the Backup directory's name. Already exists a directory with the calculated name.");

			backupDir.Create();
			return backupDir;
		}
	}
}
