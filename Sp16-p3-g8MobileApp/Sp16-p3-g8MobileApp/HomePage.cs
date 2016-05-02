
using System;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace Sp16p3g8MobileApp
{
		public class HomePage : ContentPage
		{
			Button buttonGenerateBarcode;
			Button buttonScanDefaultOverlay;
			ZXingScannerPage scanPage;

			public HomePage ()
			{ 
				buttonScanDefaultOverlay = new Button {
					Text = "Let's Scan",
				};

				buttonScanDefaultOverlay.Clicked += async delegate {
					scanPage = new ZXingScannerPage ();
					scanPage.OnScanResult += (result) => {
						scanPage.IsScanning = false;

						Device.BeginInvokeOnMainThread (() => {
							Navigation.PopAsync ();
							DisplayAlert("Scanned Barcode", result.Text, "OK");
						});
					};

					await Navigation.PushAsync (scanPage);
				};


				buttonGenerateBarcode = new Button {
					Text = "Barcode Generator"
				};
				buttonGenerateBarcode.Clicked += async delegate {
					await Navigation.PushAsync (new BarcodePage ());    
				};

				var stack = new StackLayout ();
			//	stack.Children.Add (buttonGenerateBarcode);
				stack.Children.Add (buttonScanDefaultOverlay);

				Content = stack;

			}
		}
	}



