using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Furnishly.UI
{
	public class ProductScreen: UIViewController
	{
		Product product;

		public ProductScreen(Product product) : base()
		{
			this.product = product;
			this.Title = product.Title;
		}

		public UIWebView webView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			var webFrame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height - 44);

			webView = new UIWebView (webFrame) {
				BackgroundColor = UIColor.White,
				ScalesPageToFit = true,
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
			};

			webView.LoadStarted += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			};
			webView.LoadFinished += delegate {
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
			};
            
            this.View.AddSubview(webView);

			webView.LoadRequest(NSUrlRequest.FromUrl(new NSUrl(product.Url)));
		}
	}
}

