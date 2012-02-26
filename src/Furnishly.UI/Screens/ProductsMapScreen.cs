using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	
	public partial class ProductsMapScreen : UIViewController
	{
		public Func<CLLocationCoordinate2D> GetCurrentLocation;
		public Func<IEnumerable<Product>> GetProducts;
		
		public ProductsMapScreen() : base("ProductsMapScreen", null)
		{
			TabBarItem = new UITabBarItem 
			{ 
				Title = "Map", 
				Image = UIImage.FromFile("Images/globe_64.png")
			};
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.mapView.GetViewForAnnotation += GetViewForAnnotation;
			this.mapView.CalloutAccessoryControlTapped += ViewSelectedProduct;
			SetVisibleRegion();
			AnnotateUsersCurrentLocation();
			AnnotateProductsNearBy();
		}

		void ViewSelectedProduct(object sender, MKMapViewAccessoryTappedEventArgs e)
		{
			var annotation = e.View.Annotation as ProductAnnotation;
			var product = annotation.Product;
			
			var productScreen = new ProductScreen { Product = product };
				this.NavigationController.PushViewController(productScreen, true);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		private void AnnotateUsersCurrentLocation()
		{
			var location = GetCurrentLocation();
			this.mapView.AddAnnotation(new UserAnnotation(location));
		}
		
		private void AnnotateProductsNearBy()
		{
			var products = GetProducts();
			
			foreach (var product in products) 
				this.mapView.AddAnnotation(new ProductAnnotation(product));	
			
		}
		
		private void SetVisibleRegion()
		{
			this.mapView.SetRegion(GetVisibleRegion(), true);
		}	
		
		private MKCoordinateRegion GetVisibleRegion()
		{
			var currentLocation = GetCurrentLocation();
			var span = new MKCoordinateSpan(0.02,0.02);
			var region = new MKCoordinateRegion(currentLocation,span);
			
			return region;
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

