using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Itfort.Web;

namespace YouTong.WebSite.Codes
{
    public class PagingBase : PageBase
    {
        public Int32 PageIndex;
        public Int32 PageSize = 2;

        protected override void OnPreInit(EventArgs e)
        {
            PageIndex = RequestObject.ToInt32("pIndex");
            if (PageIndex == 0)
                PageIndex = 1;

            base.OnPreInit(e);
        }
    }
}
