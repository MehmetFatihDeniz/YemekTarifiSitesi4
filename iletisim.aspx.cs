using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace YemekTarifiSitesi4
{
    public partial class iletisim : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Mesajlar (MesajGonderen, MesajBaslik, MesajMail, Mesajicerik) values(@p1, @p2, @p3, @p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtGonderen.Text);
            komut.Parameters.AddWithValue("@p2", TxtBaslık.Text);
            komut.Parameters.AddWithValue("@p3", TxtMail.Text);
            komut.Parameters.AddWithValue("@p4", TxtMesaj.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Response.Write("Mesajınız Gönderildi");
            TxtGonderen.Text = "";
            TxtBaslık.Text = "";
            TxtMail.Text = "";
            TxtMesaj.Text = "";
        }
    }
}
