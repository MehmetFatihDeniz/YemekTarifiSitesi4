using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class YorumDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        private int YorumId
        {
            get
            {
                int.TryParse(Request.QueryString["Yorumid"], out int id);
                return id;
            }
        }

        private bool _onayliMi = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (YorumId <= 0)
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Yorumid.";
                BtnOnay.Enabled = false;
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
                SELECT y.YorumAdSoyad, y.YorumMail, y.YorumTarih, y.Yorumicerik, y.YorumOnay, ym.YemekAd
                FROM Tbl_Yorumlar y
                INNER JOIN Tbl_Yemekler ym ON y.Yemekid = ym.Yemekid
                WHERE y.Yorumid = @p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = YorumId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Red;
                        LblBilgi.Text = "Yorum bulunamadı.";
                        BtnOnay.Enabled = false;
                        BtnSil.Enabled = false;
                        return;
                    }

                    TxtAdSoyad.Text = dr["YorumAdSoyad"].ToString();
                    TxtMail.Text = dr["YorumMail"].ToString();
                    Txticerik.Text = dr["Yorumicerik"].ToString();
                    TxtYemek.Text = dr["YemekAd"].ToString();

                    // Tarih format
                    if (dr["YorumTarih"] != DBNull.Value)
                        LblTarih.Text = Convert.ToDateTime(dr["YorumTarih"]).ToString("dd.MM.yyyy HH:mm");

                    // Onay durumu
                    _onayliMi = dr["YorumOnay"] != DBNull.Value && Convert.ToBoolean(dr["YorumOnay"]);

                    if (_onayliMi)
                    {
                        LblDurum.ForeColor = System.Drawing.Color.Green;
                        LblDurum.Text = "Durum: Onaylı ✅";
                        BtnOnay.Enabled = false; // zaten onaylı
                    }
                    else
                    {
                        LblDurum.ForeColor = System.Drawing.Color.OrangeRed;
                        LblDurum.Text = "Durum: Onaysız ⛔";
                        BtnOnay.Enabled = true;
                    }
                }
            }
        }

        protected void BtnOnay_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Tbl_Yorumlar SET Yorumicerik=@p1, YorumOnay=@p2 WHERE Yorumid=@p3", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar).Value = Txticerik.Text;
                cmd.Parameters.Add("@p2", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@p3", SqlDbType.Int).Value = YorumId;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Yorumlar.aspx?onay=1");
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Tbl_Yorumlar WHERE Yorumid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = YorumId;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Yorumlar.aspx?s=1");
        }
    }
}
