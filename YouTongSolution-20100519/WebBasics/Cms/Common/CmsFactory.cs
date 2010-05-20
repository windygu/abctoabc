using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBasics.Cms.Common
{
	public class CmsFactory
	{
		public static CmsFactory Instance = new CmsFactory();

		public ICmsService CmsService = new CmsService();

		public IChannelService ChannelService = new ChannelService();

		public IArticleService ArticleService = new ArticleService();

		public IAnyFileService AnyFileService = new AnyFileService();
	}
}
