using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sp16p3g8MobileApp.Models
{
   public class Showtime
    {
        public int Id { get; set; }
        

        public int ScreenId { get; set; }
        public virtual Screen Screen { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public string StartTime { get; set; }
    }
}
