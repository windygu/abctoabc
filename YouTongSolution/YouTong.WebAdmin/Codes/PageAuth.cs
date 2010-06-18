using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Itfort.Web;

namespace YouTong.WebAdmin
{
	public class PageAuth : Itfort.Web.BasePage
	{
        public Int32 PageIndex;
        public Int32 PageSize = 10;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

            PageIndex = RequestObject.ToInt32("pIndex");
            if (PageIndex == 0)
                PageIndex = 1;

			var obj = Session["admin-user"];
			if (obj == null || !(Boolean)obj)
			{
				Response.Redirect("/admin/signin.aspx");
			}
		}
	}
}
