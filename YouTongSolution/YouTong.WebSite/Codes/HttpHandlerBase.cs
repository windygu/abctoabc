using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace YouTong.WebSite.Codes
{
	public abstract class HttpHandlerBase : IHttpHandler, IReadOnlySessionState
	{
		public HttpRequest Request;
		public HttpResponse Response;
		public HttpServerUtility Server;
		public HttpSessionState Session;

		#region IHttpHandler 成员

		public virtual bool IsReusable
		{
			get { return false; }
		}

		public virtual void ProcessRequest(HttpContext context)
		{
			Request = context.Request;
			Response = context.Response;
			Server = context.Server;
			Session = context.Session;

			Response.ContentType = "text/html";
		}

		#endregion
	}
}
