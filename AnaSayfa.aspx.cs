using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace YemekTarifiSitesi4
{
    public partial class _Default : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();

        private const int PageSize = 5;

        private int CurrentPage
        {
            get => ViewState["CurrentPage"] == null ? 0 : (int)ViewState["CurrentPage"];
            set => ViewState["CurrentPage"] = value;
        }

        private string SearchTerm
        {
            get => ViewState["SearchTerm"] == null ? "" : ViewState["SearchTerm"].ToString();
            set => ViewState["SearchTerm"] = value ?? "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // İlk açılışta arama varsa al
                string q = Request.QueryString["q"];
                if (!string.IsNullOrWhiteSpace(q))
                {
                    SearchTerm = q.Trim();
                    TxtAra.Text = SearchTerm;
                }

                CurrentPage = 0;
                BindData();
            }
        }

        private void BindData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = bgl.baglanti())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT
                    Yemekid,
                    YemekAd,
                    LEFT(YemekMalzeme, 180) AS YemekMalzeme,
                    LEFT(YemekTarif, 220) AS YemekTarif,
                    YemekTarih,
                    YemekPuan
                FROM Tbl_Yemekler
                WHERE (@q = '' OR YemekAd LIKE '%' + @q + '%')
                ORDER BY Yemekid DESC", con))
            {
                cmd.Parameters.Add("@q", SqlDbType.NVarChar, 100).Value = SearchTerm;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            // Bilgi mesajı
            if (dt.Rows.Count == 0)
            {
                LabelBilgi.ForeColor = System.Drawing.Color.OrangeRed;
                LabelBilgi.Text = "Sonuç bulunamadı.";
            }
            else
            {
                LabelBilgi.Text = "";
            }

            // Sayfalama
            PagedDataSource pds = new PagedDataSource
            {
                DataSource = dt.DefaultView,
                AllowPaging = true,
                PageSize = PageSize
            };

            int pageCount = pds.PageCount;
            if (pageCount == 0) pageCount = 1;

            // sınır kontrol
            if (CurrentPage < 0) CurrentPage = 0;
            if (CurrentPage >= pds.PageCount) CurrentPage = Math.Max(0, pds.PageCount - 1);

            pds.CurrentPageIndex = CurrentPage;

            DataList2.DataSource = pds;
            DataList2.DataBind();

            LnkPrev.Enabled = !pds.IsFirstPage;
            LnkNext.Enabled = !pds.IsLastPage;
            LblSayfa.Text = (CurrentPage + 1) + " / " + pageCount;
        }

        protected void BtnAra_Click(object sender, EventArgs e)
        {
            SearchTerm = TxtAra.Text.Trim();
            CurrentPage = 0;
            BindData();
        }

        protected void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAra.Text = "";
            SearchTerm = "";
            CurrentPage = 0;
            BindData();
        }

        protected void LnkPrev_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            BindData();
        }

        protected void LnkNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            BindData();
        }
    }
}
