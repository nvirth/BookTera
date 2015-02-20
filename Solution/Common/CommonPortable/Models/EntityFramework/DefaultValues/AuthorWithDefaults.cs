namespace CommonModels.Models.EntityFramework
{
	public partial class Author
	{
		public Author(bool withDefaults)
			: this()
		{
			if (withDefaults)
			{
				IsCheckedByAdmin = false;
			}
		}
	}
}
