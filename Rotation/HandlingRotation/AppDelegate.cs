using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace HandlingRotation {
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {

		protected UIWindow window;
		protected UINavigationController mainNavController;
		protected HandlingRotation.Screens.iPhone.Home.HomeScreen iPhoneHome;
		protected HandlingRotation.Screens.iPad.Home.HomeScreenPad iPadHome;

		/// <summary>
		/// The current device (iPad or iPhone)
		/// </summary>
		public DeviceType CurrentDevice { get; set; }

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create our window
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.MakeKeyAndVisible ();
			
			// are we running an iPhone or an iPad?
			DetermineCurrentDevice ();

			// instantiate our main navigatin controller and add it's view to the window
			mainNavController = new UINavigationController ();
			mainNavController.NavigationBar.Translucent = false;

			switch (CurrentDevice)
			{
				case DeviceType.iPhone:
					iPhoneHome = new HandlingRotation.Screens.iPhone.Home.HomeScreen ();
					mainNavController.PushViewController (iPhoneHome, false);
					break;
				
				case DeviceType.iPad:
					iPadHome = new HandlingRotation.Screens.iPad.Home.HomeScreenPad ();
					mainNavController.PushViewController (iPadHome, false);
					break;
			}

			window.RootViewController = mainNavController;

			return true;
		}

		protected void DetermineCurrentDevice ()
		{
			// figure out the current device type
			if (UIScreen.MainScreen.Bounds.Height == 1024 || UIScreen.MainScreen.Bounds.Width == 1024) {
				CurrentDevice = DeviceType.iPad;
			} else {
				CurrentDevice = DeviceType.iPhone;
			}
		}
	}
}