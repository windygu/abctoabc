using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Model;
using WebBasics.Utilities;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Articles
{
	public partial class ArticleInsert : PageAuth
	{
		public Guid? ChannelID;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ChannelID = RequestObject.ToNullableGuid("ChannelID");

			if (this.ChannelID != null)
			{
				this.Article_ChannelID.Value = this.ChannelID.Value.ToString();
				this.LblChannel.Text = xCmsService.GetChannelFamily(this.ChannelID.Value) ?? "";
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

			xArticleService.AddArticle(article);

			Response.Redirect("ArticleResult.aspx?action=1&id=" + article.ID);
		}
	}
}
