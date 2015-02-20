using System.ComponentModel.DataAnnotations;


namespace CommonModels.Models.EntityFramework
{
	[MetadataType(typeof(HighlightTypeValidation))]
	public partial class HighlightType{}

	public class HighlightTypeValidation
	{
		#region Not visible

		public int ID { get; set; }
		public int Price { get; set; }
		public string Description { get; set; }

		#endregion
	}
}
