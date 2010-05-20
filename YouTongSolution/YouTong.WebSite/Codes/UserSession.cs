using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBasics.Member.Model;

namespace YouTong.WebSite.Codes
{
	public class UserSession
	{
		public static Boolean IsAnonymous
		{
			get
			{
				return User == null ? true : false;
			}
		}

		public static User User
		{
			get
			{
				return MemberAction.GetUser();
			}
		}

		public static Guid UserID
		{
			get { return User.ID; }
		}

		public static string UserName
		{
			get { return User.UserName; }
		}
	}
}
