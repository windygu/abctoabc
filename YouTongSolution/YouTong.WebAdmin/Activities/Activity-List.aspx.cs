using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.Common;

namespace YouTong.WebAdmin.Activities
{
	public partial class Activity_List : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var list = UtFactory.Instance.ActivityService.GetAllActivities();
			this.Repeater1.DataSource = list;
			this.DataBind();
		}
	}
}
