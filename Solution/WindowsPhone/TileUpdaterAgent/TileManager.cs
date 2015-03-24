using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Media.PhoneExtensions;

namespace TileUpdaterAgent
{
	public class TileManager
	{
		#region Members

		private const string SecondTileFragment = "isSecondaryTile";
		private const string ImageFolder = @"\Shared\ShellContent";
		private const string SharedImageFormat = "TileImage{0}.jpg";
		private const string ProductImagesDirFormat = "http://192.168.1.101:50308/Content/Images/ProductImages/{0}";
		private const string SecondaryTileTitle = "BookTera - Kiemeltek";

		public readonly ShellTile SecondaryTile =
			ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(SecondTileFragment));

		#endregion


		private string GetProductImageUrl(string imageFileName, bool noCache = false)
		{
			var result = string.Format(ProductImagesDirFormat, imageFileName);
			if(noCache)
				result += "?" + DateTime.Now.Ticks;

			return result;
		}

		public void InitSecondaryTile()
		{
			if(SecondaryTile == null)
			{
				var tileUri = new Uri(string.Format("/BookteraMainPage.xaml?{0}=true", SecondTileFragment), UriKind.Relative);
				var tileData = new CycleTileData
				{
					Title = SecondaryTileTitle,
				};
				ShellTile.Create(tileUri, tileData, supportsWideTile: false);
			}
		}

		// --

		public async Task UpdateSecondaryTileImages(string[] imageUrls)
		{
			if(SecondaryTile == null || imageUrls == null)
				return;

			var _savedImageUris = new List<Uri>();
			using(var httpClient = new HttpClient())
			{
				for(int i = 0; i < imageUrls.Length; i++)
				{
					var requestUri = new Uri(GetProductImageUrl(imageUrls[i]), UriKind.Absolute);

					Stream response;

					response = await httpClient.GetStreamAsync(requestUri);

					using(var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
					{
						if(!myIsolatedStorage.DirectoryExists(ImageFolder))
						{
							myIsolatedStorage.CreateDirectory(ImageFolder);
						}

						var sharedImageName = string.Format(SharedImageFormat, i);
						var fullPath = Path.Combine(ImageFolder, sharedImageName); //pl "Shared\\ShellContent\\BackgroundImage.jpg"
						if(myIsolatedStorage.FileExists(fullPath))
						{
							myIsolatedStorage.DeleteFile(fullPath);
						}

						using(var stream = myIsolatedStorage.CreateFile(fullPath))
						{
							response.CopyTo(stream);
						}

						_savedImageUris.Add(new Uri(@"isostore:" + fullPath, UriKind.Absolute));
					}
				}
			}

			SecondaryTile.Update(new CycleTileData()
			{
				Title = SecondaryTileTitle,
				SmallBackgroundImage = _savedImageUris.Any() ? _savedImageUris[0] : null,
				CycleImages = _savedImageUris
			});
		}
	}
}
