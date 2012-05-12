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
		private ProductsListScreen productsListScreen;
		private ProductsMapScreen productsMapScreen;
		
		public ProductSearchController()
		{
		}
		
		public Position SearchPosition {get; set;}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			productsService = new ProductsService();
			var products = GetProducts();
			productsListScreen = new ProductsListScreen(products);
			productsMapScreen = new ProductsMapScreen();

			this.SetViewControllers(new UIViewController[]{ productsMapScreen, productsListScreen }, false);
			
			productsMapScreen.ShowProducts(products, GetPosition());			
		}
			                               
		private Position GetPosition()
		{
			var chicago = new Position { Latitude = 41.8942, Longitude =  -87.6228};
			if(SearchPosition == null)
				return chicago;
				
			return SearchPosition;
		}
				
		private IEnumerable<Product> GetProducts()
		{
			var chicago = new Position { Latitude = 41.8942, Longitude =  -87.6228};
			if(SearchPosition == null)
				return productsService.GetProductsNear(chicago);
			return productsService.GetProductsNear(SearchPosition);
		}
	}
}

