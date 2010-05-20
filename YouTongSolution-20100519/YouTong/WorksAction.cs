using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;

namespace YouTong
{
	public class WorksAction
	{
		public static IList<Channel> GetWorksCategories()
		{
			return CmsFactory.Instance.ChannelService.GetChildChannels(UtConfig.WorksChannelID);
		}
	}
}
