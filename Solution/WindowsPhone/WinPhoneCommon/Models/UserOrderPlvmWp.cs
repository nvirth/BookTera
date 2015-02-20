using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CommonModels.Models;
using CommonPortable.Enums;
using CommonPortable.Models.ProductModels;
using UtilsSharedPortable;
using WinPhoneCommon.Properties;

namespace WinPhoneCommon.Models
{
	public class UserOrderPlvmWp
	{
		public Tuple<UserOrderVmWp, TransactionType> UserOrderFullData { get; set; }

		public TransactionType TransactionType { get; set; }
		public UserOrderVmWp UserOrder { get; set; }

		public ObservableCollection<InBookBlockPVM> Products { get; set; }
		public ObservableCollection<InBookBlockPVM> ExchangeProducts { get; set; }

		public UserOrderPlvmWp()
		{
			Products = new ObservableCollection<InBookBlockPVM>();
			ExchangeProducts = new ObservableCollection<InBookBlockPVM>();
			UserOrder = new UserOrderVmWp();
		}

		public void InitAfterDeserialization(Action<InBookBlockPvmByTransaction> productRemovedFromCartHandler, Action<InBookBlockPvmByTransaction> exchangeProductRemovedHandler)
		{
			UserOrderFullData = new Tuple<UserOrderVmWp, TransactionType>(UserOrder, TransactionType);

			for(int i = 0; i < Products.Count; i++)
			{
				var products = new InBookBlockPvmByTransaction(Products[i], UserOrder, isExchangeProduct: false);
				Products[i] = products;

				products.RemovedFromCart += productRemovedFromCartHandler;
			}

			// The customer sent an order. The vendor took customer's book(s) to his ExchangeCart, 
			//  but he not sent that order yet. The customer must not view this unstable ExchangeCart!
			if(TransactionType == TransactionType.InProgressOrderOwn && UserOrder.Status == UserOrderStatus.BuyedWaiting)
				ExchangeProducts.Clear();
			else
				for(int i = 0; i < ExchangeProducts.Count; i++)
				{
					var exchanges = new InBookBlockPvmByTransaction(ExchangeProducts[i], UserOrder, isExchangeProduct: true);
					ExchangeProducts[i] = exchanges;

					exchanges.RemovedFromCart += exchangeProductRemovedHandler;
				}

			Products.CollectionChanged += ProductRemovedHandler;
		}

		void ProductRemovedHandler(object sender, NotifyCollectionChangedEventArgs e)
		{
			RefreshSummary();
		}

		public void RefreshSummary()
		{
			UserOrder.SumBookPrice = Products
				.Select(
					inBookBlockPvm =>
					{
						var price = inBookBlockPvm.Product.PriceString.ParseFormatted();
						return price * inBookBlockPvm.Product.HowMany;
					})
				.Sum();
		}
	}

	public class UserOrderVmWp : UserOrderPLVM.UserOrderVM, INotifyPropertyChanged
	{
		private readonly UserOrderPLVM.UserOrderVM _core;

		public UserOrderVmWp()
		{
			_core = new UserOrderPLVM.UserOrderVM();
		}

		public int SumCustomerFee { get { return (int)(SumBookPrice * CustomersFeePercent / 100.0); } }
		public int SumVendorFee { get { return (int)(SumBookPrice * VendorsFeePercent / 100.0); } }
		public int SumCustomerOrderAmount { get { return SumCustomerFee + SumBookPrice; } }

		#region Overriding/Delegating Properties

		public override int SumBookPrice
		{
			get { return _core.SumBookPrice; }
			set
			{
				_core.SumBookPrice = value;
				OnPropertyChanged();
				OnPropertyChanged(this.Property(uo => uo.SumCustomerFee));
				OnPropertyChanged(this.Property(uo => uo.SumVendorFee));
				OnPropertyChanged(this.Property(uo => uo.SumCustomerOrderAmount));
			}
		}

		public override UserOrderStatus Status
		{
			get { return _core.Status; }
			set
			{
				_core.Status = value;
				OnPropertyChanged();

			}
		}

		public override int ID { get { return _core.ID; } set { _core.ID = value; } }
		public override DateTime Date { get { return _core.Date; } set { _core.Date = value; } }

		public override int VendorsFeePercent { get { return _core.VendorsFeePercent; } set { _core.VendorsFeePercent = value; } }
		public override string VendorName { get { return _core.VendorName; } set { _core.VendorName = value; } }
		public override string VendorFriendlyUrl { get { return _core.VendorFriendlyUrl; } set { _core.VendorFriendlyUrl = value; } }
		public override string VendorAddress { get { return _core.VendorAddress; } set { _core.VendorAddress = value; } }
		public override int? VendorAddressId { get { return _core.VendorAddressId; } set { _core.VendorAddressId = value; } }

		public override int CustomersFeePercent { get { return _core.CustomersFeePercent; } set { _core.CustomersFeePercent = value; } }
		public override string CustomerName { get { return _core.CustomerName; } set { _core.CustomerName = value; } }
		public override string CustomerFriendlyUrl { get { return _core.CustomerFriendlyUrl; } set { _core.CustomerFriendlyUrl = value; } }
		public override string CustomerAddress { get { return _core.CustomerAddress; } set { _core.CustomerAddress = value; } }
		public override int? CustomerAddressId { get { return _core.CustomerAddressId; } set { _core.CustomerAddressId = value; } }

		public override bool? CustomerFeedbackedSuccessful { get { return _core.CustomerFeedbackedSuccessful; } set { _core.CustomerFeedbackedSuccessful = value; } }
		public override bool? VendorFeedbackedSuccessful { get { return _core.VendorFeedbackedSuccessful; } set { _core.VendorFeedbackedSuccessful = value; } }

		#endregion

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if(handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

	}

}
