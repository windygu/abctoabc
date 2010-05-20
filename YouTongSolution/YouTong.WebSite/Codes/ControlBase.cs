using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBasics.Member.Model;

namespace YouTong.WebSite.Codes
{
	public class ControlBase : System.Web.UI.UserControl
	{
		public Boolean IsAnonymous
		{
			get
			{
				return this.User == null ? true : false;
			}
		}

		public User User
		{
			get
			{
				return MemberAction.GetUser();
			}
		}
	}
}
