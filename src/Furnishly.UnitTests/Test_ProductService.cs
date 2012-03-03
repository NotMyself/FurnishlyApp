using System;
using MonoTouch.CoreLocation;
using NUnit.Framework;
using Furnishly.UI;
using ServiceStack.Text;

namespace Furnishly.UnitTests
{
	[TestFixture]
	public class Test_ProductService
	{
		[Test]
		public void product_service_should_be_able_to_fetch_products_by_coordinates()
		{
			var coordinates = new CLLocationCoordinate2D(41.8942,-87.6228);
			var productsService = new ProductsService();
			
			var result = productsService.GetProductsNear(coordinates);
			
			Assert.That(result, Is.Not.Null);
		}
	}
}
