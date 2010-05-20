using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBasics.Cms.Common;

namespace WebBasics.WebAdmin.Cms.Codes
{
	public class PageBase : PageAuth
	{
		public CmsFactory xCmsFactory = new CmsFactory();

		public ICmsService xCmsService;
		public IChannelService xChannelService;
		public IArticleService xArticleService;

		public PageBase()
		{
			this.xCmsService = xCmsFactory.CmsService;
			this.xChannelService = xCmsFactory.ChannelService;
			this.xArticleService = xCmsFactory.ArticleService;
		}
	}
}
