
using System;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp {
    public class HomePage : ContentPage {
        Button buttonGenerateBarcode;
        Button buttonScanDefaultOverlay;
        ZXingScannerPage scanPage;

        public HomePage() {
            buttonScanDefaultOverlay = new Button {
                Text = "Let's Scan" ,
            };

            buttonScanDefaultOverlay.Clicked += async delegate {
                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) => {
                    scanPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() => {
                        Navigation.PopAsync();
                        DisplayAlert("Scanned Barcode" , result.Text , "OK");
                        if (Validate(result.Text , DependencyService.Get<ITicketStorage>().LoadCodes(Constant.LocalFile))) {
                            DependencyService.Get<ITicketStorage>().Save(Constant.LocalFile , result.Text);
                            //new ConfirmationPage(result.Text); //This isn't the right way to make it, however the page does work
                        }
                    });
                };

                await Navigation.PushAsync(scanPage);
            };


            buttonGenerateBarcode = new Button {
                Text = "Barcode Generator"
            };
            buttonGenerateBarcode.Clicked += async delegate {
                await Navigation.PushAsync(new BarcodePage());
            };

            var stack = new StackLayout();
            //	stack.Children.Add (buttonGenerateBarcode);
            stack.Children.Add(buttonScanDefaultOverlay);

            Content = stack;

        }
        protected bool Validate(string newString , List<string> codes) {
            if (codes.Count == 0) return true; //Empty file
            foreach (string c in codes) {
                if (c == newString) {
                    return false;
                }
            }
            return true;
        }
    }
}


