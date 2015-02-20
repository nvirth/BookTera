using System;
using System.Linq;
using System.Threading.Tasks;
using CommonPortable.Enums;
using Microsoft.WindowsAzure.MobileServices;

namespace DAL.PushNotification
{
	public static partial class PushNotification
	{
		public const string ChannelName = "BookTeraPushChannel";
		public const string ApplicationUrl = "https://booktera.azure-mobile.net/";
		public const string ApplicationKey = "sqzVaVOzbBVYqNgYzQBLgVLBeSgxgi33";

		public static readonly MobileServiceClient MobileService = null;

		static PushNotification()
		{
			try
			{
				MobileService = new MobileServiceClient(ApplicationUrl, ApplicationKey);
			}
			catch(Exception e)
			{
				//const string msg = "MobileServiceClient was not successfully initialized (in class PushNotification, in DAL, for WP8)";
				//BookteraLog.ger.LogException(msg, e);
				// Push Notifciation will be disabled
			}
		}

		public static async Task Send(int userToSend, string msg, int actionCount = -1)
		{
			if(MobileService == null)
				return;

			var notificationDataTable = MobileService.GetTable<NotificationData>();
			var notificationData = await notificationDataTable
				.Where(data => data.UserId == userToSend)
				.ToListAsync();

			if(notificationData.Any()) // else: this user does not have any push notification subscription
			{
				notificationData[0].LastActionMessage = msg;
				notificationData[0].ActionCount = actionCount == -1 ? notificationData[0].ActionCount + 1 : actionCount;

				await notificationDataTable.UpdateAsync(notificationData[0]);
			}
		}
	}
}
