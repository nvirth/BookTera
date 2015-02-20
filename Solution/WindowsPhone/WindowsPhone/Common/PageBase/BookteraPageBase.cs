using System.Threading;
using System.Threading.Tasks;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WindowsPhone.Common.PageBase
{
	public class BookteraPageBase : PhoneApplicationPage
	{
		protected override void OnOrientationChanged(OrientationChangedEventArgs e)
		{
			base.OnOrientationChanged(e);

			// This did not work. There is an error in the Framework: if the Orientation is
			//  Landscape, the AppBarMenu appears; independently from the settings in code.
			//  This also means, that in Landscapr mode, when the ContextMenu of a BookBlock is opening,
			//  the minimizing will not work...
			//
			//switch(e.Orientation)
			//{
			//	case PageOrientation.Landscape:
			//	case PageOrientation.LandscapeLeft:
			//	case PageOrientation.LandscapeRight:
			//		AppBarMenu.ApplicationBar.Mode = ApplicationBarMode.Minimized;
			//		break;
			//	case PageOrientation.Portrait:
			//	case PageOrientation.PortraitDown:
			//	case PageOrientation.PortraitUp:
			//		AppBarMenu.ApplicationBar.Mode = ApplicationBarMode.Default;
			//		break;
			//}
		}
	}
}
