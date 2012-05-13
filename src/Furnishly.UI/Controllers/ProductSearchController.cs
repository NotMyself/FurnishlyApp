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
		private ProductsListScreen productsListScreen;
		private ProductsMapScreen productsMapScreen;
				
		Position position;
		IEnumerable<Product> products;
		
		public ProductSearchController(Position position, IEnumerable<Product> products)
		{
			this.position = position;
			this.products = products;
		}
				
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();		
		}
		
		public override void ViewWillAppear (bool animated)
		{
			productsListScreen = new ProductsListScreen(products);
     		productsMapScreen = new ProductsMapScreen(position, products);
			this.SetViewControllers(new UIViewController[]{ productsMapScreen, productsListScreen }, false);

			base.ViewWillAppear (animated);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation == UIInterfaceOrientation.Portrait);
		}
			                               
	}
}

