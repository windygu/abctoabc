using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBasics.Cms.Data;

namespace WebBasics.Cms.Common
{
	public class BusinessBase
	{
		public DbCommon dbCommon = new DbCommon();
		public DbChannel dbChannel = new DbChannel();
		public DbArticle dbArticle = new DbArticle();
		public DbAnyFile dbAnyFile = new DbAnyFile();
	}
}
