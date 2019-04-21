using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class holidays
    {
        public int holidayID { get; set; }
        public string holidayRefCountryCode { get; set; }
        public string holidayName { get; set; }
        public DateTime holidayDate { get; set; }
    }
}
