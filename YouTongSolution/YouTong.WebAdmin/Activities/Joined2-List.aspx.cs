using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.Common;
using YouTong.Model;

namespace YouTong.WebAdmin.Activities
{
	public partial class Joined2_List : PageAuth
	{
		public Guid ActivityID;
		public Activity Activity;
		Int32 _PageIndex, _PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			HtmlPager.GetPagerParmsFromRequest(out _PageIndex, out _PageSize);

			this.ActivityID = RequestObject.ToGuid("activityid");
			this.Activity = UtFactory.Instance.ActivityService.GetActivity(this.ActivityID);

			this.Repeater1.DataSource = UtFactory.Instance.ActivityJoined2Service.GetActivityJoined2s(this.ActivityID, _PageIndex, _PageSize);
			this.DataBind();
			int rowCount = UtFactory.Instance.ActivityJoined2Service.GetDeletedActivityJoined2Count(this.ActivityID);
			String baseUrl = "Joined2-List.aspx?activityid={0}&page={1}&size={2}";
			baseUrl = String.Format(baseUrl, this.ActivityID, "($ID)", _PageSize);
			HtmlPager hp = new HtmlPager(baseUrl, _PageIndex, rowCount, _PageSize, 10);

			this.Hp.Text = hp.GetHtmlNoWrapper();
		}
	}
}
