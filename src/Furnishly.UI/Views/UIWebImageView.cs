// --------------
// ESCOZ.COM
// --------------
//https://raw.github.com/escoz/monotouch-controls/master/UICatalog/UIWebImageView.cs
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace Furnishly.UI
{
	public partial class UIWebImageView : UIImageView
	{
		NSMutableData imageData;
		UIActivityIndicatorView indicatorView;
	
		public UIWebImageView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		[Export("initWithCoder:")]
		public UIWebImageView(NSCoder coder) : base(coder)
		{
			Initialize();
		}


		void Initialize()
		{
			indicatorView = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
			indicatorView.HidesWhenStopped = true;
			var width  = (this.Frame.Width-20)/2;
			var height = (this.Frame.Height-20)/2;
			indicatorView.Frame = new RectangleF(width, height,20,20);
			this.AddSubview(indicatorView);
		}
		
		public UIWebImageView(RectangleF frame)
		{
			Initialize();
			
			indicatorView.Frame = new RectangleF(
                		frame.Size.Width/2,
                		frame.Size.Height/2,
                		indicatorView.Frame.Size.Width,
                		indicatorView.Frame.Size.Height);

		}
		
		public UIWebImageView(RectangleF frame, string url) : base(frame)
		{
			Initialize();
			Frame = frame;
			DownloadImage(url);
		}
		
		public void DownloadImage(string url)
		{
			indicatorView.StartAnimating();
			NSUrlRequest request = new NSUrlRequest(new NSUrl(url));
			
			new NSUrlConnection(request, new ConnectionDelegate(this), true);
		}
		
		class ConnectionDelegate : NSUrlConnectionDelegate 
		{
			
			UIWebImageView view;
			
			public ConnectionDelegate(UIWebImageView view)
			{
				this.view = view;
			}
			
			public override void ReceivedData (NSUrlConnection connection, NSData data)
			{
				if (view.imageData==null)
					view.imageData = new NSMutableData();
				
				view.imageData.AppendData(data);	
			}
			
			public override void FinishedLoading(NSUrlConnection connection)
			{
				view.indicatorView.StopAnimating();
				UIImage downloadedImage = UIImage.LoadFromData(view.imageData);
				view.imageData = null;
				view.Image = downloadedImage;
			}
		}
	}
}