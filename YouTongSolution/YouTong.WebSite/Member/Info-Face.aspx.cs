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
	public partial class Info_Face : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var action = RequestObject.ToString("action");
			if (action == "u")
			{
				var user = xMemberFactory.UserService.GetUser(this.UserID);
				user.HeadPicture = this.HeadPicture.Value;

				xMemberFactory.UserService.UpdateUser(user);

				MemberAction.SetUser(user);
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{

		}
	}
}
