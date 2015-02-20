using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WinPhoneClientProxy.CategoryManagerService;
using WindowsPhone.Common;
using WinPhoneClientProxy.ProductGroupManagerService;
using Microsoft.Phone.Controls;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;
using BookBlockPLVM = WinPhoneClientProxy.ProductManagerService.BookBlockPLVM;
using Ps = WinPhoneClientProxy.ProductManagerService;

namespace WindowsPhone.ViewModels
{
	public class ProductGroupDetailsVM : NotifyPropertyChanged
	{
		#region Data

		public bool IsDataLoaded { get; private set; }
		private BookRowPLVM _data;

		public BookRowPLVM Data
		{
			get { return _data; }
			set
			{
				if(Equals(value, _data))
					return;
				_data = value;
				OnPropertyChanged();
			}
		}

		#endregion

		public void LoadData(string friendlyUrl)
		{
			if(IsDataLoaded)
				return;

			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					Data = Services.ProductGroupManager.EndGetFullDetailed(ar);
				});

			Services.ProductGroupManager.BeginGetFullDetailed(friendlyUrl, 1, 100, callback, null);
			IsDataLoaded = true;
		}
	}
}
