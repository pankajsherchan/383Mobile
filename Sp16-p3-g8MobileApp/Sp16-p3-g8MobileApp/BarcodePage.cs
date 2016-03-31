using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Sp16p3g8MobileApp
{
	public class BarcodePage : ContentPage
	{
		ZXingBarcodeImageView barcode;

		public BarcodePage ()
		{
			barcode = new ZXingBarcodeImageView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,                   
			};
			barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
			barcode.BarcodeOptions.Width = 300;
			barcode.BarcodeOptions.Height = 300;
			barcode.BarcodeOptions.Margin = 10;
			barcode.BarcodeValue = "ZXing.Net.Mobile";
			barcode.BarcodeValue = "fajkhkasjkdfh";
			Content = barcode;
		}
	}

}





