using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Channels
{
	public partial class ChannelResult : PageAuth
	{
		public Int32 Action = 0;
		public Guid ChannelID;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Action = RequestObject.ToInt32("action");
			this.ChannelID = RequestObject.ToGuid("id");
		}
	}
}
