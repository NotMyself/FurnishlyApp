using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

using Xamarin.Geolocation;

namespace Furnishly.UI
{
	public class ProductSearchController : UITabBarController
	{
		private ProductsService productsService;
		
		public ProductSearchController()
		{
		}
		
		public Position SearchPosition {get; set;}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if(productsService == null)
				productsService = new ProductsService();
			
			var productsListScreen = new ProductsListScreen
									{
										GetProducts = GetProducts	
									};
			var productsMapScreen = new ProductsMapScreen 
									{ 
										GetCurrentLocation = () => { return SearchPosition; },
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
				
		private IEnumerable<Product> GetProducts()
		{
			var chicago = new Position { Latitude = 41.8942, Longitude =  -87.6228};
			if(SearchPosition == null)
				return productsService.GetProductsNear(chicago);
			return productsService.GetProductsNear(SearchPosition);
		}
	}
}

