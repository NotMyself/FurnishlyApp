using System;

using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductAnnotation : MKAnnotation
	{
		private Product product;
		
		public ProductAnnotation(Product product)
		{
			this.product = product;
		}
		
		public override CLLocationCoordinate2D Coordinate 
		{
			get { return product.Location; }
			set { product.Location = value;}
		}
		
		public override string Title 
		{
			get { return "{0} - {1}".FormatWith(product.Price, product.Title);}
		}
		
		
		public Product Product 
		{
			get { return product; }
		}
	}
}

