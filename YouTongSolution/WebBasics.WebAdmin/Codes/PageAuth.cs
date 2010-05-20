using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBasics.Cms.Common;

namespace WebBasics.WebAdmin
{
	public class PageAuth : Itfort.Web.BasePage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			var obj = Session["admin-user"];
			if (obj == null || !(Boolean)obj)
			{
				Response.Redirect("/admin/signin.aspx");
			}
		}

		public CmsFactory xCmsFactory = new CmsFactory();

		public ICmsService xCmsService;
		public IChannelService xChannelService;
		public IArticleService xArticleService;

		public PageAuth()
		{
			this.xCmsService = xCmsFactory.CmsService;
			this.xChannelService = xCmsFactory.ChannelService;
			this.xArticleService = xCmsFactory.ArticleService;
		}
	}
}
