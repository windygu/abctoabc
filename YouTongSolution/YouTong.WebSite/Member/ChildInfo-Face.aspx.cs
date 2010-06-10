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

namespace YouTong.WebSite.Member
{
    public partial class ChildInfo_Face : PageAuth
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Itfort.Web.RequestObject.ToString("action");
            if (action == "u")
            {
                Child child = this.FirstChild;
                child.HeadPicture = this.HeadPicture.Value;

                xUtFactory.ChildService.UpdateChild(child);
            }
        }
    }
}
