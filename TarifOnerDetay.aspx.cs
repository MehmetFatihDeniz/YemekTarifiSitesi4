using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace YemekTarifiSitesi4
{
    public partial class TarifOnerDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        private int TarifId
        {
            get
            {
                int.TryParse(Request.QueryString["Tarifid"], out int id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (TarifId <= 0)
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Tarifid.";
                BtnOnayla.Enabled = false;
                BtnSil.Enabled = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                KategorileriDoldur();
                TarifiGetir();
            }
        }

        private void KategorileriDoldur()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("SELECT Kategoriid, KategoriAd FROM Tbl_Kategoriler ORDER BY KategoriAd", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DropDownList1.DataTextField = "KategoriAd";
                DropDownList1.DataValueField = "Kategoriid";
                DropDownList1.DataSource = dr;
                DropDownList1.DataBind();
            }
        }

        private void TarifiGetir()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TarifAd, TarifMalzeme, TarifYapilis, TarifResim, TarifSahip, TarifSahipMail, TarifDurum
                FROM Tbl_Tarifler
                WHERE Tarifid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = TarifId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Red;
                        LblBilgi.Text = "Tarif bulunamadı.";
                        BtnOnayla.Enabled = false;
                        BtnSil.Enabled = false;
                        return;
                    }

                    TextBox1.Text = dr["TarifAd"].ToString();
                    TextBox2.Text = dr["TarifMalzeme"].ToString();
                    TextBox3.Text = dr["TarifYapilis"].ToString();
                    TextBox4.Text = dr["TarifSahip"].ToString();
                    TextBox5.Text = dr["TarifSahipMail"].ToString();

                    string resim = dr["TarifResim"] == DBNull.Value ? "" : dr["TarifResim"].ToString();
                    LblResim.Text = string.IsNullOrWhiteSpace(resim) ? "Kayıtlı resim yok." : ("Kayıtlı resim: " + resim);

                    bool durum = dr["TarifDurum"] != DBNull.Value && Convert.ToBoolean(dr["TarifDurum"]);
                    if (durum)
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Green;
                        LblBilgi.Text = "Bu tarif zaten onaylı.";
                    }
                }
            }
        }

        protected void BtnOnayla_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(DropDownList1.SelectedValue, out int kategoriId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Kategori seçimi geçersiz.";
                return;
            }

            // Resim seçildiyse kaydet (opsiyonel)
            string yeniResimYolu = null;
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".webp")
                {
                    LblBilgi.ForeColor = System.Drawing.Color.Red;
                    LblBilgi.Text = "Sadece .jpg / .png / .webp yükleyebilirsin.";
                    return;
                }

                string dosyaAdi = Guid.NewGuid().ToString("N") + ext;
                string fiziksel = Server.MapPath("~/resimler/" + dosyaAdi);
                FileUpload1.SaveAs(fiziksel);
                yeniResimYolu = "~/resimler/" + dosyaAdi;
            }

            using (SqlConnection con = bgl.baglanti())
            using (SqlTransaction tr = con.BeginTransaction())
            {
                try
                {
                    // 1) Tarifi onayla (+ resim güncelle varsa)
                    if (!string.IsNullOrEmpty(yeniResimYolu))
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Tbl_Tarifler SET TarifDurum=1, TarifResim=@r WHERE Tarifid=@id", con, tr))
                        {
                            cmd.Parameters.Add("@r", SqlDbType.NVarChar, 300).Value = yeniResimYolu;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = TarifId;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE Tbl_Tarifler SET TarifDurum=1 WHERE Tarifid=@id", con, tr))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = TarifId;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // 2) Yemeği ana sayfaya ekle (Tbl_Yemekler)
                    using (SqlCommand cmd2 = new SqlCommand(@"
                        INSERT INTO Tbl_Yemekler (YemekAd, YemekMalzeme, YemekTarif, Kategoriid, YemekResim)
                        VALUES (@a,@m,@t,@k,@r)", con, tr))
                    {
                        cmd2.Parameters.Add("@a", SqlDbType.NVarChar, 100).Value = TextBox1.Text.Trim();
                        cmd2.Parameters.Add("@m", SqlDbType.NVarChar).Value = TextBox2.Text.Trim();
                        cmd2.Parameters.Add("@t", SqlDbType.NVarChar).Value = TextBox3.Text.Trim();
                        cmd2.Parameters.Add("@k", SqlDbType.Int).Value = kategoriId;
                        cmd2.Parameters.Add("@r", SqlDbType.NVarChar, 300).Value =
                        string.IsNullOrEmpty(yeniResimYolu) ? (object)DBNull.Value : yeniResimYolu;

                        cmd2.ExecuteNonQuery();
                    }

                    // 3) Kategori adet artır
                    using (SqlCommand cmd3 = new SqlCommand(
                        "UPDATE Tbl_Kategoriler SET KategoriAdet = KategoriAdet + 1 WHERE Kategoriid=@k", con, tr))
                    {
                        cmd3.Parameters.Add("@k", SqlDbType.Int).Value = kategoriId;
                        cmd3.ExecuteNonQuery();
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    LblBilgi.ForeColor = System.Drawing.Color.Red;
                    LblBilgi.Text = "Onaylama sırasında hata oluştu.";
                    return;
                }
            }

            Response.Redirect("Tarifler.aspx?onay=1");
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Tarifler WHERE Tarifid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = TarifId;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Tarifler.aspx?sil=1");
        }
    }
}
