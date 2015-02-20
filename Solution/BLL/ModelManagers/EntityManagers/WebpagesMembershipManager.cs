using System;
using System.Data;
using AutoMapper;
using CommonModels.Models.EntityFramework;
using CommonPortable.Enums;
using CommonPortable.Exceptions;
using DAL.EntityFramework;
using UtilsLocal;

namespace BLL.EntityManagers
{
	public static class WebpagesMembershipManager
	{
		#region CREATE

		#region Add

		public static void Add(DBEntities ctx, webpages_Membership webpagesMembership)
		{
			try
			{
				ctx.webpages_Membership.Add(webpagesMembership);
				ctx.SaveChanges();
			}
			catch(Exception e)
			{
				ctx.Entry(webpagesMembership).State = EntityState.Detached;
				var msg = string.Format("Nem sikerült beszúrni a rekordot a webpages_Membership táblába. UserID: {0}. ", webpagesMembership.UserId);
				throw new BookteraException(msg, e, BookteraExceptionCode.AddWebpagesMembership_InsertFailed);
			}
		}

		#endregion

		#endregion


		#region OTHERS

		#region CopyFromProxy

		public static webpages_Membership CopyFromProxy(webpages_Membership webpagesMembership)
		{
			bool wasNew;
			AutoMapperInitializer<webpages_Membership, webpages_Membership>
				.InitializeIfNeeded(out wasNew, sourceProxy: webpagesMembership);
			return Mapper.Map<webpages_Membership>(webpagesMembership);
		}

		#endregion
		
		#endregion
	}
}
