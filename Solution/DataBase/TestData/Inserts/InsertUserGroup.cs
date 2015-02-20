using DAL.EntityFramework;
using ebookTestData.Get;

namespace ebookTestData.Inserts
{
	class InsertUserGroup : Insert
	{
		protected sealed override void Start()
		{
			var userGroups = GetResources.GetUserGroupResources();

			using(var ctx = new DBEntities())
			{
				foreach (var userGroup in userGroups)
					ctx.UserGroup.Add(userGroup);

				ctx.SaveChanges();
			}
		}
	}
}
