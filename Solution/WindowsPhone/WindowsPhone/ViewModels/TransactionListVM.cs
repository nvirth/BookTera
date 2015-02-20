using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using WindowsPhone.Common;
using Coding4Fun.Toolkit.Controls;
using CommonModels.Models;
using CommonPortable.Enums;
using CommonPortable.Models.ProductModels;
using Microsoft.Phone.Controls;
using UtilsSharedPortable;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;
using WinPhoneCommon.Models;

namespace WindowsPhone.ViewModels
{
	public class TransactionListVM : NotifyPropertyChanged
	{
		#region Data

		private ObservableCollection<UserOrderPlvmWp>[] _orders = new ObservableCollection<UserOrderPlvmWp>[6];

		public void SetOrder(TransactionType which, ObservableCollection<UserOrderPlvmWp> value)
		{
			_orders[(int)which] = value;
			OnPropertyChanged(GetPropertyName(which));
		}

		#region Carts

		public LongListSelector LongListSelectorCarts { get; set; }
		public ObservableCollection<UserOrderPlvmWp> Carts
		{
			get { return _orders[(int)TransactionType.CartOwn]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.CartOwn]))
					return;
				_orders[(int)TransactionType.CartOwn] = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region InCartsByOthers

		public ObservableCollection<UserOrderPlvmWp> InCartsByOthers
		{
			get { return _orders[(int)TransactionType.CartOthers]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.CartOthers]))
					return;
				_orders[(int)TransactionType.CartOthers] = value;
				OnPropertyChanged();
			}
		}

		#endregion


		#region InProgressBuys

		public ObservableCollection<UserOrderPlvmWp> InProgressBuys
		{
			get { return _orders[(int)TransactionType.InProgressOrderOwn]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.InProgressOrderOwn]))
					return;
				_orders[(int)TransactionType.InProgressOrderOwn] = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region InProgressSells

		public ObservableCollection<UserOrderPlvmWp> InProgressSells
		{
			get { return _orders[(int)TransactionType.InProgressOrderOthers]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.InProgressOrderOthers]))
					return;
				_orders[(int)TransactionType.InProgressOrderOthers] = value;
				OnPropertyChanged();
			}
		}

		#endregion


		#region EarlierBuys

		public ObservableCollection<UserOrderPlvmWp> EarlierBuys
		{
			get { return _orders[(int)TransactionType.FinishedOrderOwn]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.FinishedOrderOwn]))
					return;
				_orders[(int)TransactionType.FinishedOrderOwn] = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region EarlierSells

		public ObservableCollection<UserOrderPlvmWp> EarlierSells
		{
			get { return _orders[(int)TransactionType.FinishedOrderOthers]; }
			set
			{
				if(Equals(value, _orders[(int)TransactionType.FinishedOrderOthers]))
					return;
				_orders[(int)TransactionType.FinishedOrderOthers] = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#endregion

		public void Load(TransactionType type)
		{
			//(int? customerId, int? vendorId, Action<ObservableCollection<UserOrderPLVM>> todoWithResponse, Action<WebException> todoWithWebException)
			Action<int?, int?, Action<ObservableCollection<UserOrderPlvmWp>>, Action<WebException>> action;
			int? customerId;
			int? vendorId;
			SetWichData(type, out customerId, out vendorId, out action);

			Action<ObservableCollection<UserOrderPlvmWp>> todoWithResponse = plvms => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					// change/calculate the viewmodel
					foreach(var userOrderPlvm in plvms)
						userOrderPlvm.InitAfterDeserialization(ProductRemovedFromCartHandler, ExchangeProductRemovedHandler);

					SetOrder(type, plvms);
				});

			action(customerId, vendorId, todoWithResponse, null);
		}

		private void ExchangeProductRemovedHandler(InBookBlockPvmByTransaction bookBlock)
		{
			InProgressSells.First(userOrderPlvmWp => userOrderPlvmWp.ExchangeProducts.Remove(bookBlock));
		}

		private void ProductRemovedFromCartHandler(InBookBlockPvmByTransaction bookBlock)
		{
			// -- Remove the from-cart-removed book from the correspondent Cart

			UserOrderPlvmWp cartRemovedFrom = null;
			var wasAroundEnd = false;
			foreach(var userOrderPlvmWp in Carts)
			{
				var indexOfRemoved = userOrderPlvmWp.Products.IndexOf(bookBlock);
				if(indexOfRemoved >= 0)
				{
					cartRemovedFrom = userOrderPlvmWp;
					wasAroundEnd = (userOrderPlvmWp.Products.Count - indexOfRemoved) <= 3; // index is zero based
					userOrderPlvmWp.Products.RemoveAt(indexOfRemoved);
					break;
				}
			}

			// If we could not remove the item, something went wrong
			if (cartRemovedFrom==null)
				throw new Exception();

			// If the removed item was one of the last 2 books in the last cart, because of a Framework bug,
			// the screen will be empty. The reason is only, we got out from the visible area,
			// so we have to scroll up a bit
			var isBigEnough = cartRemovedFrom.Products.Count >= 3; // the item is already removed
			var isLastCart = Carts[Carts.Count - 1] == cartRemovedFrom;
			if(wasAroundEnd && isLastCart && isBigEnough)
				LongListSelectorCarts.ScrollTo(cartRemovedFrom);

			// If the cart became empty
			if (cartRemovedFrom.Products.Count == 0)
				Carts.Remove(cartRemovedFrom);
		}

		private void SetWichData(TransactionType type, out int? customerId, out int? vendorId,
			out Action<int?, int?, Action<ObservableCollection<UserOrderPlvmWp>>, Action<WebException>> action)
		{
			switch(type)
			{
				case TransactionType.CartOwn:
					action = Services.TransactionManagerClient.GetUsersCartsVM;
					vendorId = null;
					customerId = StaticData.UserData.UserId;
					break;
				case TransactionType.CartOthers:
					action = Services.TransactionManagerClient.GetUsersCartsVM;
					customerId = null;
					vendorId = StaticData.UserData.UserId;
					break;
				case TransactionType.InProgressOrderOwn:
					action = Services.TransactionManagerClient.GetUsersInProgressOrdersVM;
					vendorId = null;
					customerId = StaticData.UserData.UserId;
					break;
				case TransactionType.InProgressOrderOthers:
					action = Services.TransactionManagerClient.GetUsersInProgressOrdersVM;
					customerId = null;
					vendorId = StaticData.UserData.UserId;
					break;
				case TransactionType.FinishedOrderOwn:
					action = Services.TransactionManagerClient.GetUsersFinishedTransactionsVM;
					vendorId = null;
					customerId = StaticData.UserData.UserId;
					break;
				case TransactionType.FinishedOrderOthers:
					action = Services.TransactionManagerClient.GetUsersFinishedTransactionsVM;
					customerId = null;
					vendorId = StaticData.UserData.UserId;
					break;
				default:
					throw new Exception();
			}
		}

		private string GetPropertyName(TransactionType type)
		{
			switch(type)
			{
				case TransactionType.CartOwn:
					return this.Property(vm => vm.Carts);
				case TransactionType.CartOthers:
					return this.Property(vm => vm.InCartsByOthers);
				case TransactionType.InProgressOrderOwn:
					return this.Property(vm => vm.InProgressBuys);
				case TransactionType.InProgressOrderOthers:
					return this.Property(vm => vm.InProgressSells);
				case TransactionType.FinishedOrderOwn:
					return this.Property(vm => vm.EarlierBuys);
				case TransactionType.FinishedOrderOthers:
					return this.Property(vm => vm.EarlierSells);
				default:
					throw new Exception();
			}
		}
	}

}
