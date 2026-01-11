using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace YemekTarifiSitesi4
{
    public partial class YemekDuzenle : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        private int YemekId
        {
            get
            {
                int.TryParse(Request.QueryString["Yemekid"], out int id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (YemekId <= 0)
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Yemekid.";
                Button1.Enabled = false;
                Button2.Enabled = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                KategorileriDoldur();
                YemegiGetirVeDoldur();
            }
        }

        private void KategorileriDoldur()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Kategoriid, KategoriAd FROM Tbl_Kategoriler ORDER BY KategoriAd", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DropDownList1.DataTextField = "KategoriAd";
                DropDownList1.DataValueField = "Kategoriid";
                DropDownList1.DataSource = dr;
                DropDownList1.DataBind();
            }
        }

        private void YemegiGetirVeDoldur()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT YemekAd, YemekMalzeme, YemekTarif, Kategoriid FROM Tbl_Yemekler WHERE Yemekid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = YemekId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        TextBox1.Text = dr["YemekAd"].ToString();
                        TextBox2.Text = dr["YemekMalzeme"].ToString();
                        TextBox3.Text = dr["YemekTarif"].ToString();

                        // kategori seçili gelsin
                        string katId = dr["Kategoriid"].ToString();
                        if (DropDownList1.Items.FindByValue(katId) != null)
                            DropDownList1.SelectedValue = katId;
                    }
                    else
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Red;
                        LblBilgi.Text = "Yemek bulunamadı.";
                        Button1.Enabled = false;
                        Button2.Enabled = false;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ad = TextBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(ad))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Yemek adı boş olamaz.";
                return;
            }

            if (!int.TryParse(DropDownList1.SelectedValue, out int yeniKategoriId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Kategori seçimi geçersiz.";
                return;
            }

            using (SqlConnection con = bgl.baglanti())
            {
                // 1) Eski kategori + eski resim yolunu bul
                int eskiKategoriId = 0;
                string eskiResim = null;

                using (SqlCommand cmdOld = new SqlCommand(
                    "SELECT Kategoriid, YemekResim FROM Tbl_Yemekler WHERE Yemekid=@p1", con))
                {
                    cmdOld.Parameters.Add("@p1", SqlDbType.Int).Value = YemekId;
                    using (SqlDataReader dr = cmdOld.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            eskiKategoriId = Convert.ToInt32(dr["Kategoriid"]);
                            eskiResim = dr["YemekResim"] == DBNull.Value ? null : dr["YemekResim"].ToString();
                        }
                        else
                        {
                            LblBilgi.ForeColor = System.Drawing.Color.Red;
                            LblBilgi.Text = "Yemek bulunamadı.";
                            return;
                        }
                    }
                }

                // 2) Resim seçildiyse kaydet
                string yeniResimYolu = eskiResim;
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
                    string fizikselYol = Server.MapPath("~/resimler/" + dosyaAdi);
                    FileUpload1.SaveAs(fizikselYol);
                    yeniResimYolu = "~/resimler/" + dosyaAdi;
                }

                // 3) Update yemek
                using (SqlCommand cmdUpd = new SqlCommand(
                    "UPDATE Tbl_Yemekler SET YemekAd=@p1, YemekMalzeme=@p2, YemekTarif=@p3, Kategoriid=@p4, YemekResim=@p6 WHERE Yemekid=@p5", con))
                {
                    cmdUpd.Parameters.Add("@p1", SqlDbType.NVarChar, 100).Value = ad;
                    cmdUpd.Parameters.Add("@p2", SqlDbType.NVarChar).Value = TextBox2.Text;
                    cmdUpd.Parameters.Add("@p3", SqlDbType.NVarChar).Value = TextBox3.Text;
                    cmdUpd.Parameters.Add("@p4", SqlDbType.Int).Value = yeniKategoriId;
                    cmdUpd.Parameters.Add("@p5", SqlDbType.Int).Value = YemekId;
                    cmdUpd.Parameters.Add("@p6", SqlDbType.NVarChar, 300).Value = (object)yeniResimYolu ?? DBNull.Value;
                    cmdUpd.ExecuteNonQuery();
                }

                // 4) Kategori değiştiyse adetleri düzelt
                if (eskiKategoriId != yeniKategoriId)
                {
                    using (SqlCommand cmdDec = new SqlCommand(
                        "UPDATE Tbl_Kategoriler SET KategoriAdet = CASE WHEN KategoriAdet>0 THEN KategoriAdet-1 ELSE 0 END WHERE Kategoriid=@p1", con))
                    {
                        cmdDec.Parameters.Add("@p1", SqlDbType.Int).Value = eskiKategoriId;
                        cmdDec.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdInc = new SqlCommand(
                        "UPDATE Tbl_Kategoriler SET KategoriAdet = KategoriAdet+1 WHERE Kategoriid=@p1", con))
                    {
                        cmdInc.Parameters.Add("@p1", SqlDbType.Int).Value = yeniKategoriId;
                        cmdInc.ExecuteNonQuery();
                    }
                }
            }

            LblBilgi.ForeColor = System.Drawing.Color.Green;
            LblBilgi.Text = "Yemek güncellendi.";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlTransaction tr = con.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd0 = new SqlCommand("UPDATE Tbl_Yemekler SET Durum=0", con, tr))
                        cmd0.ExecuteNonQuery();

                    using (SqlCommand cmd1 = new SqlCommand("UPDATE Tbl_Yemekler SET Durum=1 WHERE Yemekid=@p1", con, tr))
                    {
                        cmd1.Parameters.Add("@p1", SqlDbType.Int).Value = YemekId;
                        cmd1.ExecuteNonQuery();
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    LblBilgi.ForeColor = System.Drawing.Color.Red;
                    LblBilgi.Text = "Günün yemeği ayarlanamadı.";
                    return;
                }
            }

            LblBilgi.ForeColor = System.Drawing.Color.Green;
            LblBilgi.Text = "Günün yemeği olarak ayarlandı.";
        }
    }
}
