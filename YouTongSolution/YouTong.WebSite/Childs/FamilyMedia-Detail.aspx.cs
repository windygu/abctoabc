using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Childs
{
	public partial class FamilyMedia_Detail : PageBase
	{
		public Guid MediaID;
		public AnyFile Media;
		public Child Child;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.MediaID = RequestObject.ToGuid("id");
			Media = xCmsFactory.AnyFileService.GetAnyFile(MediaID);
			this.Child = xUtFactory.ChildService.GetFirstChild(Media.UserID.Value);
			if (this.Child == null) this.Child = new Child();
		}
	}
}
