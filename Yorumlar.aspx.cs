using System;
using System.Data;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public partial class Yorumlar : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Panel2.Visible = false;
                Panel4.Visible = false;

                // silme işlemi varsa önce uygula
                HandleDeleteFromQuery();
            }

            Listele();

            if (Request.QueryString["s"] == "1")
            {
                LblBilgi.ForeColor = System.Drawing.Color.Green;
                LblBilgi.Text = "Yorum silindi.";
            }
        }

        private void Listele()
        {
            // Onaylılar
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Yorumid, YorumAdSoyad FROM Tbl_Yorumlar WHERE YorumOnay=1 ORDER BY Yorumid DESC", con))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                DataList1.DataSource = dr;
                DataList1.DataBind();
            }

            // Onaysızlar
            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd2 = new SqlCommand(
                "SELECT Yorumid, YorumAdSoyad FROM Tbl_Yorumlar WHERE YorumOnay=0 ORDER BY Yorumid DESC", con))
            using (SqlDataReader dr2 = cmd2.ExecuteReader())
            {
                DataList2.DataSource = dr2;
                DataList2.DataBind();
            }
        }

        private void HandleDeleteFromQuery()
        {
            string islem = Request.QueryString["islem"];
            string idStr = Request.QueryString["Yorumid"];

            if (!string.Equals(islem, "sil", StringComparison.OrdinalIgnoreCase))
                return;

            if (!int.TryParse(idStr, out int yorumId))
            {
                LblBilgi.ForeColor = System.Drawing.Color.Red;
                LblBilgi.Text = "Geçersiz Yorumid.";
                return;
            }

            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Yorumlar WHERE Yorumid=@p1", con))
            {
                cmd.Parameters.Add("@p1", SqlDbType.Int).Value = yorumId;
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Yorumlar.aspx?s=1");
        }

        protected void Button1_Click(object sender, EventArgs e) => Panel2.Visible = true;
        protected void Button2_Click(object sender, EventArgs e) => Panel2.Visible = false;
        protected void Button3_Click1(object sender, EventArgs e) => Panel4.Visible = true;
        protected void Button4_Click(object sender, EventArgs e) => Panel4.Visible = false;
    }
}
