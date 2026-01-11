using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YemekTarifiSitesi4
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Admin giriş kontrolü (master'a bağlı tüm sayfaları korur)
            if (Session["admin"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
}