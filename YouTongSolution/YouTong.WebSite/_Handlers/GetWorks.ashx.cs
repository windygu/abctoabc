using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Itfort.Web;
using System.Collections.Generic;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Common;
using System.Text;

namespace YouTong.WebSite._Handlers
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetWorks : HttpHandlerBase
    {

        public override void ProcessRequest(HttpContext context)
        {
            Guid UserID = RequestObject.ToGuid("userid");
            Guid workGuid = RequestObject.ToGuid("Cat");

            IList<AnyFile> workList = CmsFactory.Instance.AnyFileService.GetAnyFiles(workGuid, true, UserID, null, 1, 6);
            StringBuilder sbJson = new StringBuilder();

            foreach (AnyFile item in workList)
            {
                sbJson.AppendFormat("[\"{0}\",\"{1}\",\"{2}\"],", item.ID, item.ThumbnailUrl, item.Title);
            }
            if (sbJson.Length > 0)
                sbJson.Remove(sbJson.Length - 1, 1);
            sbJson.Insert(0, "{Data:[");
            sbJson.Append("]}");
            context.Response.Write(sbJson.ToString());
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
