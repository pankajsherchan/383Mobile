using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


//Purpose is more or less to keep track of Local Data
namespace Sp16p3g8MobileApp.History {
    [JsonObject(MemberSerialization.OptIn)]
    class HistoryObject {
        //Identifying information
        [JsonProperty]
        public string MovieName { get; set; }
        [JsonProperty]
        public string ReleaseDate { get; set; }
        [JsonProperty]
        public int ReviewsPosted { get; set; }

        //QR Code area
        [JsonProperty]
        List<string> ScannedCodes;

        //Handly Little validator function!
        public bool CanLeaveAReview() {
            return ReviewsPosted > ScannedCodes.Count ? true : false;
        }

    }
}
