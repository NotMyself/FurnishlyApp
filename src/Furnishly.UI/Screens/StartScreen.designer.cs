// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Furnishly.UI
{
	[Register("StartScreen")]
	partial class StartScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnLocate { get; set; }
		
		void ReleaseDesignerOutlets()
		{
			if (btnLocate != null) {
				btnLocate.Dispose();
				btnLocate = null;
			}
		}
	}
}
