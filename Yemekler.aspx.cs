using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class Yemekler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;
                Panel4.Visible = false;

                KategorileriDoldur();
                SilmeIsleminiYapQueryden();
            }

            YemekleriListele();

            // küçük mesajlar
            if (Request.QueryString["s"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Yemek silindi.";
            }
            else if (Request.QueryString["e"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Yemek eklendi.";
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

        private void YemekleriListele()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Yemekid, YemekAd FROM Tbl_Yemekler ORDER BY YemekAd", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }
        }

        private void SilmeIsleminiYapQueryden()
        {
            string islem = Request.QueryString["islem"];
            string idStr = Request.QueryString["Yemekid"];

            if (!string.Equals(islem, "sil", StringComparison.OrdinalIgnoreCase))
                return;

            if (!int.TryParse(idStr, out int yemekId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz yemek id.";
                return;
            }

            int kategoriId = 0;

            using (SqlConnection con = bgl.baglanti())
            {
                // 1) Bu yemeğin kategoriid'sini bul
                using (SqlCommand cmdGet = new SqlCommand(
                    "SELECT Kategoriid FROM Tbl_Yemekler WHERE Yemekid=@p1", con))
                {
                    cmdGet.Parameters.Add("@p1", SqlDbType.Int).Value = yemekId;
                    object val = cmdGet.ExecuteScalar();
                    if (val == null)
                    {
                        // zaten yoksa
                        Response.Redirect("Yemekler.aspx");
                        return;
                    }
                    kategoriId = Convert.ToInt32(val);
                }

                // 2) Yemeği sil
                using (SqlCommand cmdDel = new SqlCommand(
                    "DELETE FROM Tbl_Yemekler WHERE Yemekid=@p1", con))
                {
                    cmdDel.Parameters.Add("@p1", SqlDbType.Int).Value = yemekId;
                    cmdDel.ExecuteNonQuery();
                }

                // 3) Kategori adetini 1 azalt (negatif olmasın)
                using (SqlCommand cmdUpd = new SqlCommand(
                    "UPDATE Tbl_Kategoriler SET KategoriAdet = CASE WHEN KategoriAdet > 0 THEN KategoriAdet - 1 ELSE 0 END WHERE Kategoriid=@p1", con))
                {
                    cmdUpd.Parameters.Add("@p1", SqlDbType.Int).Value = kategoriId;
                    cmdUpd.ExecuteNonQuery();
                }
            }

            Response.Redirect("Yemekler.aspx?s=1");
        }

        protected void Button1_Click(object sender, EventArgs e) => Panel2.Visible = true;
        protected void Button2_Click(object sender, EventArgs e) => Panel2.Visible = false;
        protected void Button3_Click1(object sender, EventArgs e) => Panel4.Visible = true;
        protected void Button4_Click(object sender, EventArgs e) => Panel4.Visible = false;

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            string ad = TextBox1.Text.Trim();
            string malzeme = TextBox2.Text.Trim();
            string tarif = TextBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(ad))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Yemek adı boş olamaz.";
                return;
            }

            if (!int.TryParse(DropDownList1.SelectedValue, out int kategoriId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Kategori seçimi geçersiz.";
                return;
            }

            using (SqlConnection con = bgl.baglanti())
            {
                // 1) yemek ekle
                using (SqlCommand cmdIns = new SqlCommand(
                    "INSERT INTO Tbl_Yemekler (YemekAd, YemekMalzeme, YemekTarif, Kategoriid) VALUES (@p1,@p2,@p3,@p4)", con))
                {
                    cmdIns.Parameters.Add("@p1", SqlDbType.NVarChar, 100).Value = ad;
                    cmdIns.Parameters.Add("@p2", SqlDbType.NVarChar).Value = malzeme;
                    cmdIns.Parameters.Add("@p3", SqlDbType.NVarChar).Value = tarif;
                    cmdIns.Parameters.Add("@p4", SqlDbType.Int).Value = kategoriId;
                    cmdIns.ExecuteNonQuery();
                }

                // 2) kategori adet artır
                using (SqlCommand cmdUpd = new SqlCommand(
                    "UPDATE Tbl_Kategoriler SET KategoriAdet = KategoriAdet + 1 WHERE Kategoriid=@p1", con))
                {
                    cmdUpd.Parameters.Add("@p1", SqlDbType.Int).Value = kategoriId;
                    cmdUpd.ExecuteNonQuery();
                }
            }

            Response.Redirect("Yemekler.aspx?e=1");
        }
    }
}
