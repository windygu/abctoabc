using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web.Binder;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Model;

namespace YouTong.WebSite.Blogs
{
	public partial class Blog_Write : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var blog = ConverterFactory.ConvertTo<Article>(Request.Params, "Blog_");
			blog.UserID = this.UserID;
			blog.ChannelID = UtConfig.BlogChannelID;
			xCmsFactory.ArticleService.AddArticle(blog);
			Response.Redirect("../blogs/detail.aspx?id=" + blog.ID);
		}
	}
}
