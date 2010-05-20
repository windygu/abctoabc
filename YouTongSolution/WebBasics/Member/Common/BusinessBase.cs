using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Member.Data;

namespace WebBasics.Member.Common
{
	public class BusinessBase
	{
		public DbCommon dbCommon = new DbCommon();
		public DbUser dbUser = new DbUser();
	}
}
