using System;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class Tarifler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;
                Panel4.Visible = false;
            }

            Listele();

            // Detay sayfasından dönüş mesajları (istersen)
            if (Request.QueryString["onay"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Tarif onaylandı.";
            }
            else if (Request.QueryString["sil"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Tarif silindi.";
            }
        }

        private void Listele()
        {
            // Onaysız
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Tarifid, TarifAd FROM Tbl_Tarifler WHERE TarifDurum=0 ORDER BY Tarifid DESC", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }

            // Onaylı
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd2 = new SqlCommand(
                "SELECT Tarifid, TarifAd FROM Tbl_Tarifler WHERE TarifDurum=1 ORDER BY Tarifid DESC", con))
            using (SqlDataReader dr2 = cmd2.ExecuteReader())
            {
                DataList2.DataSource = dr2;
                DataList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e) => Panel2.Visible = true;
        protected void Button2_Click(object sender, EventArgs e) => Panel2.Visible = false;
        protected void Button3_Click(object sender, EventArgs e) => Panel4.Visible = true;
        protected void Button4_Click(object sender, EventArgs e) => Panel4.Visible = false;
    }
}
