using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;

namespace WebBasics.WebAdmin
{
	public partial class SignIn : BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var username = RequestObject.ToString("User_UserName").ToLower();
			var password = RequestObject.ToString("User_password").ToLower();

			if (String.Compare(username, "admin", true) == 0 && String.Compare(password, "admin", true) == 0)
			{
				Session["admin-user"] = true;

				Response.Redirect("Default.aspx");
			}
			else
			{
				this.JsAlert("登陆失败");
			}
		}
	}
}
