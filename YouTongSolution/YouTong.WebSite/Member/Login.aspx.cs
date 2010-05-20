using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web.Binder;
using WebBasics.Member.Model;
using YouTong.WebSite.Codes;
using Itfort.Web;

namespace YouTong.WebSite.Member
{
	public partial class Login : PageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			try
			{
				var username = RequestObject.ToString("User_UserName");
				var password = RequestObject.ToString("User_Password");
				var remember = RequestObject.ToBoolean("User_Remember");

				this.SignIn(username, password, remember);
			}
			catch (Exception ex)
			{
				this.JsAlert(ex.Message);
				return;
			}

			this.GoBackUrl();
		}
	}
}
