using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.Common;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Activities.Disney
{
	public partial class Expo : PageBase
	{
		public ActivityJoined ActivityJoined;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				if (!this.IsAnonymous)
				{
					this.ActivityJoined = xUtFactory.ActivityJoinedService.GetActivityJoined(UtConfig.DisneyExpoActivityID, this.User.ID);
				}
			}
		}

		protected void BtnSignIn_Click(object sender, EventArgs e)
		{
			try
			{
				var username = RequestObject.ToString("User_UserName");
				var password = RequestObject.ToString("User_Password");

				this.SignIn(username, password, false);

				Response.Redirect("Expo.aspx");
			}
			catch
			{
				this.LiInfo.Text = "用户名或密码错误";
			}
		}

		protected Child GetFirstChild()
		{
			var childs = UtFactory.Instance.ChildService.GetChildsByParent(this.User.ID);
			return childs.Count == 0 ? null : childs[0];
		}
	}
}
