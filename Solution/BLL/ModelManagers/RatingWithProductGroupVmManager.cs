using System;
using BLL.ModelManagers.ProductModelManagers;
using CommonModels.Models;
using CommonModels.Models.EntityFramework;
using CommonModels.Models.ProductModels;
using CommonPortable.Models.ProductModels;

namespace BLL.ModelManagers
{
	public static class RatingWithProductGroupVmManager
	{
		public static RatingWithProductGroupVM DoConsturctorWork(this RatingWithProductGroupVM instance, Rating rating)
		{
			if(instance == null)
				instance = new RatingWithProductGroupVM();
				
			instance.Rating = new RatingWithProductGroupVM.RatingVM().DoConsturctorWork(rating);
			instance.Product = new InBookBlockPVM().DoConsturctorWork(null, rating.ProductGroup);

			return instance;
		}
		
		public static RatingWithProductGroupVM.RatingVM DoConsturctorWork(this RatingWithProductGroupVM.RatingVM instance, Rating rating)
		{
			if(instance == null)
				instance = new RatingWithProductGroupVM.RatingVM();

			instance.Value = rating.Value;
			instance.Date = rating.Date;

			return instance;
		}
	}
}
