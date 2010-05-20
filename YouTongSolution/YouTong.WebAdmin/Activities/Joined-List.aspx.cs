using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.Model;
using YouTong.Common;

namespace YouTong.WebAdmin.Activities
{
	public partial class Joined_List : PageAuth
	{
		public Guid ActivityID;
		public Activity Activity;
		Int32 _PageIndex, _PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			HtmlPager.GetPagerParmsFromRequest(out _PageIndex, out _PageSize);

			this.ActivityID = RequestObject.ToGuid("activityid");
			this.Activity = UtFactory.Instance.ActivityService.GetActivity(this.ActivityID);

			this.Repeater1.DataSource = UtFactory.Instance.ActivityJoinedService.GetActivityJoineds(_PageIndex, _PageSize);
			int rowCount = UtFactory.Instance.ActivityJoinedService.GetActivityJoinedCount(this.ActivityID);

			String baseUrl = "Activity-List.aspx?page={0}&size={1}";
			baseUrl = String.Format(baseUrl, "($ID)", _PageSize);
			HtmlPager hp = new HtmlPager(baseUrl, _PageIndex, rowCount, _PageSize, 10);

			this.Hp.Text = hp.GetHtmlNoWrapper();
		}
	}
}
