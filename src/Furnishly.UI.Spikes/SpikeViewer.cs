using System;

using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace Furnishly.UI.Spikes
{
	public class SpikeViewer
	{
		UIWindow window;
		
		public SpikeViewer(UIWindow window)
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
			var menu = new RootElement("Spikes");
			
			var section = new Section()
			{
				new StyledStringElement("Map View Spikes", MapView)	
			};
			
			menu.Add(section);
			
			var viewController = new DialogViewController(menu) { Autorotate = true };
			
			return viewController;
		}
		
		public void MapView()
		{
			var mapViewSpikes = new MapViewSpikes(window);
			NavigationController.PushViewController(mapViewSpikes.GetViewController(), true);
			
		}
	}
}

