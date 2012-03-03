using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class Product
	{
		public Product()
		{
			Images = Enumerable.Empty<string>();
		}
		
		public string Id { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }		
		public string Url { get; set; }
		public string IconImageUri { get; set; }
		public IEnumerable<string> Images {get; set;}
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public CLLocationCoordinate2D Location 
		{ 
			get{ return new CLLocationCoordinate2D(this.Latitude, this.Longitude);} 
		}
	}
}

