namespace CommonModels.Models.EntityFramework
{
	public partial class Image
	{
		public Image(bool withDefaults)
			:this()
		{
			if(withDefaults)
			{
				IsDefault = false;
			}
		}

		public Image()
		{

		}
	}
}
