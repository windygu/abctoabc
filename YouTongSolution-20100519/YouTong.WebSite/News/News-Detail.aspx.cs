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
	public partial class News_Detail : PageBase
	{
		public Guid NewsID;
		public Article News;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.NewsID = RequestObject.ToGuid("id");
			this.News = xCmsFactory.ArticleService.GetArticle(NewsID);
		}
	}
}
