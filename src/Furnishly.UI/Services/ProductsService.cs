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
			Count = 25;
		}
		
		private List<string> images = new List<string>
		{
			"http://furnishly.com/media/catalog/product/cache/1/small_image/55x55/9df78eab33525d08d6e5fb8d27136e95/b/o/bookshelf1_2.jpg",
			"http://furnishly.com/media/catalog/product/cache/1/small_image/55x55/9df78eab33525d08d6e5fb8d27136e95/1/6/169.JPG",
			"http://furnishly.com/media/catalog/product/cache/1/small_image/55x55/9df78eab33525d08d6e5fb8d27136e95/c/h/chair1_10.jpeg",
			"http://furnishly.com/media/catalog/product/cache/1/small_image/55x55/9df78eab33525d08d6e5fb8d27136e95/l/i/lia_endtable_3.jpg",
			
		};
		
		public int Count { get; set; }
		
		public IEnumerable<Product> GetProductsNear(CLLocationCoordinate2D location)
		{
			foreach (var i in Enumerable.Range(0,Count)) {
				var randomLocation = Locator.GetLocationNear(location, 0.002);
				yield return new Product 
								{
									Title = "Product {0}".FormatWith(i),
									Price = "${0}00".FormatWith(i),
									IconImageUri = SelectRandomImage(),
									Location = randomLocation
								};
			}
		}
		
		private string SelectRandomImage()
		{
			var index = Locator.random.Next(0, images.Count);
			return images[index];
		}
	}
	
	public class Locator
    {
        public static Random random = new Random();
       
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

