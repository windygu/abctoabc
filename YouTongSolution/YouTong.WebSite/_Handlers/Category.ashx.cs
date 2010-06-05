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
    public class Category : YouTong.WebSite.Codes.HttpHandlerBase
    {

        public override void ProcessRequest(HttpContext context)
        {
            string action = RequestObject.ToString("action");
            string value = RequestObject.ToString("value");
            Guid UserID = RequestObject.ToGuid("userid");
            Guid ID = RequestObject.ToGuid("Id");

            WebBasics.Member.Model.User user = MemberAction.GetUser();
            if (user != null && user.ID == UserID)
            {
                //删除分类
                if (action.ToLower().CompareTo("delete") == 0)
                {
                    CategoryService.Instance.DeleteCategory(ID);
                }
                else if (action.ToLower().CompareTo("update") == 0)
                {
                    CategoryService.Instance.UpdateCategory(new YouTong.Model.Category()
                    {
                        Name = value,
                        ID = ID,
                        Entity = YouTong.FamilyMediaAction.EntityName,
                        UserID = UserID
                    });
                }
                else if (action.ToLower().CompareTo("add") == 0)
                {

                    CategoryService.Instance.AddCategory(new YouTong.Model.Category()
                    {
                        Name = value,
                        UserID = UserID,
                        Entity = YouTong.FamilyMediaAction.EntityName,
                        ID = Guid.NewGuid()
                    });
                }
                else if (action.ToLower().CompareTo("deleteanyfile") == 0)
                {
                    CmsFactory.Instance.AnyFileService.DeleteAnyFile(ID);
                }
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
