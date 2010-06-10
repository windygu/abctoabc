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
using YouTong.Model;

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

            IList<AnyFile> workList;
            IList<Comment> workComments;
            string title;
            string name;
            StringBuilder sbJson = new StringBuilder();
            if (UserID == Guid.Empty)
            {
                workList = CmsFactory.Instance.AnyFileService.GetAnyFiles(workGuid, true, 1, 6);
                foreach (AnyFile item in workList)
                {
                    title = string.Empty;
                    name = string.Empty;
                    workComments = CommentService.Instance.GetComments(Codes.EntityName.WorkCommentEntity, item.ID, 1, 1);
                    if (workComments != null && workComments.Count > 0)
                    {
                        title = workComments[0].Title;
                        if (workComments[0].Title.Length > 15)
                            title = workComments[0].Title.Substring(0, 15);
                        name = DataCache.GetChildNameByUserID(workComments[0].Reviewer.Value);
                    }

                    sbJson.AppendFormat("[\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"],", item.ID, item.ThumbnailUrl, item.Title,
                        DataCache.GetChildNameByUserID(item.UserID.Value),
                        DataCache.GetSchoolNameByUserID(item.UserID.Value),
                        title,
                        name);
                }
            }
            else
            {
                workList = CmsFactory.Instance.AnyFileService.GetAnyFiles(workGuid, true, UserID, null, 1, 6);
                foreach (AnyFile item in workList)
                {
                    sbJson.AppendFormat("[\"{0}\",\"{1}\",\"{2}\"],", item.ID, item.ThumbnailUrl, item.Title);
                }
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
