using System;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class LocationService
	{
		private CLLocationManager locationManager;
		
		public LocationService()
		{
			locationManager = new CLLocationManager();
			locationManager.StartUpdatingLocation();
		}
		
		public CLLocationCoordinate2D GetCurrentLocation()
		{
			//dirty for now just to get some info.
			locationManager.StartUpdatingLocation();
			while(locationManager.Location == null);
			var location = locationManager.Location.Coordinate;
			locationManager.StopUpdatingLocation();
			return location;
		}
	}
}

