using System;
using System.Collections.Generic;
using System.Linq;
using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Methods.ManagerRelief;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Enums;
using CommonPortable.Models.ProductModels;
using UtilsLocal;

namespace BLL.ModelManagers
{
	public static class UserOrderPlvmManager
	{
		public static UserOrderPLVM DoConsturctorWork(this UserOrderPLVM instance, UserOrder userOrder, TransactionType transactionType, bool isForCustomer)
		{
			if(instance == null)
				instance = new UserOrderPLVM();

			var productsInOrder = userOrder.ProductsInOrder;
			if(productsInOrder.Count == 0)
				return instance;

			instance.Products = new List<InBookBlockPVM>();
			instance.ExchangeProducts = new List<InBookBlockPVM>();
			foreach(var productInOrder in productsInOrder)
			{
				var product = productInOrder.Product;
				if(productInOrder.IsForExchange)
					instance.ExchangeProducts.Add(new InBookBlockPVM().DoConsturctorWork(product, productInOrder));
				else
					instance.Products.Add(new InBookBlockPVM().DoConsturctorWork(product, productInOrder));
			}

			instance.UserOrder = new UserOrderPLVM.UserOrderVM().DoConsturctorWork(userOrder, instance.Products.First(), isForCustomer);
			instance.TransactionType = transactionType;

			return instance;
		}

		public static UserOrderPLVM.UserOrderVM DoConsturctorWork(this UserOrderPLVM.UserOrderVM instance, UserOrder userOrder, InBookBlockPVM productSample, bool isForCustomer)
		{
			if(instance == null)
				instance = new UserOrderPLVM.UserOrderVM();

			instance.ID = userOrder.ID;
			instance.Date = userOrder.Date;
			instance.SumBookPrice = userOrder.SumBookPrice;
			instance.Status = (UserOrderStatus)userOrder.Status;

			if(isForCustomer)
			{
				instance.CustomersFeePercent = userOrder.CustomersBuyFeePercent;

				instance.VendorName = productSample.Product.UserName;
				instance.VendorFriendlyUrl = productSample.Product.UserFriendlyUrl;

				if(userOrder.CustomerAddressID.HasValue)
				{
					instance.CustomerAddressId = userOrder.CustomerAddressID;
					instance.CustomerAddress = UserAddressManagerRelief.ToString(userOrder.CustomerAddress);
				}
			}
			else // isForVendor
			{
				instance.VendorsFeePercent = userOrder.VendorsSellFeePercent;

				var customerUserProfile = userOrder.CustomerUserProfile;
				instance.CustomerName = customerUserProfile.UserName;
				instance.CustomerFriendlyUrl = customerUserProfile.FriendlyUrl;

				if(userOrder.VendorAddressID.HasValue)
				{
					instance.VendorAddressId = userOrder.VendorAddressID;
					instance.VendorAddress = UserAddressManagerRelief.ToString(userOrder.VendorAddress);
				}
			}

			if(instance.Status == UserOrderStatus.Finished)
			{
				var feedbacks = userOrder.Feedbacks;
				foreach(var feedback in feedbacks)
				{
					if(feedback.IsCustomers)
						instance.CustomerFeedbackedSuccessful = feedback.WasSuccessful;
					else
						instance.VendorFeedbackedSuccessful = feedback.WasSuccessful;
				}
			}

			return instance;
		}
	}
}
