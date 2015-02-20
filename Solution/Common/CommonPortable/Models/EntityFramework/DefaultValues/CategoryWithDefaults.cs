namespace CommonModels.Models.EntityFramework
{
	public partial class Category
	{
		public Category(bool withDefaults)
			: this()
		{
			if (withDefaults)
			{
				IsParent = false;
			}
		}
	}
}
