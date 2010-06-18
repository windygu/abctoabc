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
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;

namespace WebBasics.WebAdmin.Cms.Articles
{
    public partial class ArticleDetail : PageAuth
    {
        public Guid ID;
        public AnyFile Detail;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ID = Itfort.Web.RequestObject.ToGuid("id");
            Detail = CmsFactory.Instance.AnyFileService.GetAnyFile(ID);
        }
    }
}
