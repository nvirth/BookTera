using System;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WindowsPhone.Annotations;
using WinPhoneClientProxy.CategoryManagerService;
using WindowsPhone.Common;
using WindowsPhone.Common.PageBase;
using WindowsPhone.ViewModels;
using Coding4Fun.Toolkit.Controls;
using CommonPortable.Enums;
using Microsoft.Phone.Controls;
using UtilsSharedPortable;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon.Models;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace WindowsPhone
{
	public partial class TransactionListPage : AuthPage, INotifyPropertyChanged
	{
		#region HeaderStrings

		private const string _cartOwnHeader = "Kosaraim";
		private const string _inProgressOrderOwnHeader = "Megrendeltek";
		private const string _inProgressOrderOthersHeader = "Folyamatban";
		private const string _cartOthersHeader = "Más kosarában";
		private const string _finishedOrderOwnHeader = "Korábbiak";
		private const string _finishedOrderOthersHeader = "Befejezett";

		public static string CartOwnHeader { get { return _cartOwnHeader; } }
		public static string CartOthersHeader { get { return _cartOthersHeader; } }
		public static string InProgressOrderOwnHeader { get { return _inProgressOrderOwnHeader; } }
		public static string InProgressOrderOthersHeader { get { return _inProgressOrderOthersHeader; } }
		public static string FinishedOrderOwnHeader { get { return _finishedOrderOwnHeader; } }
		public static string FinishedOrderOthersHeader { get { return _finishedOrderOthersHeader; } }

		#endregion

		#region MainTitle

		private const string _mainTitleSell = "BOOKTERA - ELADÁS";
		private const string _mainTitleBuy = "BOOKTERA - VÁSÁRLÁS";
		private string _mainTitle = "BOOKTERA";

		public string MainTitle
		{
			get { return _mainTitle; }
			set
			{
				if(value == _mainTitle)
					return;
				_mainTitle = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public TransactionListVM ViewModel { get; private set; }
		public bool IsBuy { get; private set; }

		public TransactionListPage()
		{
			ViewModel = new TransactionListVM();
			InitializeComponent();
			ViewModel.LongListSelectorCarts = LongListSelectorCartOwn;
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			if(NavigationContext.QueryString.ContainsKey("IsBuy"))
				IsBuy = bool.Parse(NavigationContext.QueryString["IsBuy"]);

			// The .RemoveAt method fires SelectionChanged event
			PivotRoot.SelectionChanged -= Pivot_SelectionChanged;

			string pivotItemHeader = null;
			var pivotItem = PivotRoot.SelectedItem as PivotItem;
			if(pivotItem != null)
				pivotItemHeader = (string)pivotItem.Header;

			if(IsBuy)
			{
				if(PivotRoot.Items.Count == 6) // Navigated forward, not via BackButton press
					for(int i = 0; i < 3; i++)
						PivotRoot.Items.RemoveAt(PivotRoot.Items.Count - 1); // Remove the last 3 item

				LoadData(pivotItemHeader ?? CartOwnHeader); // Load data to the first PivotItem: Cart
				MainTitle = _mainTitleBuy;
			}
			else
			{
				if(PivotRoot.Items.Count == 6) // Navigated forward, not via BackButton press
					for(int i = 0; i < 3; i++)
						PivotRoot.Items.RemoveAt(0); // Remove the first 3 item

				LoadData(pivotItemHeader ?? CartOthersHeader); // Load data to the first PivotItem: My books in others' cart
				MainTitle = _mainTitleSell;
			}

			PivotRoot.SelectionChanged += Pivot_SelectionChanged;
		}

		private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var pivot = (Pivot)sender;
			var pivotItem = (PivotItem)pivot.SelectedItem;

			LoadData(pivotItem.Header as string);
		}

		private void LoadData(string pivotItemHeader)
		{
			switch(pivotItemHeader)
			{
				case _cartOwnHeader:
					ViewModel.Load(TransactionType.CartOwn);
					break;
				case _cartOthersHeader:
					ViewModel.Load(TransactionType.CartOthers);
					break;
				case _inProgressOrderOwnHeader:
					ViewModel.Load(TransactionType.InProgressOrderOwn);
					break;
				case _inProgressOrderOthersHeader:
					ViewModel.Load(TransactionType.InProgressOrderOthers);
					break;
				case _finishedOrderOwnHeader:
					ViewModel.Load(TransactionType.FinishedOrderOwn);
					break;
				case _finishedOrderOthersHeader:
					ViewModel.Load(TransactionType.FinishedOrderOthers);
					break;
				default:
					throw new Exception("TransactionListPage/Pivot_SelectionChanged");
			}
		}

		#region INotifyPropertyChanged members

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if(handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		#region ContextMenu

		#region Core (open,close...)

		private void CartHeader_Tap(object sender, GestureEventArgs e)
		{
			App.OpenContextMenu(sender);
		}

		private void ContextMenu_OnOpened(object sender, RoutedEventArgs e)
		{
			App.ContextMenu_OnOpened_DoWork(sender, e);
		}

		private void ContextMenu_OnClosed(object sender, RoutedEventArgs e)
		{
			App.ContextMenu_OnClosed_DoWork(sender, e);
		}

		/// <summary>
		/// Without this, the ContextMenu will have (randomly) wrong DataContext... (Silverlight bug)
		/// </summary>
		private void ContextMenu_Unloaded(object sender, RoutedEventArgs e)
		{
			var contextMenu = (ContextMenu)sender;
			contextMenu.ClearValue(DataContextProperty);
		}

		#endregion

		private void ModifyOrderState_Core(UserOrderPlvmWp userOrderPlvmWp, string confirmMsg, string successMsg, string errorMsg, Action<int, Action, Action<WebException>> modifyOrderAction, Action refreshViewAfterSuccess)
		{
			var messageBoxResult = MessageBox.Show(confirmMsg, "Megerősítés", MessageBoxButton.OKCancel);
			if(messageBoxResult == MessageBoxResult.Cancel)
				return;

			Action todoAfterResponseReceived = () => Dispatcher.BeginInvoke(
				() =>
				{
					new ToastPrompt()
					{
						Message = successMsg
					}.Show();
					refreshViewAfterSuccess();
				});
			Action<WebException> todoWithWebException = webException => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show(errorMsg);
					bool noUnderline;
				});

			modifyOrderAction(userOrderPlvmWp.UserOrder.ID, todoAfterResponseReceived, todoWithWebException);
		}

		private void ContextMenu_UsersProducts_Click(object sender, RoutedEventArgs e)
		{
			var dataContext = (UserOrderPlvmWp)((MenuItem)sender).DataContext;
			var data = dataContext.Products[0];

			App.ContextMenu_UsersProducts_Click_DoWork(data);
		}

		private void ContextMenu_RemoveThisCart_Click(object sender, RoutedEventArgs e)
		{
			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			var msg = string.Format("Biztos, hogy törölni szeretnéd ezt a kosarat? ({0})", userOrderPlvmWp.UserOrder.VendorName);
			var messageBoxResult = MessageBox.Show(msg, "Törlés megerősítése", MessageBoxButton.OKCancel);
			if(messageBoxResult == MessageBoxResult.Cancel)
				return;

			Action todoAfterResponseReceived = () => Dispatcher.BeginInvoke(
				() =>
				{
					new ToastPrompt()
					{
						Message = "Kosár törölve!"
					}.Show();
					ViewModel.Carts.Remove(userOrderPlvmWp);
				});
			Action<WebException> todoWithWebException = webException => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Nem sikerült törölni a kosarad!");
					bool noUnderline;
				});

			Services.TransactionManagerClient.RemoveUsersCart(userOrderPlvmWp.UserOrder.ID,
				todoAfterResponseReceived, todoWithWebException);
		}

		private void ContextMenu_RemoveAllCarts_Click(object sender, RoutedEventArgs e)
		{
			var messageBoxResult = MessageBox.Show("Biztos, hogy törölni szeretnéd MINDEN kosarad?", "Törlés megerősítése", MessageBoxButton.OKCancel);
			if(messageBoxResult == MessageBoxResult.Cancel)
				return;

			Action todoAfterResponseReceived = () => Dispatcher.BeginInvoke(
				() =>
				{
					new ToastPrompt()
					{
						Message = "Minden kosarad törölve!"
					}.Show();
					ViewModel.Carts.Clear();
				});
			Action<WebException> todoWithWebException = webException => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Nem sikerült törölni a kosaraid!");
					bool noUnderline;
				});

			Services.TransactionManagerClient.RemoveUsersAllCarts(todoAfterResponseReceived, todoWithWebException);
		}

		private void ContextMenu_SendOrder_Click(object sender, RoutedEventArgs e)
		{
			// Customer

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.SendOrder;
			Action refreshViewAfterSuccess = () => ViewModel.Carts.Remove(userOrderPlvmWp);

			var confirmMsg = string.Format("Biztos, hogy meg szeretnéd rendelni ennek a kosarnák ({0}) a tartalmát?", userOrderPlvmWp.UserOrder.VendorName);
			var successMsg = string.Format("Megrendelés feladva! (lásd: \"{0}\" fül)", _inProgressOrderOwnHeader);
			const string errorMsg = "Nem sikerült feladni a rendelésed!";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		private void ContextMenu_AddExchangeProduct_Click(object sender, RoutedEventArgs e)
		{
			var userOrderVm = ((ComplexMenuItem)sender).UserOrderVm;

			var uri = new Uri(string.Format("/SearchPage.xaml?userFu={0}&userName={1}&forExchange=true&userOrderId={2}",
				userOrderVm.CustomerFriendlyUrl, userOrderVm.CustomerName, userOrderVm.ID), UriKind.Relative);

			var frame = (PhoneApplicationFrame)Application.Current.RootVisual;
			frame.Navigate(uri);
		}

		private void ContextMenu_RemoveExchangeCart_Click(object sender, RoutedEventArgs e)
		{
			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			var msg = string.Format("Biztos, hogy törölni szeretnéd ezt a csere-kosarat? ({0})", userOrderPlvmWp.UserOrder.CustomerName);
			var messageBoxResult = MessageBox.Show(msg, "Törlés megerősítése", MessageBoxButton.OKCancel);
			if(messageBoxResult == MessageBoxResult.Cancel)
				return;

			Action todoAfterResponseReceived = () => Dispatcher.BeginInvoke(
				() =>
				{
					new ToastPrompt()
					{
						Message = "Csere-kosár kiürítve!"
					}.Show();

					//ViewModel.Carts.Remove(userOrderPlvmWp);
					ViewModel.InProgressSells
						.First(plvm => plvm == userOrderPlvmWp)
						.ExchangeProducts
						.Clear();
				});
			Action<WebException> todoWithWebException = webException => Dispatcher.BeginInvoke(
				() =>
				{
					MessageBox.Show("Nem sikerült kiüríteni a csere-kosarad!");
					bool noUnderline;
				});

			Services.TransactionManagerClient.RemoveExchangeCart(userOrderPlvmWp.UserOrder.ID,
				todoAfterResponseReceived, todoWithWebException);
		}

		//todo innentől teszteletlen!
		// + ContextMenu_SendOrder_Click változott
		//ModifyOrderState_Core

		//itt a státusz frissül majd -- ez magával viszi a UserOrder frissítése nélkül a .Status -ra kötött dolgokat?
		// a ctx menü maszek, ott sztem menni fog
		// a felületen a státusz kiírás kérdése <-- az meg sztem közvetlen binding a status-ra
		private void ContextMenu_SendExchangeOffer_Click(object sender, RoutedEventArgs e)
		{
			// Vendor

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.SendExchangeOffer;
			Action refreshViewAfterSuccess = () => userOrderPlvmWp.UserOrder.Status = UserOrderStatus.BuyedExchangeOffered;

			var confirmMsg = string.Format("Biztos el szeretnéd küldeni ezt a csere-ajánlatot \"{0}\" felhasználónak?", userOrderPlvmWp.UserOrder.CustomerName);
			const string successMsg = "Csere ajánlat elküldve!";
			const string errorMsg = "Nem sikerült elküldeni a csere-ajánlatod.";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		private void ContextMenu_FinalizeOrderWithoutExchange_Click(object sender, RoutedEventArgs e)
		{
			// Vendor

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.FinalizeOrderWithoutExchange;
			Action refreshViewAfterSuccess = () => userOrderPlvmWp.UserOrder.Status = UserOrderStatus.FinalizedCash;

			var confirmMsg = string.Format("Biztos, hogy csere nélkül szeretnéd véglegesíteni \"{0}\" felhasználóval folytatott tranzakciód?", userOrderPlvmWp.UserOrder.CustomerName);
			const string successMsg = "A tranzakció csere nélkül véglegesítve!";
			const string errorMsg = "Nem sikerült a tranzakció (csere nélküli) véglegesítése.";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		private void ContextMenu_FinalizeOrderAcceptExchange_Click(object sender, RoutedEventArgs e)
		{
			// Customer

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.FinalizeOrderAcceptExchange;
			Action refreshViewAfterSuccess = () => userOrderPlvmWp.UserOrder.Status = UserOrderStatus.FinalizedExchange;

			var confirmMsg = string.Format("Biztos elfogadod \"{0}\" felhasználó csere ajánlatát?", userOrderPlvmWp.UserOrder.VendorName);
			const string successMsg = "A tranzakció cserével véglegesítve!";
			const string errorMsg = "Nem sikerült a tranzakció (cserével történő) véglegesítése.";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		private void ContextMenu_FinalizeOrderDenyExchange_Click(object sender, RoutedEventArgs e)
		{
			// Customer

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.FinalizeOrderDenyExchange;
			Action refreshViewAfterSuccess = () => userOrderPlvmWp.UserOrder.Status = UserOrderStatus.FinalizedCash;

			var confirmMsg = string.Format("Biztos elutasítod \"{0}\" felhasználó csere ajánlatát?", userOrderPlvmWp.UserOrder.VendorName);
			const string successMsg = "A tranzakció csere nélkül véglegesítve!";
			const string errorMsg = "Nem sikerült a tranzakció (csere nélküli) véglegesítése.";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		//ellenőrizni h frissül-e az állapot, hogy sikeresnek értékelte
		private void ContextMenu_CloseOrderSuccessful_Click(object sender, RoutedEventArgs e)
		{
			// Vendor + Customer

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.CloseOrderSuccessful;
			Action refreshViewAfterSuccess =
				() =>
				{
					switch(userOrderPlvmWp.TransactionType)
					{
						case TransactionType.InProgressOrderOthers: // Vendor's side
							ViewModel.InProgressSells.Remove(userOrderPlvmWp);
							break;
						case TransactionType.InProgressOrderOwn: // Customer's side
							ViewModel.InProgressBuys.Remove(userOrderPlvmWp);
							break;
						case TransactionType.FinishedOrderOthers: // Vendor's side
							userOrderPlvmWp.UserOrder.VendorFeedbackedSuccessful = true;
							break;
						case TransactionType.FinishedOrderOwn: // Customer's side
							userOrderPlvmWp.UserOrder.CustomerFeedbackedSuccessful = true;
							break;
					}
				};

			string successMsg;
			switch(userOrderPlvmWp.TransactionType)
			{
				case TransactionType.InProgressOrderOthers: // Vendor's side
					successMsg = string.Format("Tranzakció sikeres-ként lezárva! (lásd: \"{0}\" fül)", _finishedOrderOthersHeader);
					break;
				case TransactionType.InProgressOrderOwn:	// Customer's side
					successMsg = string.Format("Tranzakció sikeres-ként lezárva! (lásd: \"{0}\" fül)", _finishedOrderOwnHeader);
					break;

				//case TransactionType.FinishedOrderOthers:		// Vendor's side
				//case TransactionType.FinishedOrderOwn:		// Customer's side
				default:
					successMsg = string.Format("Tranzakció sikeres-ként lezárva!");
					break;
			}

			var otherParticipantName = userOrderPlvmWp.UserOrder.VendorName ?? userOrderPlvmWp.UserOrder.CustomerName;
			var confirmMsg = string.Format("Biztos, hogy sikeres volt a(z) {0} felhasználóval folytatott tranzakciód?", otherParticipantName);
			const string errorMsg = "Nem sikerült sikeres-ként lezárni a tranzakciót!";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		private void ContextMenu_CloseOrderUnsuccessful_Click(object sender, RoutedEventArgs e)
		{
			// Vendor + Customer

			var userOrderPlvmWp = (UserOrderPlvmWp)(((MenuItem)sender).DataContext);

			Action<int, Action, Action<WebException>> modifyOrderAction = Services.TransactionManagerClient.CloseOrderUnsuccessful;
			Action refreshViewAfterSuccess =
				() =>
				{
					switch(userOrderPlvmWp.TransactionType)
					{
						case TransactionType.InProgressOrderOthers: // Vendor's side
							ViewModel.InProgressSells.Remove(userOrderPlvmWp);
							break;
						case TransactionType.InProgressOrderOwn: // Customer's side
							ViewModel.InProgressBuys.Remove(userOrderPlvmWp);
							break;
						case TransactionType.FinishedOrderOthers: // Vendor's side
							userOrderPlvmWp.UserOrder.VendorFeedbackedSuccessful = false;
							break;
						case TransactionType.FinishedOrderOwn: // Customer's side
							userOrderPlvmWp.UserOrder.CustomerFeedbackedSuccessful = false;
							break;
					}
				};

			string successMsg;
			switch(userOrderPlvmWp.TransactionType)
			{
				case TransactionType.InProgressOrderOthers: // Vendor's side
					successMsg = string.Format("Tranzakció SIKERTELEN-ként lezárva! (lásd: \"{0}\" fül)", _finishedOrderOthersHeader);
					break;
				case TransactionType.InProgressOrderOwn:	// Customer's side
					successMsg = string.Format("Tranzakció SIKERTELEN-ként lezárva! (lásd: \"{0}\" fül)", _finishedOrderOwnHeader);
					break;

				//case TransactionType.FinishedOrderOthers:		// Vendor's side
				//case TransactionType.FinishedOrderOwn:		// Customer's side
				default:
					successMsg = string.Format("Tranzakció SIKERTELEN-ként lezárva!");
					break;
			}

			var otherParticipantName = userOrderPlvmWp.UserOrder.VendorName ?? userOrderPlvmWp.UserOrder.CustomerName;
			var confirmMsg = string.Format("Biztos, hogy SIKERTELEN volt a(z) {0} felhasználóval folytatott tranzakciód?", otherParticipantName);
			const string errorMsg = "Nem sikerült SIKERTELEN-ként lezárni a tranzakciót!";

			ModifyOrderState_Core(userOrderPlvmWp, confirmMsg, successMsg, errorMsg, modifyOrderAction, refreshViewAfterSuccess);
		}

		#endregion

	}
}