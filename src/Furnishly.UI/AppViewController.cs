using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;
namespace Furnishly.UI
{
	public class AppViewController : UIViewController
	{
		UIWindow window;
		UINavigationController navigationController;
		
		public AppViewController(UIWindow window)
		{
			this.window = window;
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			this.navigationController = new UINavigationController(this);
		}
	}
}

