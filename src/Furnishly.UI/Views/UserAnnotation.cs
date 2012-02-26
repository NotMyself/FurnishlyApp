using System;

using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class UserAnnotation: MKAnnotation
	{
		private CLLocationCoordinate2D coordinate;
		public UserAnnotation(CLLocationCoordinate2D coordinate)
		{
			this.coordinate = coordinate;
		}
		
		public override CLLocationCoordinate2D Coordinate 
		{
			get { return coordinate; }
			set { coordinate = value;}
		}
		
		public override string Title {
			get { return "You are here!";}
		}
	}
}

