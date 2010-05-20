using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBasics.Cms.Common
{
	public interface ICmsService
	{
		String GetChannelFamily(Guid channelId);
	}
}
