using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public partial class ProductsListScreen : UIViewController
	{
		public Func<IEnumerable<Product>> GetProducts;
		
		public ProductsListScreen() : base("ProductsListScreen", null)
		{
			TabBarItem = new UITabBarItem 
			{ 
				Title = "List", 
				Image = UIImage.FromFile("Images/list_64.png")
			};
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
			var products = GetProducts();
			foreach (var product in products) {
					
			}
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose(); myOutlet = null;
			
			ReleaseDesignerOutlets();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

