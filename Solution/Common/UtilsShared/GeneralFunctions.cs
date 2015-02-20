using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using UtilsSharedPortable;

namespace UtilsShared
{
	public class GeneralFunctions
	{
		// -- Properties, Fields

		public static readonly Random Random = new Random(DateTime.Now.Millisecond);

		// -- Methods

		#region DeleteDirectoryIfExist

		public static void DeleteDirectoryIfExist(string dir, bool reCreateDir = true)
		{
			int numOfErrors = 0;
			bool wasError;

			do
			{
				try
				{
					//if(!Directory.Exists(dir))
					//	Directory.CreateDirectory(dir);

					if(Directory.Exists(dir))
						Directory.Delete(dir, true);

					if(reCreateDir)
					{
						Directory.CreateDirectory(dir);

						// Tutira megyünk, nagyon aljas az a hiba!
						for(int i = 0; i < 10; i++)
						{
							Thread.Sleep(0);
							if(!Directory.Exists(dir))
								throw new Exception();
						}
					}

					wasError = false;
				}
				// Random néha előjön, hogy nem sikerül letörölnie/újra léterhoznia a könyvtárat (random módon)
				catch(Exception exception)
				{
					wasError = true;
					numOfErrors++;

					var beforeColor = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("!! Random Directory-Delete Exception !! - " + numOfErrors);
					Console.WriteLine(" " + exception.Message);

					if (numOfErrors == 10)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("No more try. The program will not work properly. ");
					}

					Console.ForegroundColor = beforeColor;

					Thread.Sleep(10);
				}
			} while((numOfErrors < 10) && (wasError));
		}

		#endregion

		#region Console

		public static void WithConsoleColor(ConsoleColor color, Action action)
		{
			var beforeColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			action();
			Console.ForegroundColor = beforeColor;
		}

		public static void WriteLineToConsoleYellow(string msg)
		{
			WithConsoleColor(ConsoleColor.Yellow, () => Console.WriteLine(msg));
		}

		public static void WriteToConsoleYellow(string msg)
		{
			WithConsoleColor(ConsoleColor.Yellow, () => Console.Write(msg));
		}

		#endregion

		#region CreateSelectListWithInit

		public static List<SelectListItemWithClass> CreateSelectListWithInit(bool initIsSelected = false, IEnumerable<SelectListItemWithClass> afterFirstItems = null)
		{
			var result = new List<SelectListItemWithClass>()
			{
				new SelectListItemWithClass()
				{
					Text = "Válassz",
					Value = string.Empty,
					Selected = initIsSelected
				}
			};

			if(afterFirstItems != null)
				result.AddRange(afterFirstItems);

			result.Add(new SelectListItemWithClass()
			{
				Text = string.Empty,
				Value = string.Empty
			});

			return result;
		}

		#endregion

		#region Enum

		public static List<SelectListItem> ConvertEnumToSelectListItems(Type enumType)
		{
			var result = new List<SelectListItem>();
			foreach(string name in Enum.GetNames(enumType))
			{
				var value = ((int)Enum.Parse(enumType, name)).ToString(Constants.CultureInfoHu);
				result.Add(new SelectListItem()
				{
					Text = name,
					Value = value,
					Selected = false
				});
			}
			return result;
		}

		#endregion

		#region File

		public static void CreateNewFileDeleteOld(FileInfo newFile, FileInfo oldFile, StringBuilder stringBuilder)
		{
			using(var streamWriter = new StreamWriter(newFile.FullName))
			{
				streamWriter.Write(stringBuilder.ToString());
			}
			newFile.Refresh();	// Egyébként a FileInfo objektum nem frissül, és pl Exist == false marad

			if(oldFile != null && oldFile.FullName != newFile.FullName)	// && oldFile.Exists)
				oldFile.Delete();
		}

		public static void CreateNewFileDeleteOld(string newFilePath, FileInfo oldFile, FileInfo fileToCopy)
		{
			fileToCopy.CopyTo(newFilePath, /*overwrite*/ true);

			if(oldFile != null && oldFile.FullName != newFilePath)
				oldFile.Delete();
		}

		#endregion

		#region File in

		public static string[] ReadInFile(string path, Encoding encoding = null)
		{
			return ReadInFileList(path, encoding).ToArray();
		}

		public static List<string> ReadInFileList(string path, Encoding encoding = null)
		{
			encoding = encoding ?? Encoding.UTF8;

			using(var reader = new StreamReader(new FileStream(path, FileMode.Open), encoding))
			{
				var stringList = new List<string>();
				while(!reader.EndOfStream)
				{
					stringList.Add(reader.ReadLine());
				}
				return stringList;
			}
		}

		public static string ReadInFileString(string path, Encoding encoding = null)
		{
			encoding = encoding ?? Encoding.UTF8;

			using(var reader = new StreamReader(new FileStream(path, FileMode.Open), encoding))
			{
				return reader.ReadToEnd();
			}
		}

		#endregion
	}
}
