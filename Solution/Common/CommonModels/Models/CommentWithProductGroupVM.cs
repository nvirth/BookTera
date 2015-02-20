using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace CommonModels.Models
{
	public class CommentWithProductGroupVM
	{
		public CommentVM Comment { get; set; }
		public InBookBlockPVM Product { get; set; }

		public class CommentVM
		{
			public System.DateTime CreatedDate { get; set; }
			public string Text { get; set; }
		}
	}
}
