using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using YouTong.Model;

namespace YouTong.WebSite.Member
{
	public partial class FamilyMedia_Upload : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Guid guid = RequestObject.ToGuid("id");
			if (!this.IsPostBack)
			{
				var channels = xCmsFactory.ChannelService.GetChildChannels(UtConfig.FamilyMediaChannelID);

				foreach (var channel in channels)
				{   
					this.Works_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
                    if (channel.ID == guid)
                        this.Works_ChannelID.SelectedIndex = this.Works_ChannelID.Items.Count - 1;
				}
                IList<Category> catList = CategoryService.Instance.GetCategoriesByUser(UserID, YouTong.FamilyMediaAction.EntityName);
                foreach (var channel in catList)
                {
                    this.Works_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
                    if (channel.ID == guid)
                        this.Works_ChannelID.SelectedIndex = this.Works_ChannelID.Items.Count - 1;
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
