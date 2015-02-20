namespace CommonModels.Models.EntityFramework
{
	public partial class UserAddress
	{
		public UserAddress(bool withDefaults)
			:this()
		{
			if(withDefaults)
			{
				Country = "Magyarország";
			}
		}

		public UserAddress()
		{

		}
	}
}
