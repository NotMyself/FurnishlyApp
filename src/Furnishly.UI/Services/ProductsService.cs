using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductsService
	{
		public ProductsService()
		{
			Count = 1000;
		}
		
		public int Count { get; set; }
		
		public IEnumerable<Product> GetProductsNear(CLLocationCoordinate2D location)
		{
			foreach (var i in Enumerable.Range(0,Count)) {
				var randomLocation = Locator.GetLocationNear(location, 0.002);
				yield return new Product 
								{
									Title = "Product {0}".FormatWith(i),
									Price = "${0}00".FormatWith(i),
									Location = randomLocation
								};
			}
		}
	}
	
	public class Locator
    {
        static Random random = new Random();
       
        public static CLLocationCoordinate2D GetLocationNear(CLLocationCoordinate2D location, double radius = 1.0)
        {
			var x = location.Latitude;
			var y = location.Longitude;
            var dx = random.NextDouble() * RandomNegativeMultiplier;
			dx = radius / dx;
            var dy = Math.Sqrt(Math.Abs(Math.Pow(radius, 2) - Math.Pow(dx, 2))) * RandomNegativeMultiplier;
			Console.WriteLine("{0} {1}".FormatWith(x+dx,y+dy));
            return new CLLocationCoordinate2D( x+dx, y+dy );
        }

        private static int RandomNegativeMultiplier
        {
            get { return ( ( (int) random.Next() ) % 2 == 0 ? -1 : 1 ); }
        }
    }
}

