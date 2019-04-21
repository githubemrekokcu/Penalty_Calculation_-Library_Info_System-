using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Penalty_Calculation_V2
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindComponent(); // Safadaki Componentleri Dolduran method
        }

        private void BindComponent()
        {
            try
            {
                if (!string.IsNullOrEmpty(Session["businessDay"].ToString()) &
                    !string.IsNullOrEmpty(Session["penaltyInfos"].ToString())) // Session Boş değilise
                {
                    lbl_BusinessDay.InnerText = Session["businessDay"].ToString(); // businessDay bilgisini yaz
                    lbl_PenaltyDayPrice.InnerText = Session["penaltyInfos"].ToString(); // penaltyInfos bilgisini yaz

                }
                else
                    showAlert("Data Not Read  !!!"); 

            }
            catch (Exception)
            {

                showAlert("Data Not Read  !!!");
            }
        }

        private void showAlert(string _message)
        {
            Response.Write("<script>alert('" + _message + "')</script>");
        }
    }
}