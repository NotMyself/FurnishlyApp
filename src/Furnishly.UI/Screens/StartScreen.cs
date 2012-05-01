using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Furnishly.UI
{
	/* StartScreen Specs
	 * when the application launches
	 * 		the start screen 
	 * 			should check if geolocation services are enabled
	 * 				if they are not, display a message and end
	 * 			should check if there is a network connection available
	 * 				if no network, display a message and end
	 * 			should fetch the users current location
	 * 				when current location recieved store and enable button
	 * 				if error display message and end
	 * 
	 * */
	public partial class StartScreen : UIViewController
	{
		public StartScreen() : base("StartScreen", null)
		{
			
		}
		
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//this.btnLocate.Alpha = 0;
			//this.activityIndicator.Alpha = 0;
			this.messages.Alpha = 0;
			
			this.activityIndicator.StartAnimating();
			
			this.btnLocate.TouchUpInside += (sender, e) => {
				var productSearchController = new ProductSearchController();
				this.NavigationController.PushViewController(productSearchController, true);
			};
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.NavigationController.SetNavigationBarHidden(true, animated);
		}
		
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			this.NavigationController.SetNavigationBarHidden(false, animated);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

