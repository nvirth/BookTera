using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhone.Annotations;
using CommonModels.Models;
using CommonPortable.Enums;
using CommonPortable.Models.ProductModels;
using Microsoft.Phone.Controls;
using WinPhoneCommon.Models;

namespace WindowsPhone.Common
{
	public class ComplexMenuItem : MenuItem
	{
		#region IsQuantityGreaterThanZero

		public bool IsQuantityGreaterThanZero
		{
			get { return (bool)GetValue(IsQuantityGreaterThanZeroProperty); }
			set { SetValue(IsQuantityGreaterThanZeroProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsQuantity.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsQuantityGreaterThanZeroProperty =
			DependencyProperty.Register("IsQuantityGreaterThanZero", typeof(bool), typeof(ComplexMenuItem), null);

		#endregion

		#region IsUserAuthenticated

		public bool IsUserAuthenticated
		{
			get { return (bool)GetValue(IsUserAuthenticatedProperty); }
			set { SetValue(IsUserAuthenticatedProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsUserAuthenticated.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsUserAuthenticatedProperty =
			DependencyProperty.Register("IsUserAuthenticated", typeof(bool), typeof(ComplexMenuItem), null);

		#endregion

		#region IsProduct

		public bool IsProduct
		{
			get { return (bool)GetValue(IsProductProperty); }
			set { SetValue(IsProductProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsProductGroup.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsProductProperty =
			DependencyProperty.Register("IsProduct", typeof(bool), typeof(ComplexMenuItem), null);

		#endregion

		#region IsExchangeProduct

		public bool IsExchangeProduct
		{
			get { return (bool)GetValue(IsExchangeProductProperty); }
			set { SetValue(IsExchangeProductProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsExchangeProduct.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IsExchangeProductProperty =
			DependencyProperty.Register("IsExchangeProduct", typeof(bool), typeof(ComplexMenuItem), null);

		#endregion

		#region ProductOwnerName

		public string ProductOwnerName
		{
			get { return (string)GetValue(ProductOwnerNameProperty); }
			set { SetValue(ProductOwnerNameProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsUsersOwn.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ProductOwnerNameProperty =
			DependencyProperty.Register("ProductOwnerName", typeof(string), typeof(ComplexMenuItem), null);

		#endregion


		#region UserOrderVm

		public UserOrderVmWp UserOrderVm
		{
			get { return (UserOrderVmWp)GetValue(UserOrderVmProperty); }
			set { SetValue(UserOrderVmProperty, value); }
		}

		// Using a DependencyProperty as the backing store for IsOrderPage.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty UserOrderVmProperty =
			DependencyProperty.Register("UserOrderVm", typeof(UserOrderVmWp), typeof(ComplexMenuItem), null);

		#endregion

		#region TransactionType

		public TransactionType? TypeOfTransaction
		{
			get { return (TransactionType?)GetValue(TypeOfTransactionProperty); }
			set { SetValue(TypeOfTransactionProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TransactionType.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TypeOfTransactionProperty =
			DependencyProperty.Register("TypeOfTransaction", typeof(TransactionType?), typeof(ComplexMenuItem), null);

		#endregion

		#region ExchangeProducts

		public ObservableCollection<InBookBlockPVM> ExchangeProducts
		{
			get { return (ObservableCollection<InBookBlockPVM>)GetValue(ExchangeProductsProperty); }
			set { SetValue(ExchangeProductsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ExchangeProductsProperty =
			DependencyProperty.Register("ExchangeProducts", typeof(ObservableCollection<InBookBlockPVM>), typeof(ComplexMenuItem), null);

		#endregion


		public bool IsAddToCartMenuItem { get; set; }
		#region AddToCartVisibility

		public Visibility AddToCartVisibility
		{
			get
			{
				if(IsQuantityGreaterThanZero && IsUserAuthenticated && IsProduct && UserOrderVm == null)
				{
					// Not own book
					if((ProductOwnerName ?? "").ToLower() != StaticData.UserData.UserName.ToLower())
						return Visibility.Visible;
				}

				return Visibility.Collapsed;
			}
		}

		#endregion

		public bool IsAddToExchangeCartMenuItem { get; set; }
		#region AddToExchangeCartVisibility

		public Visibility AddToExchangeCartVisibility
		{
			get
			{
				if(IsQuantityGreaterThanZero && IsUserAuthenticated && IsProduct
					&& UserOrderVm == null && StaticData.IsAddToExchangeCartPossible)
					return Visibility.Visible;

				return Visibility.Collapsed;
			}
		}

		#endregion

		public bool IsOwnCartMenuItem { get; set; }
		#region OwnCartItemVisibility

		public Visibility OwnCartItemVisibility
		{
			get
			{
				if(UserOrderVm != null
					&& UserOrderVm.Status == UserOrderStatus.Cart
					&& string.IsNullOrWhiteSpace(UserOrderVm.CustomerName)
					&& !string.IsNullOrWhiteSpace(UserOrderVm.VendorName)
					)
					return Visibility.Visible;

				return Visibility.Collapsed;
			}
		}

		#endregion

		public bool IsExchangeCartMenuItem { get; set; }
		#region ExchangeCartItemVisibility

		public Visibility ExchangeCartItemVisibility
		{
			get
			{
				if(!IsExchangeProduct)
					return Visibility.Collapsed;
				if(UserOrderVm == null || UserOrderVm.Status != UserOrderStatus.BuyedWaiting)
					return Visibility.Collapsed;

				// There is no need to check the TransactionType, because if it's InProg.Own,
				// there will bot be any exchange books displayed

				return Visibility.Visible;
			}
		}

		#endregion

		public bool IsInStatus_BuyedExchangeOffered { get; set; }
		#region BuyedExchangeOfferedStatusVisibility

		public Visibility BuyedExchangeOfferedStatusVisibility
		{
			get
			{
				if(UserOrderVm == null || UserOrderVm.Status != UserOrderStatus.BuyedExchangeOffered)
					return Visibility.Collapsed;

				return Visibility.Visible;
			}
		}

		#endregion

		public bool IsFeedbackMenuItem { get; set; }
		#region FeedbackItemVisibility

		public Visibility FeedbackItemVisibility
		{
			get
			{
				if(UserOrderVm == null || TypeOfTransaction == null)
					return Visibility.Collapsed;

				// InProgress
				if(UserOrderVm.Status == UserOrderStatus.FinalizedCash
					|| UserOrderVm.Status == UserOrderStatus.FinalizedExchange)
					return Visibility.Visible;

				// Finished
				if(UserOrderVm.Status == UserOrderStatus.Finished)
				{
					// My buy, and I have not feedbacked yet
					if(TypeOfTransaction.Value == TransactionType.FinishedOrderOwn
						&& !UserOrderVm.CustomerFeedbackedSuccessful.HasValue)
						return Visibility.Visible;

					// My sell, and I have not feedbacked yet
					if(TypeOfTransaction.Value == TransactionType.FinishedOrderOthers
						&& !UserOrderVm.VendorFeedbackedSuccessful.HasValue)
						return Visibility.Visible;
				}

				return Visibility.Collapsed;
			}
		}

		#endregion

		public bool IsInProgressSell { get; set; }
		public bool NeedNonEmptyExchangeList { get; set; }
		#region InProgressSellVisibility

		public Visibility InProgressSellVisibility
		{
			get
			{
				if(UserOrderVm == null || TypeOfTransaction == null)
					return Visibility.Collapsed;

				//IsRemoveFromExchangeCartMenuItem

				if(UserOrderVm.Status == UserOrderStatus.BuyedWaiting
					&& TypeOfTransaction.Value == TransactionType.InProgressOrderOthers)
				{
					if(NeedNonEmptyExchangeList)
					{
						if(ExchangeProducts.Count > 0)	// else Collapsed
							return Visibility.Visible;
					}
					else
					{
						return Visibility.Visible;
					}
				}

				return Visibility.Collapsed;
			}
		}

		#endregion

		public void ApplyComplexVisibility()
		{
			if(IsAddToCartMenuItem)
				Visibility = AddToCartVisibility;
			else if(IsOwnCartMenuItem)
				Visibility = OwnCartItemVisibility;
			else if(IsInStatus_BuyedExchangeOffered)
				Visibility = BuyedExchangeOfferedStatusVisibility;
			else if(IsFeedbackMenuItem)
				Visibility = FeedbackItemVisibility;
			else if(IsExchangeCartMenuItem)
				Visibility = ExchangeCartItemVisibility;
			else if(IsInProgressSell)
				Visibility = InProgressSellVisibility;
			else if(IsAddToExchangeCartMenuItem)
				Visibility = AddToExchangeCartVisibility;
		}
	}
}
