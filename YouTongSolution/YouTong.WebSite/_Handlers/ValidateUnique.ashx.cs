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
            String result = "false";
            string action = RequestObject.ToString("action");
			var user = ConverterFactory.ConvertTo<User>(Request.Params, "User_");

            switch (action)
            {
                case "name":
                    if (!String.IsNullOrEmpty(user.UserName))
                    {
                        result = (!MemberFactory.Instance.UserService.ExistUserName(user.UserName)).ToString();
                    }
                    break;
                case "mobile":
                    if (!String.IsNullOrEmpty(user.Mobile))
                    {
                        result = (!MemberFactory.Instance.UserService.ExistMobile(user.Mobile)).ToString();
                    }
                    break;
                case "email":
                    if (!String.IsNullOrEmpty(user.Email))
                    {
                        result = (!MemberFactory.Instance.UserService.ExistEmail(user.Email)).ToString();
                    }
                    break;
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
