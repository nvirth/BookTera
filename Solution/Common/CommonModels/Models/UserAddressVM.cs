namespace CommonModels.Models
{
	public partial class UserAddressVM
	{
		public string ZipCode { get; set; }
		public string City { get; set; }
		public string StreetAndHouseNumber { get; set; }
		public string Country { get; set; }

		public int Id { get; set; }
		public bool IsDefault { get; set; }
	}
}
