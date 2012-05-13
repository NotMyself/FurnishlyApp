using System;
using System.Linq;
using System.Collections.Generic;
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
		private ProductSearchController productSearchController;
		private ProductsService productsService;
		
		private Position currentPosition;
		private IEnumerable<Product> products;
		
		public StartScreen() : base("StartScreen", null)
		{
			this.geolocator = new Geolocator { DesiredAccuracy = 50 };
			this.productsService = new ProductsService();
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
		
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.activityIndicator.StartAnimating();
			startCurrentLocation();
			
			this.btnLocate.TouchUpInside += (sender, e) => {
				startGetProducts();
			};
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
		
		private void ShowProducts()
		{
			var thisPosition = currentPosition;
			var thisProducts = products.ToList();
			this.productSearchController = new ProductSearchController(thisPosition, thisProducts);
			this.NavigationController.PushViewController(productSearchController, true);	
		}
				
		private void OnCurrentLocation(Task<Position> positionTask)
		{
		
			if (positionTask.IsFaulted)
				this.messages.Text = ((GeolocationException)positionTask.Exception.InnerException).Error.ToString();
			else
			{
				//this.messages.Alpha = 0;
				//this.activityIndicator.Alpha = 0;
				this.btnLocate.Alpha = 1;
				currentPosition = new Position { Latitude = 41.8942, Longitude =  -87.6228};
					//positionTask.Result;
			}
			Activity.PopNetworkActive();

		}
		
		private void startCurrentLocation()
		{
			Activity.PushNetworkActive();
			var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
			this.messages.Text = "Getting current location...";
			this.geolocator.GetPositionAsync(timeout: 10000)
				.ContinueWith(OnCurrentLocation, scheduler);
		}
			
		
		
		private IEnumerable<Product> GetProducts(Position postion)
		{
			var chicago = new Position { Latitude = 41.8942, Longitude =  -87.6228};
				return productsService.GetProductsNear(chicago);
			//return productsService.GetProductsNear(SearchPosition);
		}
		
		private void startGetProducts()
		{
			Activity.PushNetworkActive();
			var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
			this.messages.Text = "Getting products near you...";
			Task.Factory.StartNew(() => GetProducts(currentPosition))
						.ContinueWith(OnProducts, scheduler);
		}
		
		private void OnProducts(Task<IEnumerable<Product>> productsTask)
		{
			if(productsTask.IsFaulted)
				this.messages.Text = ((Exception)productsTask.Exception.InnerException).Message;
			else 
			{
				InvokeOnMainThread(() => {
					this.products = productsTask.Result;
					ShowProducts();
				});
			}
			Activity.PopNetworkActive();
		}
	}
}

