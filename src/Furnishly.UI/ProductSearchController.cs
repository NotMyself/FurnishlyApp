using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductSearchController : UITabBarController
	{
		private LocationService locationService;
		
		public ProductSearchController()
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if(locationService == null)
				locationService = new LocationService();
			
			var productsListScreen = new ProductsListScreen();
			var productsMapScreen = new ProductsMapScreen() 
									{ 
										GetCurrentLocation = GetCurrentLocation 
									};
			
			this.SetViewControllers(new UIViewController[]{ productsMapScreen, productsListScreen }, false);
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
		
		private CLLocationCoordinate2D GetCurrentLocation()
		{
			return locationService.GetCurrentLocation();
		}
	}
}

