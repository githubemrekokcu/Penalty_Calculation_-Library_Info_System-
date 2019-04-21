using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class countries
    {
        public int countryID { get; set; }
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string currencyCode { get; set; }
        public decimal penaltyMoneyAmount { get; set; }
    }
}
