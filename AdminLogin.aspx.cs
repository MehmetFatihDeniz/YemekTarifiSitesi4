using System;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "Select * From Tbl_Yonetici where YoneticiAd=@p1 and YoneticiSifre=@p2",
                bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Session["admin"] = TxtKullanici.Text;
                Response.Redirect("Kategoriler.aspx");
            }
            else
            {
                LblHata.Text = "Kullanıcı adı veya şifre hatalı";
            }

            bgl.baglanti().Close();
        }
    }
}
