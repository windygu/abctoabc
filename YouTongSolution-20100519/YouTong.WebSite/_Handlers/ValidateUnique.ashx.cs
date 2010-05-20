using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Itfort.Web.Binder;
using WebBasics.Member.Model;
using YouTong.WebSite.Codes;
using Itfort.Web;
using WebBasics.Member.Common;

namespace YouTong.WebSite._Handlers
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class ValidateUnique : HttpHandlerBase
	{

		public override void ProcessRequest(HttpContext context)
		{
			base.ProcessRequest(context);

			var user = ConverterFactory.ConvertTo<User>(Request.Params, "User_");

			String result = "false";
			if (!String.IsNullOrEmpty(user.UserName))
			{
				result = (!MemberFactory.Instance.UserService.ExistUserName(user.UserName)).ToString();
			}
			else if (!String.IsNullOrEmpty(user.Email))
			{
				result = (!MemberFactory.Instance.UserService.ExistEmail(user.Email)).ToString();
			}
			else if (!String.IsNullOrEmpty(user.Mobile))
			{
				result = (!MemberFactory.Instance.UserService.ExistMobile(user.Mobile)).ToString();
			}

			Response.Write(result.ToLower());
		}

		public override bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
