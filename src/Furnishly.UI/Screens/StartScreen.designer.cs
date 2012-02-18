// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Furnishly.UI
{
	[Register ("StartScreen")]
	partial class StartScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLocate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel messages { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnLocate != null) {
				btnLocate.Dispose ();
				btnLocate = null;
			}

			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}

			if (messages != null) {
				messages.Dispose ();
				messages = null;
			}
		}
	}
}
