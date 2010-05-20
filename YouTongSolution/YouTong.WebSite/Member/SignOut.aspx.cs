using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class SignOut : PageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.SignOut();

			this.GoReferrerUrl();
		}
	}
}
