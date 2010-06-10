using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Common;
using Itfort.Web;
using System.Collections.Generic;
using WebBasics.Cms.Model;
using System.Text;
using YouTong.Model;

namespace YouTong.WebSite._Handlers
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetMedias : HttpHandlerBase
    {

        public override void ProcessRequest(HttpContext context)
        {
            Guid mediaID = RequestObject.ToGuid("id");

            StringBuilder sbJson = new StringBuilder();
            string title;
            string name;
            IList<Comment> mediaComments;
            IList<AnyFile> fileList = CmsFactory.Instance.AnyFileService.GetAnyFiles(mediaID, true, 1, 6);
            foreach (AnyFile item in fileList)
            {
                title = string.Empty;
                name = string.Empty;
                mediaComments = CommentService.Instance.GetComments(Codes.EntityName.MediaCommentEntity, item.ID, 1, 1);
                if (mediaComments != null && mediaComments.Count > 0)
                {
                    title = mediaComments[0].Title;
                    if (mediaComments[0].Title.Length > 15)
                        title = mediaComments[0].Title.Substring(0, 15);
                    name = DataCache.GetChildNameByUserID(mediaComments[0].Reviewer.Value);
                }

                sbJson.AppendFormat("[\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\"],", item.ID, item.ThumbnailUrl, item.Title,
                    DataCache.GetChildNameByUserID(item.UserID.Value),
                    DataCache.GetSchoolNameByUserID(item.UserID.Value),
                    title,
                    name);
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
