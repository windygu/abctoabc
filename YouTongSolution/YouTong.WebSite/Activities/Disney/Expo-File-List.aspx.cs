using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Model;

namespace YouTong.WebSite.Activities.Disney
{
	public partial class Expo_File_List : PageBase
	{
		public Int32 i;
		public Int32 FileType;
		public Int32 PageIndex, PageSize;
        public string TypeName = string.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
            string type = RequestObject.ToString("type");
            Guid channelID = null;
            switch (type)
            {
                case "huihua"://绘画
                    TypeName = "绘画";
                    this.FileType = (int)AnyFileType.Photo;
                    channelID = UtConfig.DrawingChannelID;
                    break;
                case "sheying"://摄影
                    TypeName = "摄影";
                    this.FileType = (int)AnyFileType.Video;
                    channelID = UtConfig.FilmChannelID;
                    break;
                case "shexiang"://摄像
                    TypeName = "摄像";
                    this.FileType = (int)AnyFileType.Photo;
                    channelID = UtConfig.CameraChannelID;
                    break;
            }
			if (this.FileType != 2) this.FileType = 1;

			HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 40);

            var list = xCmsFactory.AnyFileService.GetAnyFiles(channelID, true, null, this.FileType, UtConfig.DisneyExpoActivityID.ToString(), PageIndex, PageSize);
			this.Repeater1.DataSource = list;
			this.DataBind();

            var rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(channelID, true, null, null, UtConfig.DisneyExpoActivityID.ToString());

			var baseUrl = "expo-file-list.aspx?page=($ID)&size=" + PageSize;
			HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize);
			this.Hp.Text = hp.GetHtml();
		}
	}
}
