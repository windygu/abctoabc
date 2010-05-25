using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoft.Data;

namespace YouTong.Data
{
	public class DbBase
	{
		protected DbSession dbSession = new DbSession("ut");
	}
}
