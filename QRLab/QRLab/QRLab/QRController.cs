using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using ZXing.QrCode;
using ZXing.Mobile;

namespace QRLab {
    class TestQRController {
        public string Result { get; private set; }

        public void Process (QRCodeReader Reader) {
            //Do whatever we need
        }

    }
}