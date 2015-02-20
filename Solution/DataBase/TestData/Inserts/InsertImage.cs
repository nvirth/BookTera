using System.Collections.Generic;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;

namespace ebookTestData.Inserts
{
	class InsertImage : Insert
	{
		private List<Image> images;

		protected sealed override void Start()
		{
			//images = new List<Image>(Get.GetResources.GetImageRows());
		}

		protected  void ExecuteInDB()
		{
			using(var ctx = new DBEntities())
			{
				foreach (var image in images)
				{
					ctx.Image.Add(image);
				}
				ctx.SaveChanges();
			}
		}
	}
}
