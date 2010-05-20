using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class Index : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this.User_Name.Text = this.User.Name;
				this.User_NickName.Text = this.User.NickName;
				this.User_Mobile.Text = this.User.Mobile;

				try
				{
					this.User_Gender.SelectedValue = this.User.Gender.ToString();
				}
				catch
				{

				}
			}

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			try
			{
				var user = xMemberFactory.UserService.GetUser(this.UserName);

				user.Name = RequestObject.ToString("User_Name");
				user.NickName = RequestObject.ToString("User_NickName");
				user.Mobile = RequestObject.ToString("User_Mobile");
				user.Gender = (byte)RequestObject.ToInt32("User_Gender");

				xMemberFactory.UserService.UpdateUser(user);
				MemberAction.SetUser(user);
				this.JsAlert("修改成功");
			}
			catch (Exception ex)
			{
				this.JsAlert(ex.Message);
			}
		}
	}
}
