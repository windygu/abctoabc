using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.WebSite.Codes;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Model;

namespace YouTong.WebSite.Activities.Disney
{
	public partial class Expo_File_Upload : PageAuth
	{
		public Int32 FileType;
		public String TypeName;
		public Guid ChannelID;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				string type = RequestObject.ToString("type");
				switch (type)
				{
					case "huihua"://绘画
						TypeName = "绘画";
						this.FileType = (int)AnyFileType.Photo;
						ChannelID = UtConfig.DrawingChannelID;
						break;
					case "sheying"://摄影
						TypeName = "摄影";
						this.FileType = (int)AnyFileType.Video;
						ChannelID = UtConfig.FilmChannelID;
						break;
					case "shexiang"://摄像
						TypeName = "摄像";
						this.FileType = (int)AnyFileType.Photo;
						ChannelID = UtConfig.CameraChannelID;
						break;
					default:
						throw new Exception("类型出错");
				}

				if (this.FileType != 2) this.FileType = 1;

				this.File_ChannelID.Value = this.ChannelID.ToString();
				this.File_FileType.Value = this.FileType.ToString();
				this.File_From.Value = UtConfig.DisneyExpoActivityID.ToString();
			}

			if (RequestObject.ToString("action") == "video")
			{
				var file = ConverterFactory.ConvertTo<AnyFile>(Request.Form, "File_");
				file.UserID = this.UserID;
				file.FileType = (Byte)AnyFileType.Video;
				xCmsFactory.AnyFileService.AddAnyFile(file);

				var html = "<h1>上传成功!</h1>";
				html += "<img src='" + file.ThumbnailUrl + "' />";
				this.JsWrite("$(function(){$('#FormPanel').hide();$('#FinshPanel').show();$('#FinshPanel').html(\"" + html + "\");})");
			}
		}
	}
}
