using DAL.EntityFramework;
using ebookTestData.Get;

namespace ebookTestData.Inserts
{
	class InsertCategory : Insert
	{
		protected sealed override void Start()
		{
			var categories = GetResources.GetCategoryResources();

			using (var ctx = new DBEntities())
			{
				foreach (var category in categories)
					ctx.Category.Add(category);

				ctx.SaveChanges();
			}
		}
	}
}
