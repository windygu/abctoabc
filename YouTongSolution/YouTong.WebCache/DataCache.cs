﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using WebBasics.Member.Common;
using WebBasics.Member.Model;
using YouTong.Common;
using YouTong.Model;

namespace YouTong.WebCache
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

		public static void AddToCache(User user)
		{
			var key = "user_" + user.ID;

			HttpRuntime.Cache.Insert(key, user, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0));
		}

		public static Child GetChild(Guid userId)
		{
			var key = "child_" + userId;
			var obj = HttpRuntime.Cache.Get(key);

			Child child;
			if (obj == null)
			{
				child = UtFactory.Instance.ChildService.GetFirstChild(userId);
				if (child != null)
				{
					HttpRuntime.Cache.Insert(key, child, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 10, 0));
					return child;
				}
				else
				{
					child = new Child();

					return child;
				}
			}

			child = (Child)obj;
			if (child.ID == Guid.Empty) return null;
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
