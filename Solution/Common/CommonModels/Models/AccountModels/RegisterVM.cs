namespace CommonModels.Models.AccountModels
{
	/// <summary>
	/// - UserAddress: Default cím, null, ha nincs
	/// - AuthorName: Akkor van kitöltve, ha a felhasználó egy szerző; null egyébként
	/// - PublisherName: Akkor van kitöltve, ha a felhasználó egy kiadó; null egyébként
	/// </summary>
	public partial class RegisterVM
	{
		// -- Required

		public string UserName { get; set; }
		public string EMail { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }

		// -- Not required

		public string FullName { get; set; }
		public string PhoneNumber { get; set; }
		public string ImageUrl { get; set; }
		public string AuthorName { get; set; }
		public string PublisherName { get; set; }
		public UserAddressVM UserAddress { get; set; }
	}
}
