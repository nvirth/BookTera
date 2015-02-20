using System;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using CommonModels.Models.EntityFramework;

namespace CommonModels.WcfHelperModels
{
	[MessageContract]
	public class ImageUploadStream : IDisposable
	{
		[MessageHeader(MustUnderstand = true)]
		public string FileName;

		[MessageHeader(MustUnderstand = false)]
		public UserProfile UserProfile;

		[MessageHeader(MustUnderstand = false)]
		public Product Product;

		[MessageHeader(MustUnderstand = false)]
		public ProductGroup ProductGroup;

		[MessageHeader(MustUnderstand = false)]
		public string FriendlyUrlForProduct;

		[MessageBodyMember(Order = 1)]
		public Stream Stream;

		public void Dispose()
		{
			if(Stream != null)
			{
				Stream.Close();
				Stream = null;
			}
		}
	}

	[MessageContract]
	public class StringMcWrapper
	{
		[MessageBodyMember]
		public string String;
	}
}
