using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Common;
using WebBasics.Cms.Data;
using WebBasics.Cms.Model;
using WebBasics.Utilities;

namespace WebBasics.Cms
{
	public class CmsService : BusinessBase, ICmsService
	{
		public String GetChannelFamily(Guid channelId)
		{
			var channel = dbChannel.GetChannel(channelId);

			if (channel != null)
			{
				List<Guid> channelIds = new List<Guid>();

				if (!String.IsNullOrEmpty(channel.Family))
				{
					var array = channel.Family.Split(',');

					foreach (var item in array)
					{
						channelIds.Add(new Guid(item));
					}
				}
				else
				{
					channelIds.Add(channel.ID);
				}

				var channels = dbChannel.GetChannels(channelIds.ToArray());

				var channelDict = WbUtility.ToDictinary<Guid, Channel>("ID", channels);

				String family = null;
				foreach (var item in channelIds)
				{
					if (channelDict.ContainsKey(item))
					{
						if (family == null)
						{
							family = channelDict[item].DisplayName;
						}
						else
						{
							family += " | " + channelDict[item].DisplayName;
						}
					}
				}

				return family;
			}
			else
			{
				return null;
			}
		}
	}
}
