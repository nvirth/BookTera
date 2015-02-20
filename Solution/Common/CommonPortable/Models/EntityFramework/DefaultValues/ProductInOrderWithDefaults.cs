namespace CommonModels.Models.EntityFramework
{
	public partial class ProductInOrder
	{
		public ProductInOrder(bool withDefaults)
			: this()
		{
			if(withDefaults)
			{
				HowMany = 1;
				IsForExchange = false;
			}
		}

		public ProductInOrder()
		{
			
		}
	}
}
