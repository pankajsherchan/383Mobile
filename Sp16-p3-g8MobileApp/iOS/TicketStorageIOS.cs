using System;
using System.Collections.Generic;
using System.Text;

using Sp16p3g8MobileApp;
using Xamarin.Forms;
using Newtonsoft.Json;

[assembly: Dependency(typeof(ITicketStorage))]
namespace Sp16p3g8MobileApp.iOS {
    class TicketStorageIOS : ITicketStorage {
        public List<string> LoadCodes(string filename) {
            //Loading according to Xamarin
            /* var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath , filename);
            string source = System.IO.File.ReadAllText(filePath);
            List<String> = DeserializeJSONObjects(Source); */ //DEJSONIFY!

            throw new NotImplementedException();
        }

        public void Save(string filename , string NewCode) {
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
