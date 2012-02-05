using System;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class Product
	{
		public Product()
		{
		}
		
		public string Title { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public CLLocationCoordinate2D Location { get; set; }
	}
}

