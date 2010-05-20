using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class MyChild : PageAuth
	{
		public Child Child;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Child = xUtFactory.ChildService.GetFirstChild(this.UserID);

			if (this.Child == null)
			{
				Response.Redirect("RegisterChild.aspx");
			}

			Response.Redirect("../Childs/Home.aspx?userid=" + this.UserID);
		}
	}
}
