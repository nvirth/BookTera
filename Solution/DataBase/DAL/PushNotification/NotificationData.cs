namespace DAL.PushNotification
{
	public class NotificationData
	{
		public string Id { get; set; }

		public int UserId { get; set; }

		public string LastActionMessage { get; set; }

		public int ActionCount { get; set; }
	}
}