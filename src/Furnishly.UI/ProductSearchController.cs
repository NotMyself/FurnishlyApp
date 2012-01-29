using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Furnishly.UI
{
	public class ProductSearchController : UITabBarController
	{
		public ProductSearchController()
		{
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			var productsListScreen = new ProductsListScreen();
			var productsMapScreen = new ProductsMapScreen();
			
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
	}
}

