using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouTong.Model;
using YouTong.Common;

namespace YouTong.WebSite.Codes
{
	public class PageAuth : PageBase
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (this.IsAnonymous)
			{
				Response.Redirect("/Member/Login.aspx?back=" + HttpUtility.UrlEncode(Request.RawUrl));
			}
		}

		protected Guid UserID
		{
			get { return this.User.ID; }
		}

		protected string UserName
		{
			get { return this.User.UserName; }
		}

		protected IList<Child> GetChilds()
		{
			return UtFactory.Instance.ChildService.GetChildsByParent(this.UserID);
		}

		protected Child FirstChild
		{
			get
			{
				var childs = GetChilds();
				return childs.Count == 0 ? null : childs[0];
			}
		}
	}
}
