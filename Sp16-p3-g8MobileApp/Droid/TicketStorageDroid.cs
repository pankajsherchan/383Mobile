using System;
using System.IO;
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

[assembly: Dependency(typeof(Sp16p3g8MobileApp.Droid.TicketStorageDroid))]
namespace Sp16p3g8MobileApp.Droid {
    class TicketStorageDroid : ITicketStorage {
        
        public TicketStorageDroid() {

        }

        public List<string> LoadCodes(string filename) {
            
            //I wish there was a "App data" area but docs 'll be fine for now
            var rootPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
            string path = rootPath.AbsolutePath;
            rootPath.Dispose();

            var filePath = Path.Combine(path , filename);
            string source = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<string>>(source); //DEJSONIFY!
        }

        //IMPORTANT! VALIDATE TO MAKE SURE THE SAME QR CODE HAS NOT BEEN SCANED BEFORE USING THIS METHOD!
        public void Save(string filename, string NewCode) {
            //We might need this
            //List<string> codes = LoadCodes(filename);
            //codes.Add(NewCode);
            string JSONCode = JsonConvert.SerializeObject(NewCode); //JSONIFY!

            var rootPath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
            string path = rootPath.AbsolutePath;
            rootPath.Dispose();

            var filePath = Path.Combine(path , filename);
            File.AppendAllText(path , JSONCode);
        }
    }
}