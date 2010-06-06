using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Itfort.Web;

namespace YouTong.WebSite._Handlers
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Info : YouTong.WebSite.Codes.HttpHandlerBase
    {

        public override void ProcessRequest(HttpContext context)
        {
            string action = RequestObject.ToString("action");
            string value = RequestObject.ToString("value");
            Guid UserID = RequestObject.ToGuid("userid");
            Guid ChildID = RequestObject.ToGuid("childid");
            Guid ID = RequestObject.ToGuid("Id");

            WebBasics.Member.Model.User user = MemberAction.GetUser();
            if (user != null && user.ID == UserID)
            {
                ResumeService resumeS = new ResumeService();
                resumeS.DeleteResume(ID);
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
