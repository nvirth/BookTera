using DAL.EntityFramework;
using ebookTestData.Get;

namespace ebookTestData.Inserts
{
	class InsertHighlightedType : Insert
	{
		protected sealed override void Start()
		{
			var highlightedTypes = GetResources.GetHighlightTypeResources();

			using (var ctx = new DBEntities())
			{
				foreach (var highlightType in highlightedTypes)
					ctx.HighlightType.Add(highlightType);

				ctx.SaveChanges();
			}
		}
	}
}
