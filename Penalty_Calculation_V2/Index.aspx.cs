using BusinessLagicLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penalty_Calculation_V2
{
    public partial class Index : System.Web.UI.Page
    {
        BLL bll;
        public Index()
        {
            bll = new BLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable countries = bll.getAllCountries(); //bütün ülkeler çekildi
                drp_CountryList.DataValueField = "country_code"; // dropdownlitte seçilen item'ın value değeri.
                drp_CountryList.DataTextField = "country_name"; // dropdownlitte gözükecek olan değer.
                drp_CountryList.DataSource = countries;//dropdownlitin datassource'une ülkeler tablosu kaynak olarak gösterildi.
                drp_CountryList.DataBind(); // veri dropdownlitte yüklendi.
            }
            else
                return;
        }

        protected void btn_Calculate_Click(object sender, EventArgs e) // Page Üzerindeki Calculate buttonunun Click eveti.
        {
            DateTime _dtCheckOutDate, _dtReturnedDate; // sayfa üzerinde girilen teslim ve iade tarihini tutacak olan değişken
            string _countryCode; // sayfa üzerinde seçilen ülkenin kodunu tutacak olan değişken
            try
            {
                ReadItemBindValues(out _dtCheckOutDate, out _dtReturnedDate, out _countryCode); // sayfadan girilen değerler okunup değişkenlere aktarıldı
                if (_dtReturnedDate > _dtCheckOutDate) // iade tarihi alış tarihinden büyük mü?
                {
                    countries country = bll.getCountryOfCountryCode(_countryCode); // Seçilen ülkenin Bilgilerini getir.
                    DayOfWeek[] offDays = bll.getCountryOffDays(_countryCode); // Seçilen ülkenin offdys bilgilerini getir.
                    DateTime[] holidays = bll.getCountryHolidays(_countryCode); // Seçilen ülkenin holidays bilgilerini getir.
                    int businessDaysCount = 0, penaltyDaysCount = 0; // business days ve penalty days değerlerini tutacak olan veriable
                    for (DateTime i = _dtCheckOutDate; i <= _dtReturnedDate; i = i.AddDays(1)) // alış tarihinden iade tarihine kadar dongü oluşturuldu.
                    {
                        if (!IsOffDay(i.DayOfWeek, offDays) & !IsHoliday(i, holidays)) // doögüdeği şuanki tarih offdays veya golidays günlerinden birtanesimi kontrol et.
                        {
                            businessDaysCount++; // businessDaysCount değişkenini bir arttır.
                            if (businessDaysCount > 10) // businessDaysCount 10'dan büyük ise 
                            {
                                penaltyDaysCount++;// penaltyDaysCount değişkenini bir arttır.
                            }
                        }
                    }

                    BindSession(businessDaysCount, penaltyDaysCount, country.currencyCode, country.penaltyMoneyAmount); // Sessionu doldur ver Result sayfasını aç.
                }
                else
                    showAlert();


            }
            catch (Exception)
            {

                showAlert();
            }
        }

        private void BindSession(int businessDaysCount, int penaltyDaysCount, string currencyCode, decimal penaltyMoneyAmount) // sessiona bilgileri aktarıp Result.aspx sayfasını açan method.
        {
            Session.Clear(); // Session temizle
            Session["businessDay"] = businessDaysCount + " Days"; // businessDaysCount blgisini sessiona yükle
            Session["penaltyInfos"] = penaltyDaysCount + " Days" + " " + String.Format("{0:0.00}", (penaltyMoneyAmount * penaltyDaysCount)) + " " + currencyCode;  // Penalty bilgilerini hesapla ve sessiona yükle.
            Response.Redirect("Result.aspx"); //Result.aspx'i aç;

        }

        private bool IsHoliday(DateTime i, DateTime[] holidays)// i tarihi , holidays günlerinden birisine şit olup olmadığını karşılaştıran method.
        {

            for (int j = 0; j < holidays.Length; j++)
            {
                if (holidays[j] == i)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsOffDay(DayOfWeek dayOfWeek, DayOfWeek[] offDays) // dayOfWeek, offDays günlerinden birisine eşit olup olmadığını karşılaştıran method.
        {
            for (int j = 0; j < offDays.Length; j++)
            {
                if (offDays[j] == dayOfWeek)
                {
                    return true;
                }
            }
            return false;
        }

        private void ReadItemBindValues(out DateTime _dtCheckOutDate, out DateTime _dtReturnedDate, out string _countryCode) //sayfadan girilen değerler okunup değişkenlere aktarıldı
        {
            _dtCheckOutDate = Convert.ToDateTime(txt_CheckOutDate.Value); // kitabın kiralama tarihi okundu
            _dtReturnedDate = Convert.ToDateTime(txt_ReturnedDate.Value); // kitabın iade ediliş tarihi okundu
            _countryCode = drp_CountryList.SelectedValue.ToString();// seçilem ülkenin kodu okundu.
        }

        private void showAlert() // Methoda gelen parametreyi alert olarak ekranda gösteren method.
        {
            Response.Write("<script type = 'text/javascript'> alert('Invalid Data, Check Input Format'); </script>");
        }
    }
}