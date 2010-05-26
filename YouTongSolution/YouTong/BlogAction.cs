using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;

namespace YouTong
{
	/// <summary>
	/// 博客
	/// </summary>
	public class BlogAction
	{
		/// <summary>
		/// 官方分类
		/// </summary>
		/// <returns></returns>
		public static IList<Channel> GetOfficialCategories()
		{
			return CmsFactory.Instance.ChannelService.GetChildChannels(UtConfig.BlogChannelID);
		}
	}
}
