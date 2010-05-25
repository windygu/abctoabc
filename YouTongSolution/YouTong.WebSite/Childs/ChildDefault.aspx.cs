using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using YouTong.Model;
using Itfort.Web;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Model;
using System.Collections.Generic;

namespace YouTong.WebSite.Childs
{
    public partial class ChildDefault : PageBase
    {
        public Guid UserID;
        public Child Child;
        public IList<Channel> WorksCategories;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");
            this.Child = xUtFactory.ChildService.GetFirstChild(UserID);

            this.WorksCategories = WorksAction.GetWorksCategories();
        }
    }
}
