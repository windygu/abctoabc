using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class Works_List : PageAuth
	{
		public IList<AnyFile> Workses;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Workses = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, this.UserID, null, 1, 100);
			this.Repeater1.DataSource = this.Workses;
			this.DataBind();
		}
	}
}
