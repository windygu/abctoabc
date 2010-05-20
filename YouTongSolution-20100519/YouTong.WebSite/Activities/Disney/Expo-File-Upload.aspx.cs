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
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				var channels = xCmsFactory.ChannelService.GetChildChannels(UtConfig.FamilyMediaChannelID);

				foreach (var channel in channels)
				{
					this.File_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
				}

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
