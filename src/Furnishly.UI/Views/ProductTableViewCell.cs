using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace Furnishly.UI
{
	public class ProductTableViewCell : UITableViewCell
	{
		Product product;
		NSMutableData imageData;
		UIActivityIndicatorView indicatorView;
		
		public ProductTableViewCell(Product product, string identKey) : base(UITableViewCellStyle.Subtitle, identKey)
		{
			Initialize();
			UpdateCell(product);
			
		}
		
		void Initialize()
		{
			indicatorView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
			indicatorView.HidesWhenStopped = true;
			var width  = (this.ImageView.Frame.Width-20)/2;
			var height = (this.ImageView.Frame.Height-20)/2;
			indicatorView.Frame = new RectangleF(width, height,20,20);
			this.ImageView.AddSubview(indicatorView);
		}
		
		public void UpdateCell(Product product)
		{
			this.product = product;
			
			this.TextLabel.LineBreakMode = UILineBreakMode.TailTruncation;
			this.Accessory = UITableViewCellAccessory.DisclosureIndicator;
        	this.TextLabel.Text = this.product.Title;
        	this.DetailTextLabel.Text = this.product.Price;
			this.ImageView.Image = UIImage.FromFile("Images/icon-29.png");
			if(!string.IsNullOrWhiteSpace(product.IconImageUri))
				DownloadImage(product.IconImageUri);
		}
		
		public void DownloadImage(string url){
			indicatorView.StartAnimating();
			NSUrlRequest request = new NSUrlRequest(new NSUrl(url));
			
			new NSUrlConnection(request, new ConnectionDelegate(this), true);
		}
		
		class ConnectionDelegate : NSUrlConnectionDelegate 
		{
		
			ProductTableViewCell cell;
			
			public ConnectionDelegate(ProductTableViewCell cell)
			{
				this.cell = cell;
			}
			
			public override void ReceivedData(NSUrlConnection connection, NSData data)
			{
				if (cell.imageData==null)
					cell.imageData = new NSMutableData();
				
				cell.imageData.AppendData(data);	
			}
			
			public override void FinishedLoading(NSUrlConnection connection)
			{
				cell.indicatorView.StopAnimating();
				var downloadedImage = UIImage.LoadFromData(cell.imageData);
				cell.imageData = null;
				cell.ImageView.Image = downloadedImage;
			}
		}
	}
}
