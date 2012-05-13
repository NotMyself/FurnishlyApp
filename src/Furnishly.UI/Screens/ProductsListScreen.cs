using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace Furnishly.UI
{
	public partial class ProductsListScreen : UIViewController
	{
		IList<Product> products;
		
		public ProductsListScreen(IEnumerable<Product> products) : base("ProductsListScreen", null)
		{
			this.products = products.ToList();
			TabBarItem = new UITabBarItem 
			{ 
				Title = "List", 
				Image = UIImage.FromFile("Images/list_64.png")
			};
		}
		
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad()
		{			
			base.ViewDidLoad();	
		}
		
		public override void ViewWillAppear (bool animated)
		{
			this.productsList.DataSource = new ProductTableViewDataSource (products);
			this.productsList.Delegate = new ProductTableViewDelegate (this, products);
			
			base.ViewWillAppear (animated);
		}
		
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose(); myOutlet = null;
			
			ReleaseDesignerOutlets();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
	
	public class ProductTableViewDataSource : UITableViewDataSource
    {
		private string cellId = "cellid";
		public IList<Product> products;

		public ProductTableViewDataSource(IList<Product> products)
        {
			this.products = products;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return products.Count;
        }

        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
        	var cell = tableView.DequeueReusableCell(cellId) as ProductTableViewCell;
        	if (cell == null)
            {
        		cell = new ProductTableViewCell(products[indexPath.Row], cellId);
        	}
        	
			cell.UpdateCell(products[indexPath.Row]);
            return cell;
        }
    }		
	
    public class ProductTableViewDelegate : UITableViewDelegate
    {
		private ProductsListScreen controller;
		private IList<Product> products;
		
        public ProductTableViewDelegate(ProductsListScreen controller, IList<Product> products)
        {
			this.controller = controller;
			this.products = products;
        }			
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
			var product = products[indexPath.Row];
			
			var productScreen = new ProductScreen(product);
			controller.NavigationController.PushViewController(productScreen, true);	
		}
    }
}

