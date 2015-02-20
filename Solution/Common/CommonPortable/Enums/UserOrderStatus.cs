namespace CommonPortable.Enums
{
	public enum UserOrderStatus : byte
	{
		Nincs = 0,

		// -- Cart
		Cart = 1,

		// -- InProgress
		BuyedWaiting = 10,
		BuyedExchangeOffered = 11,
		FinalizedExchange = 20,
		FinalizedCash = 21,

		// -- Finished
		Finished = 30,

		// -- Not exist in DB
		CartDeleting = 100,
	}

	public static partial class Helpers
	{
		public static string ToDescriptionString(this UserOrderStatus userOrderStatus)
		{
			switch(userOrderStatus)
			{
				// Normal
				case UserOrderStatus.Cart:
					return "Kosárban";
				case UserOrderStatus.BuyedWaiting:
					return "Válaszra vár";
				case UserOrderStatus.BuyedExchangeOffered:
					return "Csere ajánlva";
				case UserOrderStatus.FinalizedExchange:
					return "Véglegesített tranzakció cserével";
				case UserOrderStatus.FinalizedCash:
					return "Véglegesített tranzakció fizetéssel";
				case UserOrderStatus.Finished:
					return "Befejezett tranzakció";

				// Not exist in DB
				case UserOrderStatus.CartDeleting:
					return "Kosár törlés alatt";

				default:
					return userOrderStatus.ToString();
			}
		}
	}
}