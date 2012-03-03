using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductSearchController : UITabBarController
	{
		private LocationService locationService;
		private ProductsService productsService;
		
		public ProductSearchController()
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if(locationService == null)
				locationService = new LocationService();
		
			if(productsService == null)
				productsService = new ProductsService();
			
			var productsListScreen = new ProductsListScreen
									{
										GetProducts = GetProducts	
									};
			var productsMapScreen = new ProductsMapScreen 
									{ 
										GetCurrentLocation = GetCurrentLocation,
										GetProducts = GetProducts
									};
			
			this.SetViewControllers(new UIViewController[]{ productsMapScreen, productsListScreen }, false);
		}
		
//		public override void ViewWillAppear(bool animated)
//		{
//			base.ViewWillAppear(animated);
//			this.NavigationController.SetNavigationBarHidden(true, animated);
//		}
//		
//		public override void ViewWillDisappear(bool animated)
//		{
//			base.ViewWillDisappear(animated);
//			this.NavigationController.SetNavigationBarHidden(false, animated);
//		}
		
		private CLLocationCoordinate2D GetCurrentLocation()
		{
			return locationService.GetCurrentLocation();
		}
		
		private IEnumerable<Product> GetProducts()
		{
			var location = locationService.GetCurrentLocation();
			return productsService.GetProductsNear(location);
		}
	}
}

