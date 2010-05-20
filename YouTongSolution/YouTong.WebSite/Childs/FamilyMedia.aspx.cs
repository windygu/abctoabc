using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Childs
{
	public partial class FamilyMedia : PageBase
	{
		public Int32 i = 0;
		public Guid UserID;
		public Int32 PageIndex, PageSize;
		public Int32 MediaType;
		public Guid CategoryID;
		public Channel Category;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.UserID = RequestObject.ToGuid("userid");
			HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 12);
			this.MediaType = RequestObject.ToInt32("type");
			if (this.MediaType != 2) this.MediaType = 1;
			this.CategoryID = RequestObject.ToGuid("cat");

			if (this.CategoryID == Guid.Empty) this.CategoryID = UtConfig.WorksChannelID;
			this.Category = xCmsFactory.ChannelService.GetChannel(this.CategoryID);

			IList<AnyFile> files;
			int rowCount = 0;
			if (this.UserID != Guid.Empty)
			{
				files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, UserID, MediaType, this.PageIndex, this.PageSize);
				rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(this.CategoryID, true);
			}
			else
			{
				files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, null, MediaType, this.PageIndex, this.PageSize);
			}

			var baseUrl = "FamilyMedia.aspx?UserID=" + UserID + "&type=" + MediaType + "&Page=($ID)&Size=" + PageSize;
			HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize, 10);

			this.Repeater1.DataSource = files;
			this.DataBind();
		}
	}
}
