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

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath , filename);

            if (File.Exists(filePath)) {
                string source = File.ReadAllText(filePath);
                List<string> result = JsonConvert.DeserializeObject<List<string>>(source); //DEJSONIFY!
                return result;
            } else {
                return new List<string>(); //Empty list
            }

        }

        //IMPORTANT! VALIDATE TO MAKE SURE THE SAME QR CODE HAS NOT BEEN SCANED BEFORE USING THIS METHOD!
        public void Save(string filename , string NewCode) {
            //We might need this
            //List<string> codes = LoadCodes(filename);
            //codes.Add(NewCode);
            string JSONCode = JsonConvert.SerializeObject(NewCode); //JSONIFY!
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath , filename);
            if (File.Exists(filePath)) {
                File.AppendAllText(filePath , JSONCode);
            } else {
                File.Create(filePath);
            }
        }
        /* add this in Home Page
         *  inside the barcode generator
         * if (Validate(result.Text, DependencyService.Get<ITicketStorage>().LoadCodes(Constant.LocalFile))) DependencyService.Get<ITicketStorage>().Save(Constant.LocalFile,result.Text);
         * As it's own method
         *         protected bool Validate(string newString, List<string> codes) {
            if (codes.Count == 0) return true; //Empty file
            foreach(string c in codes) {
                if(c == newString) {
                    return false;
                }
            }
            return true;
        }
         */
    }
}