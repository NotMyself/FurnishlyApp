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
				//BUG: MT 5.3.2 see http://docs.xamarin.com/ios/troubleshooting#System.ExecutionEngineException.3a_Attempting_to_JIT_compile_method_(wrapper_managed-to-managed)_Foo.5b.5d.3aSystem.Collections.Generic.ICollection.601.get_Count_()
				JsonReader<CLLocationCoordinate2D>.GetParseFn();
				products = JsonSerializer.DeserializeFromStream<Product[]>(response.GetResponseStream());
			}
			
			return products;
		}
	}
}

