namespace CommonModels.Models.EntityFramework
{
	public partial class UserAddress
	{
		public UserAddress(bool withDefaults)
			:this()
		{
			if(withDefaults)
			{
				Country = "Magyarorsz�g";
			}
		}

		public UserAddress()
		{

		}
	}
}
