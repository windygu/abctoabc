using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.WebSite.Codes;
using Itfort.Web;

namespace YouTong.WebSite.Member
{
	public partial class ModifyPassword : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			try
			{
				String oldPassword = RequestObject.ToString("OldPassword");
				String newPassword = RequestObject.ToString("NewPassword");
				String newPassword2 = RequestObject.ToString("NewPassword");

				if (newPassword != newPassword2)
				{
					throw new Exception("两次输入的密码不一样");
				}

				xMemberFactory.UserService.ModifyPassword(this.UserName, oldPassword, newPassword);

				this.JsAlert("修改成功");
			}
			catch (Exception ex)
			{
				this.JsAlert(ex.Message);
			}
		}
	}
}
