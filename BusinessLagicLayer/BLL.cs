using DataLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLagicLayer
{
    public class BLL
    {
        DLL dll;
        public BLL()
        {
            dll = new DLL();
        }
        public DataTable getAllCountries()
        {
            return dll.getAllCountries();
        }


        public countries getCountryOfCountryCode(string _countryCode)
        {
            DataTable dT= dll.getCountryOfCountryCode(_countryCode);
            if (dT.Rows.Count>0)
            {
                return new countries
                {
                    countryCode = dT.Rows[0]["country_code"].ToString(),
                    countryName = dT.Rows[0]["country_name"].ToString(),
                    currencyCode = dT.Rows[0]["currency_code"].ToString(),
                    penaltyMoneyAmount = Convert.ToDecimal(dT.Rows[0]["penaltymoney_amount"])
                };
            }
            else
            {
                countries country = new countries();
                country = null;
                return country;
            }
        }

        public DayOfWeek[] getCountryOffDays(string _countryCode)
        {
            return dll.getCountryOffDays(_countryCode);
        }

        public DateTime[] getCountryHolidays(string _countryCode)
        {
            return dll.getCountryHolidays(_countryCode);

        }
    }
}
