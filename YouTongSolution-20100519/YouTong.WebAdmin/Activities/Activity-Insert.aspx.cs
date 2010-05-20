using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web.Binder;
using YouTong.Common;
using YouTong.Model;

namespace YouTong.WebAdmin.Activities
{
	public partial class Activity_Insert : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var activity = ConverterFactory.ConvertTo<Activity>(Request.Params, "Activity_");

			UtFactory.Instance.ActivityService.AddActivity(activity);

			Response.Redirect("Activity-List.aspx");
		}
	}
}
