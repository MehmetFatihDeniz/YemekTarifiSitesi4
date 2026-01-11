using System;

namespace YemekTarifiSitesi4
{
    public partial class AdminCikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session temizle
            Session.Clear();
            Session.Abandon();

            // Login sayfasına yönlendir
            Response.Redirect("AdminLogin.aspx");
        }
    }
}
