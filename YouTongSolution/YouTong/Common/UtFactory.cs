using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTong.Common
{
	public class UtFactory
	{
		public static readonly UtFactory Instance = new UtFactory();

		public IChildService ChildService = new ChildService();

		public IActivityService ActivityService = new ActivityService();

		public IActivityJoinedService ActivityJoinedService = new ActivityJoinedService();

		public IActivityJoined2Service ActivityJoined2Service = new ActivityJoined2Service();
	}
}
