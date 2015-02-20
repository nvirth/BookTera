namespace CommonPortable.Enums
{
	public enum TransactionType : byte
	{
		CartOwn = 0,
		CartOthers = 1,
		InProgressOrderOwn = 2,
		InProgressOrderOthers = 3,
		FinishedOrderOwn = 4,
		FinishedOrderOthers = 5,
	}
}