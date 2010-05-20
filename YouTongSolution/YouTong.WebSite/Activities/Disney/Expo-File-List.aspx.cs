using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Activities.Disney
{
	public partial class Expo_File_List : PageBase
	{
		public Int32 i;
		public Int32 FileType;
		public Int32 PageIndex, PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.FileType = RequestObject.ToInt32("type");
			if (this.FileType != 2) this.FileType = 1;

			HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 40);

			var list = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, null, this.FileType, UtConfig.DisneyExpoActivityID.ToString(), PageIndex, PageSize);
			this.Repeater1.DataSource = list;
			this.DataBind();
			
			var rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(UtConfig.FamilyMediaChannelID, true, null, null, UtConfig.DisneyExpoActivityID.ToString());

			var baseUrl = "expo-file-list.aspx?page=($ID)&size=" + PageSize;
			HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize);
			this.Hp.Text = hp.GetHtml();
		}
	}
}
