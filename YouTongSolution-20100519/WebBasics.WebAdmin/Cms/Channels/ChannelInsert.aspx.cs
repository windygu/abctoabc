using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using Itfort.Web.Binder;
using WebBasics.Cms.Model;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Channels
{
	public partial class ChannelInsert : PageAuth
	{
		public Guid? ParentID;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ParentID = RequestObject.ToNullableGuid("ParentID");

			if (!this.IsPostBack)
			{
				if (this.ParentID != null)
				{
					this.Channel_ParentID.Value = this.ParentID.Value.ToString();
					this.LblParentChannel.Text = xCmsService.GetChannelFamily(this.ParentID.Value) ?? "";
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

			xChannelService.AddChannel(channel);
			Response.Redirect("ChannelResult.aspx?action=1&id=" + channel.ID);
		}
	}
}
