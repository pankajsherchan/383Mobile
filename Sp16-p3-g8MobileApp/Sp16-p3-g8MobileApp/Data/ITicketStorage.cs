using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp {
    public interface ITicketStorage {
        void Save(string filename, string NewCode);
        List<string> LoadCodes(string filename);
    }
}
