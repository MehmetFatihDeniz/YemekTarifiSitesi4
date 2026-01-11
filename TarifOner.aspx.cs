using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace YemekTarifiSitesi4
{
    public partial class TarifOner : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Request.QueryString["ok"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Tarifiniz alınmıştır. Teşekkür ederiz. Admin onayından sonra yayınlanacaktır.";
            }
        }

        protected void BtnTarifOner_Click(object sender, EventArgs e)
        {
            string ad = TxtTarifAd.Text.Trim();
            string malzeme = TxtMalzemeler.Text.Trim();
            string yapilis = TxtYapilis.Text.Trim();
            string sahip = TxtTarifOneren.Text.Trim();
            string mail = TxtMailAdresi.Text.Trim();

            // Basit validasyon
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(malzeme) ||
                string.IsNullOrWhiteSpace(yapilis) || string.IsNullOrWhiteSpace(sahip) ||
                string.IsNullOrWhiteSpace(mail))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Lütfen tüm alanları doldurun.";
                return;
            }

            // Mail kontrolü (basit)
            if (!Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçerli bir mail adresi girin.";
                return;
            }

            // Resim opsiyonel
            string resimYolu = null;
            if (FileUpload1.HasFile)
            {
                string ext = Path.GetExtension(FileUpload1.FileName).ToLowerInvariant();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".webp")
                {
                    LblBilgi.ForeColor = System.Drawing.Color.Red;
                    LblBilgi.Text = "Sadece .jpg / .png / .webp dosyası yükleyebilirsiniz.";
                    return;
                }

                string dosyaAdi = Guid.NewGuid().ToString("N") + ext;
                string fizikselYol = Server.MapPath("~/resimler/" + dosyaAdi);
                FileUpload1.SaveAs(fizikselYol);
                resimYolu = "~/resimler/" + dosyaAdi;
            }

            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Tbl_Tarifler
                (TarifAd, TarifMalzeme, TarifYapilis, TarifResim, TarifSahip, TarifSahipMail, TarifDurum)
                VALUES (@t1,@t2,@t3,@t4,@t5,@t6,@t7)", con))
            {
                cmd.Parameters.Add("@t1", SqlDbType.NVarChar, 100).Value = ad;
                cmd.Parameters.Add("@t2", SqlDbType.NVarChar).Value = malzeme;
                cmd.Parameters.Add("@t3", SqlDbType.NVarChar).Value = yapilis;
                cmd.Parameters.Add("@t4", SqlDbType.NVarChar, 300).Value = (object)resimYolu ?? DBNull.Value;
                cmd.Parameters.Add("@t5", SqlDbType.NVarChar, 80).Value = sahip;
                cmd.Parameters.Add("@t6", SqlDbType.NVarChar, 120).Value = mail;
                cmd.Parameters.Add("@t7", SqlDbType.Bit).Value = false; // admin onayı beklesin

                cmd.ExecuteNonQuery();
            }

            // tekrar insert olmasın diye redirect
            Response.Redirect("TarifOner.aspx?ok=1");
        }
    }
}
