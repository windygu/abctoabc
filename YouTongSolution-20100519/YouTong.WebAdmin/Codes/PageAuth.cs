using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTong.WebAdmin
{
	public class PageAuth : Itfort.Web.BasePage
	{
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			var obj = Session["admin-user"];
			if (obj == null || !(Boolean)obj)
			{
				Response.Redirect("/admin/signin.aspx");
			}
		}
	}
}
