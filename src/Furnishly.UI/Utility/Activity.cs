using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.CoreLocation;
using System.Globalization;
using System.Drawing;

namespace Furnishly.UI
{
	public class Activity
	{
		public static UIApplication MainApp = UIApplication.SharedApplication;
		
		//
		// Since we are a multithreaded application and we could have many
		// different outgoing network connections (api.twitter, images,
		// searches) we need a centralized API to keep the network visibility
		// indicator state
		//
		static object networkLock = new object();
		static int active;
		
		public static void PushNetworkActive()
		{
			lock (networkLock){
				active++;
				MainApp.NetworkActivityIndicatorVisible = true;
			}
		}
		
		public static void PopNetworkActive()
		{
			lock (networkLock){
				active--;
				if (active == 0)
					MainApp.NetworkActivityIndicatorVisible = false;
			}
		}
	}
}

