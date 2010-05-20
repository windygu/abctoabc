using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBasics.Cms.Common;
using WebBasics.Member.Common;
using WebBasics.Member.Model;
using YouTong.Common;

namespace YouTong.WebSite.Codes
{
	public class PageBase : Itfort.Web.BasePage
	{
		public MemberFactory xMemberFactory = MemberFactory.Instance;
		public CmsFactory xCmsFactory = CmsFactory.Instance;
		public UtFactory xUtFactory = UtFactory.Instance;

		public String BackUrl
		{
			get
			{
				var url = Request.QueryString["back"];
				if (url != null)
				{
					url = HttpUtility.UrlDecode(url);
				}
				return url;
			}
		}

		public String GetBackUrl(String defaultBack)
		{
			var url = this.BackUrl;
			if (String.IsNullOrEmpty(url))
			{
				if (String.IsNullOrEmpty(defaultBack)) defaultBack = "/";

				return defaultBack;
			}
			return url;
		}

		public void GoBackUrl()
		{
			this.GoBackUrl(null);
		}

		public void GoBackUrl(String defaultBack)
		{
			Response.Redirect(this.GetBackUrl(defaultBack));
		}

		public void GoReferrerUrl()
		{
			if (Request.UrlReferrer == null)
			{
				this.GoBackUrl(null);
			}
			else
			{
				this.GoBackUrl(Request.UrlReferrer.AbsoluteUri);
			}
		}

		public void SignIn(string username, string password, bool remember)
		{
			var uService = xMemberFactory.UserService;
			var user = uService.GetUser(username);

			if (user == null)
			{
				throw new Exception("登录帐户不存在");
			}

			if (String.Compare(user.Password, password, true) != 0)
			{
				throw new Exception("登录密码错误");
			}

			this.SignIn(user, remember);
		}

		public void SignIn(User user, bool remember)
		{
			MemberAction.SignIn(user, remember);
		}

		public void SignOut()
		{
			MemberAction.SignOut();
		}

		public Boolean IsAnonymous
		{
			get
			{
				return this.User == null ? true : false;
			}
		}

		public new User User
		{
			get
			{
				return MemberAction.GetUser();
			}
		}
	}
}
