﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using WebBasics.Member.Common;
using WebBasics.Member.Model;
using YouTong.Model;
using YouTong.Common;

namespace YouTong.WebSite.Codes
{
	public class DataCache
	{
		public static User GetUser(Guid userId)
		{
			var key = "user_" + userId;
			var obj = HttpRuntime.Cache.Get(key);

			if (obj == null)
			{
				var user = MemberFactory.Instance.UserService.GetUser(userId);
				if (user != null)
				{
					HttpRuntime.Cache.Insert(key, user, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 5, 0));
					return user;
				}
				else
				{
					return null;
				}
			}

			return (User)obj;
		}

		public static Child GetChild(Guid userId)
		{
			var key = "child_" + userId;
			var obj = HttpRuntime.Cache.Get(key);

			if (obj == null)
			{
				var child = UtFactory.Instance.ChildService.GetFirstChild(userId);
				if (child != null)
				{
					HttpRuntime.Cache.Insert(key, child, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 5, 0));
					return child;
				}
				else
				{
					return null;
				}
			}

			return (Child)obj;
		}

		public static String GetChildNameByUserID(Guid userId)
		{
			var child = GetChild(userId);

			return child == null ? "" : child.Name;
		}

		public static String GetSchoolNameByUserID(Guid userId)
		{
			var child = GetChild(userId);

			if (child == null) return "";

			return "";
		}

		public static String GetHeadPicture(String headPicture)
		{
			if (String.IsNullOrEmpty(headPicture))
			{
				return "/images/headpic.gif";
			}
			else
			{
				return headPicture;
			}
		}
	}
}
