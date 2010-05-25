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
using YouTong.WebSite.Codes;
using YouTong.Model;

namespace YouTong.WebSite.Childs
{
    public partial class ParentDefault : PageBase
    {
        public Child Child;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Child = xUtFactory.ChildService.GetFirstChild(User.ID);
        }
    }
}
