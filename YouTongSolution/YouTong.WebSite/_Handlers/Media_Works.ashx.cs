using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Itfort.Web;
using WebBasics.Cms.Common;

namespace YouTong.WebSite._Handlers
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Media_Works : YouTong.WebSite.Codes.HttpHandlerBase
    {

        public override void ProcessRequest(HttpContext context)
        {
            Guid UserID = RequestObject.ToGuid("userid");
            Guid ID = RequestObject.ToGuid("id");
            //string type = RequestObject.ToString("type");

            WebBasics.Member.Model.User user = MemberAction.GetUser();
            if (user != null && user.ID == UserID)
            {
                CmsFactory.Instance.AnyFileService.DeleteAnyFile(ID);
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("");
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
