using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CommonModels.Models.EntityFramework;
using UtilsLocal;

namespace CommonModels.Models
{
	[MetadataType(typeof (UserGroupDisplayNames))]
	public partial class UserGroupAnnotated : UserGroup
	{
		private UserGroup _core;

		public UserGroupAnnotated(UserGroup core)
		{
			_core = core;
		}

		#region Delegating members

		public int ID
		{
			get { return _core.ID; }
			set { _core.ID = value; }
		}

		public int Price
		{
			get { return _core.Price; }
			set { _core.Price = value; }
		}

		public byte BuyFeePercent
		{
			get { return _core.BuyFeePercent; }
			set { _core.BuyFeePercent = value; }
		}

		public byte SellFeePercent
		{
			get { return _core.SellFeePercent; }
			set { _core.SellFeePercent = value; }
		}

		public byte MonthsToKeepBooks
		{
			get { return _core.MonthsToKeepBooks; }
			set { _core.MonthsToKeepBooks = value; }
		}

		public string GroupName
		{
			get { return _core.GroupName; }
			set { _core.GroupName = value; }
		}

		public ICollection<UserProfile> UserProfiles
		{
			get { return _core.UserProfiles; }
			set { _core.UserProfiles = value; }
		}

		#endregion
	}

	public class UserGroupDisplayNames
	{
		#region Visible

		[Display(Name = "Név")]
		public string GroupName { get; set; }

		[Display(Name = "Ár")]
		public int Price { get; set; }

		[Display(Name = "Hónap")]
		public byte MonthsToKeepBooks { get; set; }

		[Display(Name = "Vásárlási jutalék")]
		public byte BuyFeePercent { get; set; }

		[Display(Name = "Eladási jutalék")]
		public byte SellFeePercent { get; set; }

		#endregion
		#region Not visible

		public int ID { get; set; }

		#endregion
	}
}