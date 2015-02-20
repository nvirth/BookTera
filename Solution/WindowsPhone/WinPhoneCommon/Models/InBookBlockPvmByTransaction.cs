using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommonPortable.Models.ProductModels;
using UtilsSharedPortable;
using WinPhoneCommon.Properties;

namespace WinPhoneCommon.Models
{
	public class InBookBlockPvmByTransaction : InBookBlockPVM
	{
		public UserOrderVmWp UserOrder { get; set; }
		public bool IsExchangeProduct { get; set; }

		public InBookBlockPvmByTransaction(InBookBlockPVM core, UserOrderVmWp userOrder, bool isExchangeProduct)
		{
			Product = new ProductVmWp(core.Product);
			ProductGroup = core.ProductGroup;
			UserOrder = userOrder;
			IsExchangeProduct = isExchangeProduct;
		}

		public class ProductVmWp : ProductVM, INotifyPropertyChanged
		{
			private readonly ProductVM _core;

			public ProductVmWp(ProductVM core)
			{
				_core = core;
			}

			#region Overriding/Delegating members

			public override int ID { get { return _core.ID; } set { _core.ID = value; } }
			public override string ImageUrl { get { return _core.ImageUrl; } set { _core.ImageUrl = value; } }
			public override string PriceString { get { return _core.PriceString; } set { _core.PriceString = value; } }

			public override int HowMany
			{
				get { return _core.HowMany; }
				set
				{
					_core.HowMany = value;
					OnPropertyChanged();
				}
			}
			public override string UserName { get { return _core.UserName; } set { _core.UserName = value; } }
			public override string UserFriendlyUrl { get { return _core.UserFriendlyUrl; } set { _core.UserFriendlyUrl = value; } }
			public override string Description { get { return _core.Description; } set { _core.Description = value; } }
			public override bool IsDownloadable { get { return _core.IsDownloadable; } set { _core.IsDownloadable = value; } }

			public override int ProductInOrderId { get { return _core.ProductInOrderId; } set { _core.ProductInOrderId = value; } }

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

		#region Events

		public event Action<InBookBlockPvmByTransaction> RemovedFromCart;
		public void OnRemovedFromCart()
		{
			var handler = RemovedFromCart;
			if(handler != null)
				handler(this);
		}

		#endregion

		public void RefreshQuantity(int newQuantity, bool refreshSummary = true)
		{
			var oldQuantity = Product.HowMany;
			var price = Product.PriceString.ParseFormatted();

			if(!Product.IsDownloadable)	// Electronic product's qunatity is always 1
				Product.HowMany = newQuantity;

			if(refreshSummary)
				UserOrder.SumBookPrice += (newQuantity - oldQuantity) * price;
		}
	}
}
