using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using WebBasics.Member.Model;

namespace YouTong.WebSite.Blogs
{
	public partial class Detail : PageBase
	{
		public Guid BlogID;
		public Article Blog;
		public User Owner;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.BlogID = RequestObject.ToGuid("id");
			this.Blog = xCmsFactory.ArticleService.GetArticle(BlogID);
		}
	}
}
