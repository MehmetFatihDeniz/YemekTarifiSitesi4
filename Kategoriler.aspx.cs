using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class Kategoriler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;
                Panel4.Visible = false;

                // Silme işlemi QueryString ile gelirse
                HandleDeleteFromQuery();
            }

            // Liste her durumda güncel gelsin
            Listele();
        }

        private void HandleDeleteFromQuery()
        {
            string islem = Request.QueryString["islem"];
            string idStr = Request.QueryString["Kategoriid"];

            if (!string.Equals(islem, "sil", StringComparison.OrdinalIgnoreCase))
                return;

            if (!int.TryParse(idStr, out int kategoriId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz kategori id.";
                return;
            }

            // FK (yemekler) kontrolü: bağlı yemek varsa silme
            using (SqlConnection con = bgl.baglanti())
            {
                // Bu kategoriye bağlı yemek var mı?
                using (SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Tbl_Yemekler WHERE Kategoriid=@p1", con))
                {
                    cmdCount.Parameters.Add("@p1", SqlDbType.Int).Value = kategoriId;
                    int adet = Convert.ToInt32(cmdCount.ExecuteScalar());

                    if (adet > 0)
                    {
                        LblBilgi.ForeColor = System.Drawing.Color.Red;
                        LblBilgi.Text = "Bu kategoriye bağlı yemekler var. Önce yemekleri silmelisin.";
                        return;
                    }
                }

                // Kategoriyi sil
                using (SqlCommand cmdDel = new SqlCommand(
                    "DELETE FROM Tbl_Kategoriler WHERE Kategoriid=@p1", con))
                {
                    cmdDel.Parameters.Add("@p1", SqlDbType.Int).Value = kategoriId;
                    cmdDel.ExecuteNonQuery();
                }
            }

            // Aynı silme tekrar tetiklenmesin
            Response.Redirect("Kategoriler.aspx?s=1");
        }

        private void Listele()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Kategoriid, KategoriAd, KategoriAdet FROM Tbl_Kategoriler ORDER BY KategoriAd", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }

            // Silme sonrası küçük başarı mesajı
            if (Request.QueryString["s"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Kategori silindi.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e) => Panel2.Visible = true;
        protected void Button2_Click(object sender, EventArgs e) => Panel2.Visible = false;
        protected void Button3_Click(object sender, EventArgs e) => Panel4.Visible = true;
        protected void Button4_Click(object sender, EventArgs e) => Panel4.Visible = false;

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            string ad = TextBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(ad))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Kategori adı boş olamaz.";
                return;
            }

            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Tbl_Kategoriler (KategoriAd) VALUES (@p1)", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.NVarChar, 100).Value = ad;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Kategoriler.aspx?e=1");
        }
    }
}
