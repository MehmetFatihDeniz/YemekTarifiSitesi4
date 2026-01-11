using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class MesajDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        private int MesajId
        {
            get
            {
                int.TryParse(Request.QueryString["Mesajid"], out int id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (MesajId <= 0)
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Mesajid.";
                BtnSil.Enabled = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                Yukle();
            }
        }

        private void Yukle()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT MesajGonderen, MesajBaslik, MesajMail, Mesajicerik
                FROM Tbl_Mesajlar
                WHERE Mesajid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = MesajId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        TextBox1.Text = dr["MesajGonderen"].ToString();
                        TextBox2.Text = dr["MesajBaslik"].ToString();
                        TextBox3.Text = dr["MesajMail"].ToString();
                        TextBox4.Text = dr["Mesajicerik"].ToString();
                    }
                    else
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Red;
                        LblBilgi.Text = "Mesaj bulunamadı.";
                        BtnSil.Enabled = false;
                    }
                }
            }
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Tbl_Mesajlar WHERE Mesajid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = MesajId;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Mesajlar.aspx?s=1");
        }
    }
}
