using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;
using ZXing.QrCode;

namespace FinalWebAPI.Barcode
{
    public class BarcodeGenerator
    {


        //public void generate() { 

        //IBarcodeWriter writer = new BarcodeWriter
        //    {
        //        Format = BarcodeFormat.AZTEC
        //    };
        //    Bitmap aztecBitmap;
        //    var result = writer.Write("I love you ;)");
        //    aztecBitmap = new Bitmap(result);

        //    using (var stream = new FileStream("test.bmp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        var aztecAsBytes = ImageToByte(aztecBitmap);
        //        stream.Write(aztecAsBytes, 0, aztecAsBytes.Length);
        //    }
        //}


        //public static byte[] ImageToByte(Image img)
        //{
        //    ImageConverter converter = new ImageConverter();
        //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
        //}


        public void generate()
        {

                QRCodeWriter qr = new QRCodeWriter();

                string url = "http://www.developerbyte.com";

                var matrix = qr.encode(url, ZXing.BarcodeFormat.QR_CODE, 200, 200);

                ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();

                w.Format = ZXing.BarcodeFormat.QR_CODE;

                Bitmap img = w.Write(matrix);

                img.Save(@"C:\myQR.png", System.Drawing.Imaging.ImageFormat.Png);

                Console.ReadLine();
            }

      

    //IBarcodeWriter writer = new BarcodeWriter
    //{ Format = BarcodeFormat.QR_CODE };
    //        var result = writer.Write("Hello");
    //        var barcodeBitmap = new Bitmap(result);
    //        pictureBox1.Image = barcodeBitmap;
    //    }
    }
}