using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Models.EntityFramework;
using DAL.EntityFramework;
using ebookTestData.Get;
using UtilsShared;
using GeneralFunctions = UtilsSharedPortable.GeneralFunctions;

namespace ebookTestData.Inserts
{
	class InsertComment : Insert
	{
		private List<Comment> comments;

		protected sealed override void Start()
		{
			using(var ctx = new DBEntities())
			{
				// Az elkészített kommenteket tároló lista
				comments = new List<Comment>();

				UserProfile[] userProfiles = ctx.UserProfile.ToArray();

				// A kommentekhez a hozzávalók
				string[] commentTexts = GetResources.GetComments();

				foreach (var product in ctx.Product)
				{
					// Max annyi komment lehet, ahányan megnézték (v max 5)
					int max = product.SumOfViews < 5 ? product.SumOfViews : 5;
					for (int j = 0; j < max; j++)
					{
						// Véletlenszerűnek látszik majd
						if (Random.Next(100) < 70)
						{
							// Keresünk egy usert, aki láthatta már egyáltalán a terméket
							UserProfile user;
							int idx = Random.Next(userProfiles.Length);
							int countOfCycles = 0;
							bool nobodyCanViewIt = false;
							do
							{
								user = userProfiles[idx%userProfiles.Length];
								idx++;
								countOfCycles++;
								nobodyCanViewIt = countOfCycles > userProfiles.Length;
							} while (!Util.CanUserViewProduct(user, product)
							         && !nobodyCanViewIt);

							// Ha találtunk usert, aki láthatta
							if (!nobodyCanViewIt)
							{

								string aktText = commentTexts[Random.Next(commentTexts.Length)];
								bool isDedicatory = Random.Next(100) < 15;
								DateTime createdDate = GeneralFunctions.GetRandomDateTimeBetween2mins1max(
									product.UploadedDate, user.RegistrationDate, user.LastLoginDate);

								comments.Add(new Comment(true)
								{
									//ProductID = product.ID,
									UserID = user.ID,
									Text = aktText,
									CreatedDate = createdDate,
								});
							}
						}
					}
				}
			}
		}

		protected void ExecuteInDB()
		{
			//foreach(var comment in comments)
			//{
			//	// Stored Procedure
			//	ctx.AddComment(comment.ProductID, comment.UserID, comment.Text, comment.IsDedicatory, comment.CreatedDate);
			//}
			//ctx.SaveChanges();
			throw new NotImplementedException();
		}
	}
}
