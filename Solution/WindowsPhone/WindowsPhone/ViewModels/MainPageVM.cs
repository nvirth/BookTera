using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WindowsPhone.Common;
using WindowsPhone.Common.BackgroundAgent;
using WinPhoneClientProxy.ProductManagerService;
using TileUpdaterAgent;
using WinPhoneClientProxy.WcfProxy;
using WinPhoneCommon;

namespace WindowsPhone.ViewModels
{
	public class MainPageVM : NotifyPropertyChanged
	{
		#region Properties

		#region MainHighlightedProducts

		public bool AreMainHighlightedsLoaded { get; private set; }
		private BookBlockPLVM _mainHighlightedProducts;

		public BookBlockPLVM MainHighlightedProducts
		{
			get { return _mainHighlightedProducts; }
			set
			{
				if(Equals(value, _mainHighlightedProducts))
					return;
				_mainHighlightedProducts = value;
				OnPropertyChanged();
			}
		}

		#endregion

		#region NewestProducts

		public bool AreNewestsLoaded { get; private set; }
		private BookBlockPLVM _newestProducts;

		public BookBlockPLVM NewestProducts
		{
			get { return _newestProducts; }
			set
			{
				if(Equals(value, _newestProducts))
					return;
				_newestProducts = value;
				OnPropertyChanged();
			}
		}

		#endregion

		private bool _isDebug = false;

		#endregion

		public MainPageVM()
		{
			SetDebugModeIf();
			LoadData();
		}

		private void SetDebugModeIf()
		{
#if DEBUG
			_isDebug = true;
#endif
		}

		public void LoadData()
		{
			LoadMainHighlighteds();
			LoadNewests();
		}

		private void LoadMainHighlighteds()
		{
			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					try
					{
						MainHighlightedProducts = Services.ProductManager.EndGetMainHighlighteds(ar);
					}
					catch(Exception e)
					{
						LoadMainHighlighteds_Catch(e);
					}
				});

			try
			{
				Services.ProductManager.BeginGetMainHighlighteds(1, 8, callback, null);
				AreMainHighlightedsLoaded = true;
			}
			catch(Exception e)
			{
				LoadMainHighlighteds_Catch(e);
			}
		}

		private void LoadNewests()
		{
			AsyncCallback callback = ar => Deployment.Current.Dispatcher.BeginInvoke(
				() =>
				{
					try
					{
						NewestProducts = Services.ProductManager.EndGetNewests(ar);
					}
					catch(Exception e)
					{
						LoadNewests_Catch(e);
					}
				});

			try
			{
				Services.ProductManager.BeginGetNewests(2, 8, 16, callback, null);
				AreNewestsLoaded = true;
			}
			catch(Exception e)
			{
				LoadNewests_Catch(e);
			}
		}

		private void LoadMainHighlighteds_Catch(Exception e)
		{
			AreMainHighlightedsLoaded = false;

			if(!_isDebug)
				throw e;
			else
			{
				var sampleData = new SampleData.MainHighlightedProductsSD().MainHighlightedProducts;
				MainHighlightedProducts = sampleData;
			}
		}
		private void LoadNewests_Catch(Exception e)
		{
			AreNewestsLoaded = false;

			if(!_isDebug)
				throw e;
			else
			{
				var sampleData = new SampleData.MainHighlightedProductsSD().MainHighlightedProducts;
				NewestProducts = sampleData;
			}
		}
	}
}
