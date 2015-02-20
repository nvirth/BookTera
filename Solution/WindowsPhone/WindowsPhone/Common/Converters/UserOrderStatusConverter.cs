using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using CommonPortable.Enums;
using WinPhoneCommon;
using WinPhoneCommon.Models;

namespace WindowsPhone.Common.Converters
{
	public sealed class UserOrderStatusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var tpye = (UserOrderStatusConverterTpye)Enum.Parse(typeof(UserOrderStatusConverterTpye), (string)parameter);

			switch(tpye)
			{
				case UserOrderStatusConverterTpye.ToColor:
					return new SolidColorBrush(ConvertToColor(value));

				case UserOrderStatusConverterTpye.ToStirng:
					return ConvertToString(value);

				case UserOrderStatusConverterTpye.ToStatusBlockVisibility:
					return ConvertToStatusBlockVisibility(value);

				case UserOrderStatusConverterTpye.ToAddExchangeButtonVisibility:
					return ConvertToAddExchangeButtonVisibility(value);

				case UserOrderStatusConverterTpye.ToFinishedVisibility:
					return ConvertToFinishedVisibility(value);

				default:
					throw new NotImplementedException("UserOrderStatusConverter");
			}
		}

		private object ConvertToFinishedVisibility(object value)
		{
			if(!(value is UserOrderStatus))
				return Visibility.Collapsed;

			switch((UserOrderStatus)value)
			{
				case UserOrderStatus.Finished:
					return Visibility.Visible;
				default:
					return Visibility.Collapsed;
			}
		}

		private static Visibility ConvertToStatusBlockVisibility(object value)
		{
			if(!(value is UserOrderStatus))
				return Visibility.Collapsed;

			switch((UserOrderStatus)value)
			{
				case UserOrderStatus.Cart:
				case UserOrderStatus.Finished:

				case UserOrderStatus.CartDeleting:
				case UserOrderStatus.Nincs:
					return Visibility.Collapsed;
				default:
					return Visibility.Visible;
			}
		}
		
		private Visibility ConvertToAddExchangeButtonVisibility(object value)
		{
			var uoFullData = (Tuple<UserOrderVmWp, TransactionType>)value;
			var userOrder = uoFullData.Item1;
			var transactionType = uoFullData.Item2;

			if(userOrder.Status == UserOrderStatus.BuyedWaiting 
				&& transactionType == TransactionType.InProgressOrderOthers)
				return Visibility.Visible;
			
			return Visibility.Collapsed;
		}

		private static Color ConvertToColor(object value)
		{
			var uoFullData = (Tuple<UserOrderVmWp, TransactionType>)value;
			var userOrder = uoFullData.Item1;
			var transactionType = uoFullData.Item2;

			//Colors.Gray
			//Colors.Red
			//Colors.Blue

			//Colors.LawnGreen


			switch(userOrder.Status)
			{
				case UserOrderStatus.Cart:
					if(transactionType == TransactionType.CartOwn)
						return Colors.Green;
					//else if (transactionType == TransactionType.CartOthers)
					return Colors.Gray;

				case UserOrderStatus.BuyedWaiting:
					if(transactionType == TransactionType.InProgressOrderOthers)
						return Colors.Green;
					//else if(transactionType == TransactionType.InProgressOrderOwn)
					return Colors.Gray;

				case UserOrderStatus.BuyedExchangeOffered:
					if(transactionType == TransactionType.InProgressOrderOwn)
						return Colors.Green;
					//else if (transactionType == TransactionType.InProgressOrderOthers)
					return Colors.Gray;

				case UserOrderStatus.FinalizedCash:
				case UserOrderStatus.FinalizedExchange:
					return Colors.Green;

				case UserOrderStatus.Finished:
					return CopmuteFinishedColor(userOrder);

				case UserOrderStatus.CartDeleting:
				case UserOrderStatus.Nincs:
				default:
					return Colors.Gray;
			}
		}

		/// <summary>
		/// Vendor         null      true      false
		/// 
		/// Customer
		///   null         Gray      Orange    Red
		///   true         Orange    L.Green   Red
		///   false        Red       Red       Red
		/// </summary>
		private static Color CopmuteFinishedColor(UserOrderVmWp userOrder)
		{
			var color_LightGreen = new Color() { A = 200, R = 172, G = 222, B = 20 };
			var color_HalfGreen = new Color() { A = 255, R = 10, G = 215, B = 150 };

			switch(userOrder.VendorFeedbackedSuccessful)
			{
				case null:
					switch(userOrder.CustomerFeedbackedSuccessful)
					{
						case null:
							return Colors.Gray;
						case true:
							return color_HalfGreen;
						case false:
							return Colors.Red;
					}
					break;

				case true:
					switch(userOrder.CustomerFeedbackedSuccessful)
					{
						case null:
							return color_HalfGreen;
						case true:
							return color_LightGreen;
						case false:
							return Colors.Red;
					}
					break;

				case false:
					return Colors.Red;
			}

			// Never reach this
			return Colors.Blue;
		}

		private static string ConvertToString(object value)
		{
			if(!(value is UserOrderStatus))
				return "";

			return ((UserOrderStatus)value).ToDescriptionString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
