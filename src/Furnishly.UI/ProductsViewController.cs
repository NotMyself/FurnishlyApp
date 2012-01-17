using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductsViewController : UIViewController
	{
		private LocationService locationService; 
		private ProductsService productsService;
		private MKMapView mapView;
		
		public ProductsViewController(LocationService locationService, ProductsService productsService)
		{
			this.locationService = locationService;
			this.productsService = productsService;
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			var currentLocation = locationService.GetCurrentLocation();
			
			mapView = new MKMapView()
			{
				ShowsUserLocation = true
			};
			
			mapView.SizeToFit();
			mapView.Frame = new RectangleF(0, 0, this.View.Frame.Width, this.View.Frame.Height);
			MKCoordinateSpan span = new MKCoordinateSpan(0.2,0.2);
			MKCoordinateRegion region = new MKCoordinateRegion(currentLocation,span);
			mapView.SetRegion(region, true);
			
			this.View.AddSubview(mapView);
			
			
		}
	}
}

