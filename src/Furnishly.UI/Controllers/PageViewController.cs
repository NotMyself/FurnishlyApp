using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Furnishly.UI
{
	public class PageViewController: UIViewController
	{
		Product product;

		public PageViewController(Product product) : base()
		{
			this.product = product;
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
				//webView.EvaluateJavascript (script ());
			};
            
            this.View.AddSubview(webView);

			webView.LoadRequest(NSUrlRequest.FromUrl(new NSUrl(product.Url)));
		}

		private string script ()
		{
			return "var head = document.getElementsByTagName(\"head\")[0];"
				 + "var element = document.createElement(\"meta\");"
				 + "element.name = \"viewport\";"
				 + "element.content = \"width=device-width; initial-scale=2.90; maximum-scale=2.90;\";"
				 + "head.appendChild(element);";	
		}
	}
}

