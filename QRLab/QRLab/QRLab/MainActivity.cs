using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.QrCode;
using ZXing.Common;
using ZXing;
using Android.Media;
using Android.Graphics;

using Android.Hardware;

namespace QRLab {
    [Activity(Label = "QRLab" , MainLauncher = true , Icon = "@drawable/icon")]
    public class MainActivity : Activity /*, TextureView.ISurfaceTextureListener*/ {

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(Application);
            SetContentView(Resource.Layout.Main);

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            Button scanbutton = FindViewById<Button>(Resource.Id.MyButton);
            scanbutton.Click += (sender , e) => {
                scan(scanner);
            }; 
            //FragmentManager.BeginTransaction().Add();
        }

        //Try this!
        protected async void scan(ZXing.Mobile.MobileBarcodeScanner scanner) {
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE };

            var result = await scanner.Scan(options);
            if (result != null) {
                Toast.MakeText(this, "Scanned Image: " + result.Text , ToastLength.Long).Show();
            }
    }
}
}

