using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace BLL.ModelManagers
{
	public static class CommentWithProductGroupVmManager
	{

		public static CommentWithProductGroupVM DoConsturctorWork(this CommentWithProductGroupVM instance, Comment comment)
		{
			if(instance == null)
				instance = new CommentWithProductGroupVM();

			instance.Comment = new CommentWithProductGroupVM.CommentVM().DoConsturctorWork(comment);
			instance.Product = new InBookBlockPVM().DoConsturctorWork(null, comment.ProductGroup);

			return instance;
		}

		public static CommentWithProductGroupVM.CommentVM DoConsturctorWork(this CommentWithProductGroupVM.CommentVM instance, Comment comment)
		{
			if(instance == null)
				instance = new CommentWithProductGroupVM.CommentVM();

			instance.CreatedDate = comment.CreatedDate;
			instance.Text = comment.Text;

			return instance;
		}
	}
}
