using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace YouTong.WebSite._Handlers
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class Login : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			var Request = context.Request;
			var username = Request.QueryString["username"];
			var password = Request.QueryString["password"];
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
