using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.News
{
	public partial class News_List : PageBase
	{
		public Guid ChannelID;
		public IList<Article> Articles;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ChannelID = RequestObject.ToGuid("id");

			this.Articles = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, 1, 100);
			this.Repeater1.DataSource = this.Articles;

			this.DataBind();
		}
	}
}
