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
        public Guid guid = RequestObject.ToGuid("id");
        public Guid CatagoryID = RequestObject.ToGuid("cid");

		protected void Page_Load(object sender, EventArgs e)
		{
             
			if (!this.IsPostBack)
			{
				var channels = xCmsFactory.ChannelService.GetChildChannels(UtConfig.FamilyMediaChannelID);

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
                InCategoryService.Instance.AddInCategory(new InCategory()
                {
                    CategoryID=guid,
                    EntityID=file.ID
                });

				Response.Redirect("../Childs/Works-Detail.aspx?id=" + file.ID);
			}
		}
	}
}
