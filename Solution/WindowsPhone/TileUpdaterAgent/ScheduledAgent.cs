#define DEBUG_AGENT
using System;
using System.Linq;
using System.Windows;
using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Info;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using WinPhoneClientProxy.WcfProxy;

namespace TileUpdaterAgent
{
	public class ScheduledAgent : ScheduledTaskAgent
	{
		private static volatile bool _classInitialized;

		/// <remarks>
		/// ScheduledAgent constructor, initializes the UnhandledException handler
		/// </remarks>
		public ScheduledAgent()
		{
			if(!_classInitialized)
			{
				_classInitialized = true;
				// Subscribe to the managed exception handler
				Deployment.Current.Dispatcher.BeginInvoke(delegate
				{
					Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
				});
			}
		}

		/// Code to execute on Unhandled Exceptions
		private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if(System.Diagnostics.Debugger.IsAttached)
			{
				// An unhandled exception has occurred; break into the debugger
				System.Diagnostics.Debugger.Break();
			}
		}

		/// <summary>
		/// Agent that runs a scheduled task
		/// </summary>
		/// <param name="task">
		/// The invoked task
		/// </param>
		/// <remarks>
		/// This method is called when a periodic or resource intensive task is invoked
		/// </remarks>
		protected override void OnInvoke(ScheduledTask task)
		{
			AsyncCallback callback = 
				async ar =>
				{
					var mainHighlightedProducts = Services.ProductManager.EndGetMainHighlighteds(ar);
					var mainHighlightedsImageUrls = mainHighlightedProducts.Products
						.Select(pvm => pvm.Product.ImageUrl ?? pvm.ProductGroup.ImageUrl)
						.ToArray();

					await new TileManager().UpdateSecondaryTileImages(mainHighlightedsImageUrls);

					IfDebug(task);		// If debugging is enabled, launch the agent again in one minute.
					NotifyComplete();	// Call NotifyComplete to let the system know the agent is done working.
				};

			Services.ProductManager.BeginGetMainHighlighteds(1, 8, callback, new object());
		}

		private static void IfDebug(ScheduledTask task)
		{
			// If debugging is enabled, launch the agent again in one minute.
#if DEBUG_AGENT
			ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));
#endif
		}
	}
}