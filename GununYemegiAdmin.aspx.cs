using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class GununYemegiAdmin : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;

                // seçim işlemi varsa uygula
                HandleSelectFromQuery();
            }

            GununYemeginiYaz();
            Listele();

            if (Request.QueryString["sec"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Günün yemeği güncellendi.";
            }
        }

        private void Listele()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("SELECT Yemekid, YemekAd FROM Tbl_Yemekler ORDER BY YemekAd", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }
        }

        private void GununYemeginiYaz()
        {
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 YemekAd FROM Tbl_Yemekler WHERE Durum=1", con))
            {
                object val = cmd.ExecuteScalar();
                LblGununYemegi.Text = val == null ? "Seçilmedi" : val.ToString();
            }
        }

        private void HandleSelectFromQuery()
        {
            string islem = Request.QueryString["islem"];
            string idStr = Request.QueryString["Yemekid"];

            if (!string.Equals(islem, "sec", StringComparison.OrdinalIgnoreCase))
                return;

            if (!int.TryParse(idStr, out int yemekId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Yemekid.";
                return;
            }

            using (SqlConnection con = bgl.baglanti())
            using (SqlTransaction tr = con.BeginTransaction())
            {
                try
                {
                    using (SqlCommand cmd0 = new SqlCommand("UPDATE Tbl_Yemekler SET Durum=0", con, tr))
                        cmd0.ExecuteNonQuery();

                    using (SqlCommand cmd1 = new SqlCommand("UPDATE Tbl_Yemekler SET Durum=1 WHERE Yemekid=@p1", con, tr))
                    {
                        cmd1.Parameters.Add("@p1", SqlDbType.Int).Value = yemekId;
                        cmd1.ExecuteNonQuery();
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    LblBilgi.ForeColor = System.Drawing.Color.Red;
                    LblBilgi.Text = "Günün yemeği güncellenemedi.";
                    return;
                }
            }

            Response.Redirect("GununYemegiAdmin.aspx?sec=1");
        }

        protected void Button1_Click(object sender, EventArgs e) => Panel2.Visible = true;
        protected void Button2_Click(object sender, EventArgs e) => Panel2.Visible = false;
    }
}
