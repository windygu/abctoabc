using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web.Binder;
using YouTong.WebSite.Codes;
using YouTong.Model;
using YouTong.Common;

namespace YouTong.WebSite.Member
{
	public partial class RegisterChild : PageAuth
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var child = ConverterFactory.ConvertTo<Child>(Request.Form, "Child_");
			child.ParentID = this.UserID;
			if (child.Birthday == DateTime.MinValue) child.Birthday = DateTime.Parse("1899-1-1");

			try
			{
				var xChildService = UtFactory.Instance.ChildService;
				xChildService.AddChild(child);
			}
			catch (Exception ex)
			{
				this.JsAlert(ex.Message);
				return;
			}

			Response.Redirect("RegisterSuccess.aspx");
		}
	}
}
