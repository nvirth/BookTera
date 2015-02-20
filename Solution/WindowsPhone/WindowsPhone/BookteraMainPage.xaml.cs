using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhone.Common.BackgroundAgent;
using WindowsPhone.Common.PageBase;
using WindowsPhone.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TileUpdaterAgent;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace WindowsPhone
{
	public partial class BookteraMainPage : BookteraPageBase
	{
		public MainPageVM MainPageVm { get; set; }

		public BookteraMainPage()
		{
			InitializeComponent();
			MainPageVm = new MainPageVM();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if (!MainPageVm.AreMainHighlightedsLoaded)
				MainPageVm.LoadData();

			InitSecondaryTile();
		}

		/// <summary>
		/// Ask the user if he/she wants a secondary tile (quasy with ads :D)
		/// </summary>
		private static void InitSecondaryTile()
		{
			var tileManager = new TileManager();
			if(tileManager.SecondaryTile != null)
				return;

			var messageBoxResult = MessageBox.Show("Szeretnéd bekapcsolni a Booktera másodlagos csempe szolgáltatását?", "Másodlagos csempe", MessageBoxButton.OKCancel);
			if (messageBoxResult == MessageBoxResult.Cancel)
				return;

			// The user accepted the secondary tile. Start it's background agent as well
			tileManager.InitSecondaryTile();
			new PeriodicAgentStarter().StartPeriodicAgent();
		}
	}
}