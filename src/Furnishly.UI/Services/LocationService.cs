using System;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class LocationService
	{
		private static CLLocationManager locationManager;
		
		public LocationService()
		{
			locationManager = new CLLocationManager();
		}
		
		public CLLocationCoordinate2D GetCurrentLocation()
		{
			//dirty for now just to get some info.
			locationManager.StartUpdatingLocation();
			while(locationManager.Location == null);
			locationManager.StopUpdatingLocation();
			Console.WriteLine("location: {0} {1}", locationManager.Location.Coordinate.Latitude, locationManager.Location.Coordinate.Longitude);
			
			return locationManager.Location.Coordinate;
		}
	}
}

