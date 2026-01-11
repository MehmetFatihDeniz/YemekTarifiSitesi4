using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class HakkimizdaAdmin : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;
                MetniGetir();

                if (Request.QueryString["g"] == "1")
                {
                    LblBilgi.ForeColor = System.Drawing.Color.Green;
                    LblBilgi.Text = "Hakkımızda metni güncellendi.";
                }
            }
        }

        private void MetniGetir()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Metin FROM Tbl_Hakkimizda", con))
            {
                object val = cmd.ExecuteScalar();
                TextBox1.Text = val == null ? "" : val.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string metin = TextBox1.Text.Trim();

            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("UPDATE Tbl_Hakkimizda SET Metin=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = metin;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("HakkimizdaAdmin.aspx?g=1");
        }
    }
}
