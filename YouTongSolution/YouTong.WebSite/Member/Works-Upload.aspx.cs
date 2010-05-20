using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Model;

namespace YouTong.WebSite.Member
{
	public partial class Works_Upload : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				var channels = xCmsFactory.ChannelService.GetChildChannels(UtConfig.WorksChannelID);

				foreach (var channel in channels)
				{
					this.Works_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
				}
			}

			if (RequestObject.ToString("action") == "video")
			{
				var file = ConverterFactory.ConvertTo<AnyFile>(Request.Form, "Works_");
				file.UserID = this.UserID;
				file.FileType = 2;		// 视频
				xCmsFactory.AnyFileService.AddAnyFile(file);

				Response.Redirect("../Childs/Works-Detail.aspx?id=" + file.ID);
			}
		}
	}
}
