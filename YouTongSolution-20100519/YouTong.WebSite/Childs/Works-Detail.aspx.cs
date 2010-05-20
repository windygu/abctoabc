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
	public partial class Works_Detail : PageBase
	{
		public Guid WorksID;
		public AnyFile Works;
		public Child Child;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksID = RequestObject.ToGuid("id");
			Works = xCmsFactory.AnyFileService.GetAnyFile(WorksID);
			this.Child = xUtFactory.ChildService.GetFirstChild(Works.UserID.Value);
			if (this.Child == null) this.Child = new Child();
		}
	}
}
