using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebBasics.Member.Common;
using WebBasics.Member.Model;
using YouTong.Model;

namespace YouTong
{
	public class MemberAction
	{
		/// <summary>
		/// 登录系统
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public static User SignIn(String username, String password)
		{
			var xUserService = MemberFactory.Instance.UserService;

			var user = xUserService.GetUser(username);
			if (user != null)
			{
				//var md5Password = Itfort.Encrypt.GetMD5Hash(password);
				if (user.Password == password)
				{
					SignIn(user, false);
				}
				else
				{
					user = null;
				}
			}
			else
			{
				user = null;
			}

			return user;
		}

		/// <summary>
		/// 登录系统
		/// </summary>
		/// <param name="user"></param>
		/// <param name="remember"></param>
		public static void SignIn(User user, bool remember)
		{
			var Session = HttpContext.Current.Session;
			var Response = HttpContext.Current.Response;

			Session[UtConfig.SessionKey_User] = user;

			HttpCookie cookieUserName = new HttpCookie(UtConfig.CookieKeyUserName);
			cookieUserName.Value = user.UserName;
			cookieUserName.Domain = UtConfig.Domain;
			cookieUserName.Path = "/";

			HttpCookie cookiePassword = new HttpCookie(UtConfig.CookieKeyPassword);
			cookiePassword.Value = user.Password;
			cookiePassword.Domain = UtConfig.Domain;
			cookiePassword.Path = "/";

			HttpCookie cookieClientUserName = new HttpCookie(UtConfig.CookieKeyClientUserName);
			cookieClientUserName.Value = HttpUtility.UrlEncode(user.UserName);
			cookieClientUserName.Domain = UtConfig.Domain;
			cookieClientUserName.Path = "/";

			if (remember)
			{
				cookieUserName.Expires = DateTime.Now.AddDays(365);
				cookiePassword.Expires = DateTime.Now.AddDays(365);
				cookieClientUserName.Expires = DateTime.Now.AddDays(365);
			}

			Response.Cookies.Add(cookieUserName);
			Response.Cookies.Add(cookiePassword);
			Response.Cookies.Add(cookieClientUserName);
		}

		/// <summary>
		/// 注销登陆
		/// </summary>
		public static void SignOut()
		{
			var Session = HttpContext.Current.Session;
			var Response = HttpContext.Current.Response;
			var Request = HttpContext.Current.Request;

			Session.Clear();
			Session.Abandon();
			Request.Cookies.Clear();

			HttpCookie cookieUserName = new HttpCookie(UtConfig.CookieKeyUserName);
			cookieUserName.Domain = UtConfig.Domain;
			cookieUserName.Path = "/";
			cookieUserName.Expires = DateTime.Now.AddYears(-1);
			HttpCookie cookiePassword = new HttpCookie(UtConfig.CookieKeyPassword);
			cookieUserName.Domain = UtConfig.Domain;
			cookieUserName.Path = "/";
			cookiePassword.Expires = DateTime.Now.AddYears(-1);
			HttpCookie cookieClientUserName = new HttpCookie(UtConfig.CookieKeyClientUserName);
			cookieClientUserName.Domain = UtConfig.Domain;
			cookieClientUserName.Path = "/";
			cookieClientUserName.Expires = DateTime.Now.AddYears(-1);

			Response.Cookies.Add(cookieUserName);
			Response.Cookies.Add(cookiePassword);
			Response.Cookies.Add(cookieClientUserName);
		}

		/// <summary>
		/// 获取当前用户
		/// </summary>
		/// <returns></returns>
		public static User GetUser()
		{
			var Session = HttpContext.Current.Session;
			var Response = HttpContext.Current.Response;
			var Request = HttpContext.Current.Request;

			var uService = MemberFactory.Instance.UserService;
			var objUser = Session[UtConfig.SessionKey_User];
			var user = objUser as User;

			if (user == null)
			{
				HttpCookie cookieUserName = Request.Cookies[UtConfig.CookieKeyUserName];
				HttpCookie cookiePassword = Request.Cookies[UtConfig.CookieKeyPassword];
				if (cookieUserName != null && cookiePassword != null)
				{
					try
					{
						var cookieUser = uService.GetUser(cookieUserName.Value);
						if (cookieUser != null)
						{
							if (cookieUser.Password == cookieUser.Password)
							{
								user = cookieUser;
								SignIn(user, false);
							}
						}
					}
					catch { }
				}
			}

			return user;
		}

		/// <summary>
		/// 设置用户到会话
		/// </summary>
		/// <param name="user"></param>
		public static void SetUser(User user)
		{
			var Session = HttpContext.Current.Session;
			Session[UtConfig.SessionKey_User] = user;
		}
	}
}
