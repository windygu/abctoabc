using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTong.Data;

namespace YouTong.Common
{
	public class BusinessBase
	{
		public DbChild dbChild = new DbChild();
		public DbSchool dbSchool = new DbSchool();
		public DbActivity dbActivity = new DbActivity();
		public DbActivityJoined dbActivityJoined = new DbActivityJoined();
		public DbActivityJoined2 dbActivityJoined2 = new DbActivityJoined2();
	}
}
