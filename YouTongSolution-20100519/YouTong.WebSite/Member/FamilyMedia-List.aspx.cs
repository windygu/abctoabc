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
	public partial class FamilyMedia_List : PageAuth
	{
		public IList<AnyFile> Medias;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Medias = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, this.UserID, null, 1, 100);
			this.Repeater1.DataSource = this.Medias;
			this.DataBind();
		}
	}
}
