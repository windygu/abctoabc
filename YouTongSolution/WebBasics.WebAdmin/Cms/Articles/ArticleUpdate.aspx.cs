using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Model;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Articles
{
	public partial class ArticleUpdate : PageAuth
	{
		public Guid ArticleID;
		public Article Article;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ArticleID = RequestObject.ToGuid("id");
			this.Article = xArticleService.GetArticle(this.ArticleID);

			if (!this.IsPostBack)
			{
				this.Article_Title.Text = this.Article.Title;
				this.Article_Body.Text = this.Article.Body;
				this.Article_Summary.Text = this.Article.Summary;
				this.LblAddTime.Text = this.Article.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
				this.LblUpdateTime.Text = this.Article.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");

				if (this.Article.AuditStatus >= 0 && this.Article.AuditStatus <= 2)
				{
					this.Article_AuditStatus.SelectedValue = this.Article.AuditStatus.ToString();
				}

				if (this.Article.ChannelID.HasValue)
				{
					this.Article_ChannelID.Value = this.Article.ChannelID.Value.ToString();
					this.LblChannel.Text = xCmsService.GetChannelFamily(this.Article.ChannelID.Value) ?? "";
				}
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			Article article = ConverterFactory.ConvertTo<Article>(Request.Params, "Article_");

			if (article.ChannelID.HasValue)
			{
				if (!xChannelService.ExistsChannel(article.ChannelID.Value))
				{
					article.ChannelID = null;
				}
			}

			this.Article.Title = article.Title;
			this.Article.Body = article.Body;
			this.Article.Summary = article.Summary;

			xArticleService.UpdateArticle(this.Article);
			Response.Redirect("ArticleResult.aspx?action=2&id=" + this.Article.ID);
		}
	}
}
