using FinalWebAPI.APIHelper;
using FinalWebAPI.Barcode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing.QrCode;

namespace FinalWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //BarcodeGenerator a = new BarcodeGenerator();
            //a.generate();

            //MovieAPI1 a = new MovieAPI1();
            //a.Get();
            ViewBag.Title = "Home Page";

            return View();
        }



        public FileContentResult CaptchaImage( string qrcode)
        {
            var rand = new Random((int)DateTime.Now.Ticks);


            //image stream
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            //using (var bmp = new Bitmap(130, 30))
            //using (var gfx = Graphics.FromImage((Image)bmp))
            {
                QRCodeWriter qr = new QRCodeWriter();

                string url = qrcode;

                var matrix = qr.encode(url, ZXing.BarcodeFormat.QR_CODE, 200, 200);

                ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();

                w.Format = ZXing.BarcodeFormat.QR_CODE;

                Bitmap img1 = w.Write(matrix);



             

                //render as Png
                img1.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
                img = this.File(mem.GetBuffer(), "image/png");
            }

            var file = File(img.FileContents, img.ContentType);

            return File(img.FileContents, img.ContentType);
        }
    }
}
