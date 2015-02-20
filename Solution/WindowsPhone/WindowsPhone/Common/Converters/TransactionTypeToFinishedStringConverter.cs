using System;
using System.Globalization;
using System.Windows.Data;
using CommonPortable.Enums;
using WinPhoneCommon;

namespace WindowsPhone.Common.Converters
{
	public sealed class TransactionTypeToFinishedStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var transactionType = (TransactionType)value;
			var participantType = (ParticipantType)Enum.Parse(typeof(ParticipantType), (string)parameter);

			switch(transactionType)
			{
				case TransactionType.FinishedOrderOwn:
					switch(participantType)
					{
						case ParticipantType.Customer:
							return "A Te értékelésed: ";
						case ParticipantType.Vendor:
							return "Az eladó értékelése: ";
					}
					break;
				case TransactionType.FinishedOrderOthers:
					switch(participantType)
					{
						case ParticipantType.Customer:
							return "A vevő értékelése: ";
						case ParticipantType.Vendor:
							return "A Te értékelésed: ";
					}
					break;
				default:
					return "";
			}

			// Never reach this
			throw new Exception();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
