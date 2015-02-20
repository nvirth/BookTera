using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommonPortable.Enums;
using CommonPortable.Models.ProductModels;

namespace CommonModels.Models
{
	public class UserOrderPLVM
	{
		public TransactionType TransactionType { get; set; }

		public UserOrderVM UserOrder { get; set; }
		public IList<InBookBlockPVM> Products { get; set; }
		public IList<InBookBlockPVM> ExchangeProducts { get; set; }

		public class UserOrderVM
		{
			public virtual int ID { get; set; }
			public virtual DateTime Date { get; set; }
			public virtual int SumBookPrice { get; set; }

			public virtual UserOrderStatus Status { get; set; }

			public virtual int VendorsFeePercent { get; set; }
			public virtual string VendorName { get; set; }
			public virtual string VendorFriendlyUrl { get; set; }
			public virtual string VendorAddress { get; set; }
			public virtual int? VendorAddressId { get; set; }

			public virtual int CustomersFeePercent { get; set; }
			public virtual string CustomerName { get; set; }
			public virtual string CustomerFriendlyUrl { get; set; }
			public virtual string CustomerAddress { get; set; }
			public virtual int? CustomerAddressId { get; set; }

			public virtual bool? CustomerFeedbackedSuccessful { get; set; }
			public virtual bool? VendorFeedbackedSuccessful { get; set; }
		}
	}
}
