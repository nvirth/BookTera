namespace DAL.PushNotification
{
	public class NotificationRegistration
	{
		public string Id { get; set; }
		public int UserId { get; set; }
		public string ChannelUri { get; set; }
	}
}