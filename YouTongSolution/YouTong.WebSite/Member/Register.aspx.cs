using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Member.Model;
using WebBasics.Utilities;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class Register : PageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			if (!VerifyCodeAction.Validate("Register", Request["VerifyCode"]))
			{
				this.JsAlert("验证码不正确");
				return;
			}

			var user = ConverterFactory.ConvertTo<User>(Request.Form, "User_");

			user.Password = user.Password.TrimEnd().ToLower();
			// 存储MD5加密密码
			user.PasswordHash = MD5Hasher.GetMD5HashString(user.Password);

			if (user.Birthday == DateTime.MinValue) user.Birthday = DateTime.Parse("1899-1-1");

			try
			{
				var xUserService = xMemberFactory.UserService;
				xUserService.AddUser(user);

				DNT.Regedit(user.UserName, user.Password);
			}
			catch (Exception ex)
			{
				this.JsAlert(ex.Message);
				return;
			}

			this.SignIn(user, false);

			var hasChild = RequestObject.ToBoolean("User_HasChild");

			if (hasChild)
			{
				Response.Redirect("RegisterChild.aspx");
			}
			else
			{
				Response.Redirect("Register-Completed.aspx");
			}
		}
	}
}
