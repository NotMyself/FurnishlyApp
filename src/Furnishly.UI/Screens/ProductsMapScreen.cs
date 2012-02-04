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
		private MapDelegate mapDelegate;
		
		public ProductsMapScreen() : base("ProductsMapScreen", null)
		{
			TabBarItem = new UITabBarItem 
			{ 
				Title = "Map", 
				Image = UIImage.FromFile("Images/tabmap.png")
			};
		}
		
		public Func<CLLocationCoordinate2D> GetCurrentLocation;
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//this.mapDelegate = new MapDelegate();
			//this.mapView.Delegate = this.mapDelegate;
			
			SetVisibleRegion();
			AnnotateUsersCurrentLocation();
		
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			ReleaseDesignerOutlets();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		private void AnnotateUsersCurrentLocation()
		{
			var location = GetCurrentLocation();
			this.mapView.AddAnnotation(new[]{ new UserAnnotation(location) });
		}
		
		private void SetVisibleRegion()
		{
			this.mapView.SetRegion(GetVisibleRegion(), true);
		}	
		
		private MKCoordinateRegion GetVisibleRegion()
		{
			var currentLocation = GetCurrentLocation();
			var span = new MKCoordinateSpan(0.2,0.2);
			var region = new MKCoordinateRegion(currentLocation,span);
			
			return region;
		}
		
		public class MapDelegate : MKMapViewDelegate 
		{
			public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, NSObject annotation)
			{
				var userAnnotation = annotation as UserAnnotation;
				if(userAnnotation != null)
					return getViewForUserAnnotation(mapView, userAnnotation);
				
				throw new Exception();
			}
			
			private MKAnnotationView getViewForUserAnnotation(MKMapView mapView, UserAnnotation annotation)
			{
				var annotationId = "userAnnotation";
				var annotationView = mapView.DequeueReusableAnnotation (annotationId) as MKPinAnnotationView;
                if (annotationView == null)
                    annotationView = new MKPinAnnotationView (annotation, annotationId);
                
                annotationView.PinColor = MKPinAnnotationColor.Green;
                annotationView.CanShowCallout = true;
                annotationView.Draggable = true;
                annotationView.RightCalloutAccessoryView = UIButton.FromType (UIButtonType.DetailDisclosure);
				
				return annotationView;
                
			}
		}
	}
}

