using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.SystemConfiguration;

using Xamarin.Geolocation;

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
		private Geolocator geolocator;
		private TaskScheduler scheduler;
		private ProductSearchController productSearchController;
		
		public StartScreen() : base("StartScreen", null)
		{
			this.geolocator = new Geolocator { DesiredAccuracy = 50 };
			this.scheduler = TaskScheduler.FromCurrentSynchronizationContext();
			this.productSearchController = new ProductSearchController();
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
			Activity.PushNetworkActive();
			if(checkIfGeolocationIsEnabled())
			{
				if(checkIfNetworkIsAvailable()) 
				{
					startCurrentLocation();
					
					this.btnLocate.TouchUpInside += (sender, e) => {
						this.NavigationController.PushViewController(productSearchController, true);
					};
				}
			}
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets();
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
		
		private bool checkIfGeolocationIsEnabled()
		{
			this.messages.Text = "Checking for geolocation services...";
			if(!this.geolocator.IsGeolocationEnabled)
			{
				this.messages.Text = "Geolocation services are disabled.";
				return false;
			}
			
			return true;
		}
		
		private bool checkIfNetworkIsAvailable()
		{
			this.messages.Text = "Checking for network access...";
			if(Reachability.RemoteHostStatus() == NetworkStatus.NotReachable)
			{
				this.messages.Text = "No network connection found.";
				return false;
			}
			return true;
		}
		
		private void startCurrentLocation()
		{
			this.messages.Text = "Getting current location...";
			
			this.geolocator.GetPositionAsync(timeout: 10000)
				.ContinueWith(t =>
				{
					if (t.IsFaulted)
						this.messages.Text = ((GeolocationException)t.Exception.InnerException).Error.ToString();
					else
					{
						
						this.messages.Alpha = 0;
						this.activityIndicator.Alpha = 0;
						this.btnLocate.Alpha = 1;
					}
					Activity.PopNetworkActive();
				}, scheduler);
		}
	}
}

