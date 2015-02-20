using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using log4net;
using UtilsLocal.Log;
using UtilsLocal.WCF;
using WcfInterfaces;
using WcfInterfaces.Authentication;
using WcfInterfaces.EntityManagers;

namespace WEB.Controllers.Base
{
	public class BookteraControllerBase : AsyncController
	{
		#region WCF

		public static IBookteraAuthenticationService AuthenticationManager { get; set; }

		public static IAuthorManager AuthorManager { get; set; }
		public static ICategoryManager CategoryManager { get; set; }
		public static ICommentManager CommentManager { get; set; }
		public static IImageManager ImageManager { get; set; }
		public static IProductGroupManager ProductGroupManager { get; set; }
		public static IProductManager ProductManager { get; set; }
		public static IPublisherManager PublisherManager { get; set; }
		public static IRatingManager RatingManager { get; set; }
		public static IUserAddressManager UserAddressManager { get; set; }
		public static IUserGroupManager UserGroupManager { get; set; }
		public static IUserOrderManager UserOrderManager { get; set; }
		public static IUserProfileManager UserProfileManager { get; set; }

		public static ITransactionManager TransactionManager { get; set; }
		public static IBookManager BookManager { get; set; }
		public static IRegistrationManager RegistrationManager { get; set; }

		// Not in use yet
		//public static IUserView UserView { get; set; }
		//public static IFeedback Feedback { get; set; }
		//public static IHighlightedProduct HighlightedProduct { get; set; }
		//public static IHighlightType HighlightType { get; set; }
		//public static IProductInOrderManager ProductInOrderManager { get; set; }

		#endregion

		public static BookteraLogger BookteraLogger { get; set; }

		static BookteraControllerBase()
		{
			BookteraLogger = new BookteraLogger("BookteraWeb");

			//SOAP
			AuthenticationManager = new ChannelFactory<IBookteraAuthenticationService>("*").CreateChannel();

			AuthorManager = new ChannelFactory<IAuthorManager>("*").CreateChannel();
			CategoryManager = new ChannelFactory<ICategoryManager>("*").CreateChannel();
			CommentManager = new ChannelFactory<ICommentManager>("*").CreateChannel();
			ImageManager = new ChannelFactory<IImageManager>("*").CreateChannel();
			ProductGroupManager = new ChannelFactory<IProductGroupManager>("*").CreateChannel();
			ProductManager = new ChannelFactory<IProductManager>("*").CreateChannel();
			PublisherManager = new ChannelFactory<IPublisherManager>("*").CreateChannel();
			RatingManager = new ChannelFactory<IRatingManager>("*").CreateChannel();
			UserAddressManager = new ChannelFactory<IUserAddressManager>("*").CreateChannel();
			UserGroupManager = new ChannelFactory<IUserGroupManager>("*").CreateChannel();
			UserOrderManager = new ChannelFactory<IUserOrderManager>("*").CreateChannel();
			UserProfileManager = new ChannelFactory<IUserProfileManager>("*").CreateChannel();

			BookManager = new ChannelFactory<IBookManager>("*").CreateChannel();
			RegistrationManager = new ChannelFactory<IRegistrationManager>("*").CreateChannel();
			TransactionManager = new ChannelFactory<ITransactionManager>("*").CreateChannel();

			//REST
			//TransactionManager = new WebChannelFactory<ITransactionManager>("*").CreateChannel();
			//BookManager = new WebChannelFactory<IBookManager>("*").CreateChannel();
			//RegistrationManager = new WebChannelFactory<IRegistrationManager>("*").CreateChannel();
			//AuthorManager = new WebChannelFactory<IAuthorManager>("*").CreateChannel();
			//CategoryManager = new WebChannelFactory<ICategoryManager>("*").CreateChannel();
			//CommentManager = new WebChannelFactory<ICommentManager>("*").CreateChannel();
			//ProductGroupManager = new WebChannelFactory<IProductGroupManager>("*").CreateChannel();
			//ProductManager = new WebChannelFactory<IProductManager>("*").CreateChannel();
			//PublisherManager = new WebChannelFactory<IPublisherManager>("*").CreateChannel();
			//RatingManager = new WebChannelFactory<IRatingManager>("*").CreateChannel();
			//UserAddressManager = new WebChannelFactory<IUserAddressManager>("*").CreateChannel();
			//UserGroupManager = new WebChannelFactory<IUserGroupManager>("*").CreateChannel();
			//UserOrderManager = new WebChannelFactory<IUserOrderManager>("*").CreateChannel();
			//UserProfileManager = new WebChannelFactory<IUserProfileManager>("*").CreateChannel();

			// Not in use yet
			//UserView = new WebChannelFactory<IUserView>("*").CreateChannel();
			//Feedback = new WebChannelFactory<IFeedback>("*").CreateChannel();
			//HighlightedProduct = new WebChannelFactory<IHighlightedProduct>("*").CreateChannel();
			//HighlightType = new WebChannelFactory<IHighlightType>("*").CreateChannel();
			//ProductInOrderManager = new WebChannelFactory<IProductInOrderManager>("*").CreateChannel();
		}

		// public BookteraControllerBase()
		// {
		// TransactionManager = new TransactionManagerClient();
		// BookManager = new BookManagerClient();
		// RegistrationManager = new RegistrationManagerClient();
		// Author = new AuthorClient();
		// Category = new CategoryClient();
		// Image = new ImageClient();
		// ProductGroup = new ProductGroupClient();
		// ProductInOrder = new ProductInOrderClient();
		// Product = new ProductClient();
		// Publisher = new PublisherClient();
		// UserAddress = new UserAddressClient();
		// UserGroup = new UserGroupClient();
		// UserOrder = new UserOrderClient();
		// UserProfile = new UserProfileClient();

		// // Not in use yet
		// //Rating = new RatingClient();
		// //UserView = new UserViewClient();
		// //Comment = new CommentClient();
		// //Feedback = new FeedbackClient();
		// //HighlightedProduct = new HighlightedProductClient();
		// //HighlightType = new HighlightTypeClient();
		// }
	}
}