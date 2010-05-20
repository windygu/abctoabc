using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;

namespace YouTong
{
	public class FamilyMediaAction
	{
		public static IList<Channel> GetMediaCategories()
		{
			return CmsFactory.Instance.ChannelService.GetChildChannels(UtConfig.FamilyMediaChannelID);
		}
	}
}
