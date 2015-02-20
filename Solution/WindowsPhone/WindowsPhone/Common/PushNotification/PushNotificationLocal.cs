using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WindowsPhone.Common;
using Coding4Fun.Toolkit.Controls;
using DAL.PushNotification;
using Microsoft.Phone.Notification;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using UtilsSharedPortable;

namespace DAL.PushNotification
{
	public static partial class PushNotification
	{
		public static HttpNotificationChannel CurrentChannel { get; private set; }

		public static async Task AcquirePushChannel()
		{
			// -- Channel

			CurrentChannel = HttpNotificationChannel.Find(ChannelName);
			if(CurrentChannel == null)
			{
				CurrentChannel = new HttpNotificationChannel(ChannelName);
				CurrentChannel.Open();
				CurrentChannel.BindToShellTile();
				CurrentChannel.BindToShellToast();
			}

			CurrentChannel.ShellToastNotificationReceived += ShellToastNotificationReceived;

			// -- NotificationRegistration

			var registrationsTable = MobileService.GetTable<NotificationRegistration>();
			var registration = new NotificationRegistration
			{
				ChannelUri = CurrentChannel.ChannelUri.AbsoluteUri,
				UserId = StaticData.UserData.UserId,
			};

			var existingRegistrations = await registrationsTable
				.Where(nr => nr.ChannelUri == registration.ChannelUri || nr.UserId == registration.UserId)
				.ToListAsync();

			if(existingRegistrations.Any()) // update
			{
				registration.Id = existingRegistrations[0].Id;
				await registrationsTable.UpdateAsync(registration);

				// If there are other records, those are out of date
				for (int i = 1; i < existingRegistrations.Count; i++)
					await registrationsTable.DeleteAsync(existingRegistrations[i]);
			}
			else // insert
			{
				await registrationsTable.InsertAsync(registration);
			}

			// -- NotificationData
			await ResetNotificationData();
		}

		private static async Task ResetNotificationData()
		{
			var notificationDataTable = MobileService.GetTable<NotificationData>();
			var notificationData = await notificationDataTable
				.Where(data => data.UserId == StaticData.UserData.UserId)
				.ToListAsync();

			if (!notificationData.Any())
				await notificationDataTable.InsertAsync(new NotificationData()
				{
					UserId = StaticData.UserData.UserId,
					ActionCount = 0,
					LastActionMessage = "",
				});
			else // Clear it, the user is watching the info just now
			{
				notificationData[0].ActionCount = 0;
				notificationData[0].LastActionMessage = "";
				await notificationDataTable.UpdateAsync(notificationData[0]);
			}
		}

		public static void ShellToastNotificationReceived(object sender, NotificationEventArgs e)
		{
			Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					var msg = e.Collection.Aggregate("", (current, item) => current + (item.Value + " "));
					new ToastPrompt() { Message = msg }.Show();

					ResetNotificationData();
					ResetTile(); // There was a TileNotification as well					
				});
		}

		public static void ResetTile()
		{
			var tile = ShellTile.ActiveTiles.FirstOrDefault();
			if(tile != null)
			{
				tile.Update(new FlipTileData
				{
					Count = 0,
					BackContent = "",
					BackTitle = "",
				});
			}
		}
	}
}

/*
 * Registraion section: there is no need to check insert-or-update here.
 * This functionality is implemented in the server's insert (js) script
 * 
 			var registrationsTable = MobileService.GetTable<NotificationRegistration>();
			var registration = new NotificationRegistration
			{
				ChannelUri = CurrentChannel.ChannelUri.AbsoluteUri,
				UserId = StaticData.UserData.UserId,
			};

			var existingRegistrations = await registrationsTable
				.Where(nr => nr.ChannelUri == registration.ChannelUri)
				.ToListAsync();

			if(existingRegistrations.Any()) // update
			{
				registration.Id = existingRegistrations[0].Id;
				registrationsTable.UpdateAsync(registration);
			}
			else // insert
			{
				registrationsTable.InsertAsync(registration);
			}
 
 */

/*
 * At the server side, there is no proper inesrt-or-update... so this code is not good enough
 * 
            var registrationsTable = MobileService.GetTable<NotificationRegistration>();
			await registrationsTable.InsertAsync(new NotificationRegistration
			{
				ChannelUri = CurrentChannel.ChannelUri.AbsoluteUri,
				UserId = StaticData.UserData.UserId,
			}); // This is insert-or-update, implemented by the server side
 */

//var data = new NotificationData();
//var actionCount = e.Collection[data.Property(d => d.ActionCount)];
//var lastMessage = e.Collection[data.Property(d => d.LastActionMessage)];

//new ToastPrompt() { Message = string.Format("({0}) - {1}", actionCount, lastMessage) }.Show();
