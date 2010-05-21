using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Activities
{
	public partial class Join : PageAuth
	{
		public ActivityJoined2 ActivityJoined2;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				if (!this.IsAnonymous)
				{
					this.ActivityJoined2 = xUtFactory.ActivityJoined2Service.GetActivityJoined2(UtConfig.DisneyExpoActivityID, this.User.ID);
					if (this.ActivityJoined2 == null)
					{
						var joined = new ActivityJoined2();
						joined.ActivityID = UtConfig.DisneyExpoActivityID;
						joined.UserID = this.User.ID;
						xUtFactory.ActivityJoined2Service.AddActivityJoined2(joined);
					}
				}
			}
		}
	}
}
