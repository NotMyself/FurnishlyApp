using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public partial class ProductsMapScreen : UIViewController
	{
		public ProductsMapScreen() : base("ProductsMapScreen", null)
		{
			TabBarItem = new UITabBarItem 
			{ 
				Title = "Map", 
				Image = UIImage.FromFile("Images/tabmap.png")
			};
		}
		
		public Func<MKCoordinateRegion> GetVisibleRegion;
		
		
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.mapView.SetRegion(GetVisibleRegion(), true);
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

