using System;
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

namespace QRLab {
    [Activity(Label = "QRLab" , MainLauncher = true , Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        TestQRController C;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            ImageView IV = FindViewById<ImageView>(Resource.Id.QRExample);


            //initialize
            var options = new QrCodeEncodingOptions {
                DisableECI = true ,
                CharacterSet = "UTF-8" ,
                Width = 100 ,
                Height = 100
            };

            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            writer.Encode("Hello world!");

            Canvas c = new Canvas();
            c.DrawBitmap();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { Scan(IV); };
        }
        public void Scan(ImageView I) {
            //Reader.decode()
            Toast.MakeText(this , "QRCodeScanned!" , ToastLength.Short);
        }
    }
}

