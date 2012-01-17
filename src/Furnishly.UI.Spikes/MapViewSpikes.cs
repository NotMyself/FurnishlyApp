using System;

using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace Furnishly.UI.Spikes
{
	public class MapViewSpikes
	{
		UIWindow window;
		
		public MapViewSpikes(UIWindow window)
		{
			if(window == null)
				throw new ArgumentNullException("window");
			
			this.window = window;
		}
		
		public UINavigationController NavigationController 
		{
			get { return (UINavigationController) window.RootViewController; }
		}
		
		public UIViewController GetViewController()
		{
			var menu = new RootElement("Map Views");
			
			var section = new Section()
			{
				new StyledStringElement("Show My Current Location", CurrentLocation)	
			};
			
			menu.Add(section);
			
			var viewController = new DialogViewController(menu) { Autorotate = true };
			
			return viewController;
		}
		
		public void CurrentLocation()
		{
			NavigationController.PushViewController(new ProductsViewController(new LocationService(), new ProductsService()), true);
		}
	}
}

