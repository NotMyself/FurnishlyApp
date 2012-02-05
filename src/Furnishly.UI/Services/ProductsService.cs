using System;
using System.Collections.Generic;

using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public class ProductsService
	{
		public ProductsService()
		{
		}

		public IEnumerable<Product> GetProductsNear(CLLocationCoordinate2D location)
		{
			return new[] 
			{
				new Product
				{
					Title = "Foo",
					Price = "$300.00",
					Location = new CLLocationCoordinate2D(location.Latitude - 0.001, location.Longitude + 0.001)
				},
				new Product
				{
					Title = "Bar",
					Price = "$300.00",
					Location = new CLLocationCoordinate2D(location.Latitude + 0.001, location.Longitude - 0.001)
				},
			};
		}
	}
}

