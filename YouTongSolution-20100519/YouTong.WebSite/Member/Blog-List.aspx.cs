using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class Blog_List : PageAuth
	{
		public IList<Article> Articles;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Articles = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, this.UserID, 1, 100);
			this.Repeater1.DataSource = this.Articles;
			this.DataBind();
		}
	}
}
