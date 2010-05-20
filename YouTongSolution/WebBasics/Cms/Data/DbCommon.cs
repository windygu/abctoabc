using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;

namespace WebBasics.Cms.Data
{
	public class DbCommon
	{
		DbSession dbSession = new DbSession("wbcms");

		public Boolean Exists<T>(Guid id) where T : Entity
		{
			return dbSession.Exists<T>(id);
		}

		public Boolean Exists<T>(String fieldName, object fieldValue) where T : Entity
		{
			return dbSession.Exists<T>(new Field<T>(fieldName) == fieldValue);
		}
	}
}
