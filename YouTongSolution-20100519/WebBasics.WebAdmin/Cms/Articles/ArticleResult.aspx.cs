using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Articles
{
	public partial class ArticleResult : PageAuth
	{
		public Int32 Action = 0;
		public Guid ArticleID;
		public Article Article;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Action = RequestObject.ToInt32("action");
			this.ArticleID = RequestObject.ToGuid("id");
			this.Article = xArticleService.GetArticle(this.ArticleID);
		}
	}
}
