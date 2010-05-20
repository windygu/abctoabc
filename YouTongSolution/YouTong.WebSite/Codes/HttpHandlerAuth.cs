using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTong.WebSite.Codes
{
	public class HttpHandlerAuth : HttpHandlerBase
	{
		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);

			if (UserSession.IsAnonymous)
			{
				throw new Exception("没有权限");
			}
		}
	}
}
