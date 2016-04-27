using System;
using System.IO;
using System.Collections.Generic;
using System.Text;



using Sp16p3g8MobileApp;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Platform.iOS;
using Mono;

[assembly: Dependency(typeof(ITicketStorage))]
namespace Sp16p3g8MobileApp.iOS {
    class TicketStorageIOS : ITicketStorage {
        public List<string> LoadCodes(string filename) {           

            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentspath , filename);
            string source = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<string>>(source); //DEJSONIFY!
        }

        public void Save(string filename , string NewCode) {
            string JSONCode = JsonConvert.SerializeObject(NewCode); //JSONIFY!

            var documentspath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filePath = Path.Combine(documentspath , filename);

            File.AppendAllText(filePath , JSONCode);
        }
    }
}
