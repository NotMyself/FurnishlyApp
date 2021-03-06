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
	
	public partial class ProductsMapScreen : UIViewController
	{
		Position position;
		IEnumerable<Product> products;
		
		public ProductsMapScreen(Position position, IEnumerable<Product> products) : base("ProductsMapScreen", null)
		{
			this.position = position;
			this.products = products;
			TabBarItem = new UITabBarItem 
			{ 
				Title = "Map", 
				Image = UIImage.FromFile("Images/globe_64.png")
			};
		}
		
		public override void ViewDidLoad()
		{
			this.mapView.GetViewForAnnotation += GetViewForAnnotation;
			this.mapView.CalloutAccessoryControlTapped += ViewSelectedProduct;
			base.ViewDidLoad();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			SetVisibleRegion();
			AnnotateUsersCurrentLocation();
			AnnotateProductsNearBy();
			
			base.ViewWillAppear(animated);
		}
				
		private void SetVisibleRegion()
		{
			var coordinate = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
			var span = new MKCoordinateSpan(0.1,0.1);
			var region = new MKCoordinateRegion(coordinate,span);
			
			this.mapView.SetRegion(region, true);
		}
		
		private void AnnotateUsersCurrentLocation()
		{
			var coordinate = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
			this.mapView.AddAnnotation(new UserAnnotation(coordinate));
		}
		
		private void AnnotateProductsNearBy()
		{
			foreach (var product in products) 
				this.mapView.AddAnnotation(new ProductAnnotation(product));	
			
		}

		void ViewSelectedProduct(object sender, MKMapViewAccessoryTappedEventArgs e)
		{
			var annotation = e.View.Annotation as ProductAnnotation;
			var product = annotation.Product;
			
			var productScreen = new ProductScreen(product);
				this.NavigationController.PushViewController(productScreen, true);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		private MKAnnotationView GetViewForAnnotation(MKMapView mapView, NSObject annotation)
		{
			if(annotation is UserAnnotation)
				return getViewForUserAnnotation(mapView, annotation as UserAnnotation);
			else
				return getViewForProductAnnotation(mapView, annotation as ProductAnnotation);
		}
			
		private MKAnnotationView getViewForUserAnnotation(MKMapView mapView, UserAnnotation annotation)
		{
			var annotationId = "userAnnotation";
			return getAvaiableAnnotationView(annotationId, MKPinAnnotationColor.Green, annotation);
            
		}
		
		private MKAnnotationView getViewForProductAnnotation(MKMapView mapView, ProductAnnotation annotation)
		{
			var annotationId = "ProductAnnotation";
			var annotationView = getAvaiableAnnotationView(annotationId,MKPinAnnotationColor.Red, annotation);
			if(!string.IsNullOrWhiteSpace(annotation.Product.IconImageUri))
				annotationView.LeftCalloutAccessoryView = new UIWebImageView(annotationView.Frame, annotation.Product.IconImageUri);
            annotationView.RightCalloutAccessoryView = UIButton.FromType(UIButtonType.DetailDisclosure);
			
			return annotationView;
		}
		
		private MKAnnotationView getAvaiableAnnotationView(string annotationId, MKPinAnnotationColor penColor, NSObject annotation)
		{
			var annotationView = mapView.DequeueReusableAnnotation(annotationId) as MKPinAnnotationView;
            if (annotationView == null)
                annotationView = new MKPinAnnotationView(annotation, annotationId);
            
            annotationView.PinColor = penColor;
            annotationView.CanShowCallout = true;
            annotationView.Draggable = true;
			
			return annotationView;
		}
	}
}

