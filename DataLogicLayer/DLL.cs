using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataLogicLayer
{
    public class DLL
    {
        private SqlConnection connect;
        private SqlDataAdapter adapter;
        public DataTable table;
        public DLL()
        {
            connect = new SqlConnection("server=.; database=libraryinfoDB; user id=sa; pwd=1234;");
        }
        public DataTable getAllCountries()
        {
            try
            {
                adapter = new SqlDataAdapter("select * from countries", connect);
                table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (Exception)
            {

                table = null;
                return table;
            }
        }

        public DataTable getCountryOfCountryCode(string _countryCode)
        {
            try
            {
                adapter = new SqlDataAdapter("select * from countries where country_code='" + _countryCode + "'", connect);
                table = new DataTable();
                adapter.Fill(table);
                return table;

            }
            catch (Exception)
            {

                table = null;
                return table;
            }
        }

        public DayOfWeek[] getCountryOffDays(string _countryCode)
        {
            DayOfWeek[] offDays;
            try
            {
                adapter = new SqlDataAdapter("select * from off_days where offdayrefcountry_code='" + _countryCode + "'", connect);
                table = new DataTable();
                adapter.Fill(table);
                offDays = new DayOfWeek[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    offDays[i] = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), table.Rows[i]["offday_name"].ToString(), true);
                }
                return offDays;
            }
            catch (Exception err)
            {
                offDays = new DayOfWeek[0];
                return offDays;
            }
        }

        public DateTime[] getCountryHolidays(string _countryCode)
        {
            DateTime[] holidays;
            try
            {
                adapter = new SqlDataAdapter("select * from holidays where holidayrefcountry_code='" + _countryCode + "'", connect);
                table = new DataTable();
                adapter.Fill(table);
                holidays = new DateTime[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    holidays[i] = Convert.ToDateTime(table.Rows[i]["holiday_date"].ToString());
                }
                return holidays;
            }
            catch (Exception)
            {
                holidays = new DateTime[0];
                return holidays;
            }
        }
    }
}

