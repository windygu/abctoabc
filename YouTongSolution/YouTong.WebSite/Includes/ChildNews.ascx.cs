using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace YouTong.WebSite.Includes
{
    public partial class ChildNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //优童新闻
            var huodongNews = 
                WebBasics.Cms.Common.CmsFactory.Instance.ArticleService.GetArticles(
                new Guid("7601789d-109d-9c32-f10f-eba23944a4cd"), true, 1, 5);
            this.rp_ChildNews.DataSource = huodongNews;
            this.rp_ChildNews.DataBind();
        }
    }
}