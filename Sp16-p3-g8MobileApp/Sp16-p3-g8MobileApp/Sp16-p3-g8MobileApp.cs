using Sp16p3g8MobileApp.Views;
using System;

using Xamarin.Forms;

namespace Sp16p3g8MobileApp
{
	public class App : Application
	{
		public App ()
		{
			
			//start up page
			MainPage = new NavigationPage(new PurchasePage());

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

