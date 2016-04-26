using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sp16p3g8MobileApp.Data {
    public static class TicketStorage {

        public static List<string> GetTicketsFromStorage() {
            //List<String> = DeserializeJSONObjects(Source); //DEJSONIFY!
            throw new NotImplementedException();
        }

        public static void AddTicketToStorage(string s) {
            s = JsonConvert.SerializeObject(s); //JSONIFY!
            throw new NotImplementedException();
        }
    }
}
