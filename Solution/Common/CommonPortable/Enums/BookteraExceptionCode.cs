namespace CommonPortable.Enums
{
	public enum BookteraExceptionCode : byte
	{
		None,

		#region Mangers

		#region ImageManager

		AddImageDeleteIfFailed,
		AddImageDeleteIfFailed_DeleteFromDb,
		AddImageDeleteIfFailed_DeleteFromHdd,

		DeleteImageFromDisc,
		DeleteImageFromDisc_ImageForeignKeyNotExist,
		DeleteImageFromDisc_FileNotExist,

		CopyImageToItsFolder_ArgumentParseFailed,
		CopyImageToItsFolder_ArgumentWrong_ProductFriendlyUrl,

		#endregion

		#region ProductGroupManager

		UploadProductGroup,
		UploadProductGroup_ManageAuthor,
		UploadProductGroup_ManagePublisher,

		#endregion

		#region ProductManager

		UpdateProductsQuantity,
		UpdateProductsQuantity_Negative,

		SetProductToSoldOutOrBack,

		UploadProduct,

		#endregion

		#region UserAddressManager

		AddUserAddress_MakeItDefaultFailed,

		#endregion

		#region UserProfileManager

		RegisterUser,
		RegisterUser_UserIsBothAuthorAndPublisher,
		RegisterUser_SuccesfulWithSomeProblems,
		RegisterUser_ManageAuthor_UnSuccesfulRollback,
		RegisterUser_ManageAuthor_SuccesfulRollback,
		RegisterUser_ManagePublisher_UnSuccesfulRollback,
		RegisterUser_ManagePublisher_SuccesfulRollback,

		#endregion

		#region UserOrderManager (and Cart and Transactions)

		GetUserOrder_NoCart,
		GetUserOrder_AnotherUsersCart,

		GetPiosCart_PioPointsNotToCart,
		GetPiosCart_NotSelfCart,

		CreateEmtyCartForUser,

		AddProductToCart,

		UpdateProductInCart,

		RemoveProductFromCart,

		RemoveUsersCart,

		RemoveUsersAllCarts,

		DeleteUserOrdersAllProducts,
		DeleteUserOrdersAllProducts_CantDeletePios,
		DeleteUserOrdersAllProducts_CantDeleteUserOrder,

		#endregion

		#endregion

		#region CRUD-s

		AddAuthor_InsertFailed,
		GetAuthorById,
		GetAuthorByFriendlyUrl,
		UpdateAuthor,
		DeleteAuthor,

		AddCategory_InsertFailed,
		GetCategoryById,
		UpdateCategory,
		DeleteCategory,

		AddComment_InsertFailed,
		GetCommentById,
		UpdateComment,
		DeleteComment,

		AddFeedback_InsertFailed,
		GetFeedbackById,
		UpdateFeedback,
		DeleteFeedback,

		AddHighlightedProduct_InsertFailed,
		GetHighlightedProductById,
		UpdateHighlightedProduct,
		DeleteHighlightedProduct,

		AddHighlightType_InsertFailed,
		GetHighlightTypeById,
		UpdateHighlightType,
		DeleteHighlightType,

		AddImage_InsertFailed,
		GetImageById,
		UpdateImage,
		DeleteImage,

		AddProduct_InsertFailed,
		GetProductById,
		UpdateProduct,
		DeleteProduct,

		AddProductGroup_InsertFailed,
		GetProductGroupById,
		UpdateProductGroup,
		DeleteProductGroup,

		AddProductInOrder_InsertFailed,
		GetProductInOrderById,
		UpdateProductInOrder,
		DeleteProductInOrder,

		AddPublisher_InsertFailed,
		GetPublisherById,
		GetPublisherByFriendlyUrl,
		UpdatePublisher,
		DeletePublisher,

		AddRating_InsertFailed,
		GetRatingById,
		UpdateRating,
		DeleteRating,

		AddUserAddress_InsertFailed,
		GetUserAddressById,
		UpdateUserAddress,
		DeleteUserAddress,

		AddUserGroup_InsertFailed,
		GetUserGroupById,
		UpdateUserGroup,
		DeleteUserGroup,

		AddUserOrder_InsertFailed,
		GetUserOrderById,
		UpdateUserOrder,
		DeleteUserOrder,

		AddUserProfile_InsertFailed,
		GetUserProfileById,
		UpdateUserProfile,
		DeleteUserProfile,

		AddUserView_InsertFailed,
		GetUserViewById,
		UpdateUserView,
		DeleteUserView,

		#endregion

		// Még kategorizálatlanok

		LevelUpUser,
		CheckExistEnoughToBuy_NotEnoughProducts,
		UpdateSellBuyCache,
		GetProductInOrderItem,
		UpdateProductInCart_NewQuantityNegative,
		UpdateProductInCart_NoUpdateNeeded,
		AddProductToCart_CreateOrUpdatePio_DownloadableProduct,
		InBookBlockPVM_CtorArgumentWrong,
		BookBlockPLVM_CtorArgumentWrong,
		GetCategoryByFriendlyUrl,
		AddUserProfile,
		AddWebpagesMembership_InsertFailed,
		ImageFileExtensionWrong,
		GetProductGroupByFriendlyUrl,
		UpdateUsersAmount,
		UpdateUserAddress_NotOwnAddress,
		DeleteUserAddress_NotOwnAddress,
		AddProductToCart_OwnProductToOwnCart,
		GetUserProfileByFriendlyUrl,
		GetUsersCartsOrEarlierOrders_ArgumentWrong,
		SendUserOrder,
		SendEmail,
		SendUserOrder_NoAddress,
		GetUserOrderItem_WrongStatus,
		GetUserOrder_WrongUser,
		AddExchangeProductsToOrder_CheckProduct,
		FinalizeOrder,
		CloseOrder,
		SendExchangeOffer,
		AddExchangeProductsToOrder,
		GiveFeedback,
		IncrementSumOfBuys,
		UpdateProductGroupAfterwards,
		UpdateUsersOrdersFeeCache,
		GetUserOrder_NoExchangeProducts,
		GetCartUserOrderItem_ArgumentWrong,
		GetBuyedExchangeOfferedUserOrderItem_ArgumentWrong,
		GetBuyedWaitingUserOrderItem_ArgumentWrong,
		GetFinalizedUserOrderItem_ArgumentWrong,
		GetExchangeCartUserOrderItem_ArgumentWrong,
		RemoveExchangeProduct,
		RemoveExchangeCart,
		DeleteExchangeProducts,
		AddExchangeProductToOrder,
		ManageProductByUpdate_NoUpdateNeeded,
		AddExchangeProduct,
		UpdateExchangeProduct,
		UpdateExchangeProduct_NewQuantityNegative,
		UpdateExchangeProduct_NoUpdateNeeded,
		UploadProductGroup_ManageAuthor_NoAuthors,
		UpdateUserOrdersAddress,
		UpdateUserOrdersAddress_NoRights,
		GetUserOrder_CustomerHasNoAddress,
		GetUserOrder_VendorHasNoAddress
	}
}
