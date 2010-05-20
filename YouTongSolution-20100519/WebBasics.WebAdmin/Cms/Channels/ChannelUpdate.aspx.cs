using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.WebAdmin.Cms.Codes;
using WebBasics.Cms.Model;

namespace WebBasics.WebAdmin.Cms.Channels
{
	public partial class ChannelUpdate : PageAuth
	{
		public Guid ChannelID;
		public Channel Channel;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ChannelID = RequestObject.ToGuid("id");
			this.Channel = xChannelService.GetChannel(this.ChannelID);

			if (!this.IsPostBack)
			{
				this.LblID.Text = this.Channel.ID.ToString();
				this.Channel_Name.Text = this.Channel.Name;
				this.Channel_DisplayName.Text = this.Channel.DisplayName;
				this.LblAddTime.Text = this.Channel.AddTime.ToString("yyyy-MM-dd HH:mm:ss");
				this.LblUpdateTime.Text = this.Channel.UpdateTime.ToString("yyyy-MM-dd HH:mm:ss");

				if (this.Channel.ParentID != null)
				{
					this.Channel_ParentID.Value = this.Channel.ParentID.Value.ToString();
					this.LblParentChannel.Text = xCmsService.GetChannelFamily(this.Channel.ParentID.Value) ?? "有问题？";
				}
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			Channel channel = ConverterFactory.ConvertTo<Channel>(Request.Params, "Channel_");

			if (channel.ParentID.HasValue)
			{
				if (!xChannelService.ExistsChannel(channel.ParentID.Value))
				{
					channel.ParentID = null;
				}
			}

			this.Channel.Name = channel.Name;
			this.Channel.DisplayName = channel.DisplayName;

			xChannelService.UpdateChannel(this.Channel);
			Response.Redirect("ChannelResult.aspx?action=2&id=" + this.Channel.ID);
		}
	}
}
