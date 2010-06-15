using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using WebBasics.Member.Model;
using YouTong.WebSite.Codes;
using MySoft.Data;

namespace YouTong.WebSite.Blogs
{
    public partial class Home : PagingBase
    {
        public Guid UserID;
        public IList<Article> Articles;        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");

            this.Articles = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, this.UserID, PageIndex, PageSize);
            int rowCount = xCmsFactory.ArticleService.GetArticleCount(UtConfig.BlogChannelID, true, this.UserID);
            this.rp_Blogs.DataSource = this.Articles;


            IDataPage page = new DataPage(PageSize);
            page.CurrentPageIndex = PageIndex;
            page.RowCount = rowCount;
            MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                string.Format("Home.aspx?userid={0}&pIndex=$Page", UserID));
            hPager.Style = HtmlPagerStyle.Custom;
            this.lt_Page.Text = hPager.ToString();


            this.DataBind();
        }
    }
}
