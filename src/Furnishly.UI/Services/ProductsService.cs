using System;
using System.Linq;
using System.Net;
using System.Collections;
using System.Collections.Generic;

using MonoTouch.CoreLocation;
using ServiceStack.Text;
using ServiceStack.Text.Json;
	
namespace Furnishly.UI
{
	public class ProductsService
	{
		private const string CoordinatesUrl = "http://furnishly.com/product_api.php?lat={0}&lng={1}";
		
		public ProductsService()
		{
		}
		
		public IEnumerable<Product> GetProductsNear(CLLocationCoordinate2D location)
		{
			var products = Enumerable.Empty<Product>();
			var request = WebRequest.Create(CoordinatesUrl.FormatWith(location.Latitude, location.Longitude));
			using (var response = request.GetResponse())
			{
				products = JsonSerializer.DeserializeFromStream<Product[]>(response.GetResponseStream());
			}
			
			return products;
		}
	}
}

