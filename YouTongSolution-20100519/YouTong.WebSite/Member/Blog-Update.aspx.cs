using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using Itfort.Web.Binder;

namespace YouTong.WebSite.Member
{
	public partial class Blog_Update : PageAuth
	{
		public Guid BlogID;
		public Article Article;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.BlogID = RequestObject.ToGuid("id");
			this.Article = xCmsFactory.ArticleService.GetArticle(this.BlogID);

			if (!this.IsPostBack)
			{
				this.Blog_Title.Text = this.Article.Title;
				this.Blog_Body.Text = this.Article.Body;
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var xArticle = ConverterFactory.ConvertTo<Article>(Request.Params);

			this.Article.Title = xArticle.Title;
			this.Article.Body = xArticle.Body;

			xCmsFactory.ArticleService.UpdateArticle(this.Article);
			Response.Redirect("../blogs/detail.aspx?id=" + Article.ID);
		}
	}
}
