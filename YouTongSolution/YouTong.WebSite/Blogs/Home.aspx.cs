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

namespace YouTong.WebSite.Blogs
{
	public partial class Home : PageBase
	{
		public Guid UserID;
		public IList<Article> Articles;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.UserID = RequestObject.ToGuid("userid");

			this.Articles = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, this.UserID, 1, 100);
			this.Repeater1.DataSource = this.Articles;

			this.DataBind();
		}
	}
}
