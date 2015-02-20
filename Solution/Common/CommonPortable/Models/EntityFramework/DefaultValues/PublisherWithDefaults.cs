namespace CommonModels.Models.EntityFramework
{
	public partial class Publisher
	{
		public Publisher(bool withDefaults)
			: this()
		{
			if (withDefaults)
			{
				IsCheckedByAdmin = false;
			}
		}
	}
}
