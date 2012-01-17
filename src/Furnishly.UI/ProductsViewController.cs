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
			var visibleRegion = BuildVisibleRegion(currentLocation);
			
			mapView = BuildMapView(true);
			mapView.SetRegion(visibleRegion, true);
			
			this.View.AddSubview(mapView);
		}
		
		private MKMapView BuildMapView(bool showUserLocation)
		{
			var view = new MKMapView()
			{
				ShowsUserLocation = showUserLocation
			};
			
			view.SizeToFit();
			view.Frame = new RectangleF(0, 0, this.View.Frame.Width, this.View.Frame.Height);
			return view;
		}
		
		private MKCoordinateRegion BuildVisibleRegion(CLLocationCoordinate2D currentLocation)
		{
			var span = new MKCoordinateSpan(0.2,0.2);
			var region = new MKCoordinateRegion(currentLocation,span);
			
			return region;
		}
	}
}

