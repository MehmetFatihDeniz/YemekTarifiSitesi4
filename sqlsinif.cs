using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace YemekTarifiSitesi4
{
    public class sqlsinif
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-CSBBP24\SQLEXPRESS;Initial Catalog=Dbo_yemektarifi; Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}