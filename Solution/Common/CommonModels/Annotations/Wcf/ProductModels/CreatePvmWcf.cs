using System.Runtime.Serialization;

namespace CommonModels.Models.ProductModels
{
	public partial class CreatePVM
	{
		[KnownType(typeof(WithValidation))]
		public partial class ProductGroupVM { }
	}
}
