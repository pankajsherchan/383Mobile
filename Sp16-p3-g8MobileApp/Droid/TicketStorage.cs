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
using Sp16p3g8MobileApp;
using Xamarin.Forms;
using Newtonsoft.Json;

[assembly: Dependency(typeof(ITicketStorage))]
namespace Sp16p3g8MobileApp.Droid {
    class TicketStorage : ITicketStorage {

        public List<string> LoadCodes() {
            //Loading according to Xamarin
            /* var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath , filename);
            string source = System.IO.File.ReadAllText(filePath);
            List<String> = DeserializeJSONObjects(Source); */ //DEJSONIFY!

            throw new NotImplementedException();
        }

        public void Save(string NewCode) {
            string JSONCode = JsonConvert.SerializeObject(NewCode); //JSONIFY!
            /*The code according to Xamarin
            var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
            var filePath = Path.Combine (documentsPath, filename);
            System.IO.File.WriteAllText (filePath, text);

             */
            throw new NotImplementedException();
        }
    }
}