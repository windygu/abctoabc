using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Activities.Disney
{
	public partial class Join : PageBase
	{
		public ActivityJoined ActivityJoined;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				if (!this.IsAnonymous)
				{
					this.ActivityJoined = xUtFactory.ActivityJoinedService.GetActivityJoined(UtConfig.DisneyExpoActivityID, this.User.ID);
					if (this.ActivityJoined != null)
					{
						Response.Redirect("expo.aspx");
					}
					else
					{
						var joined = new ActivityJoined();
						joined.ActivityID = UtConfig.DisneyExpoActivityID;
						joined.UserID = this.User.ID;
						xUtFactory.ActivityJoinedService.AddActivityJoined(joined);
                        Response.Redirect("http://www.no1child.com/activities/disney/disneyext/index.html");
					}
				}
				else
				{
					Response.Redirect("expo.aspx");
				}
			}
		}
	}
}
