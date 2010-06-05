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
using Itfort.Web;
using System.Collections.Generic;
using YouTong.Model;
using WebBasics.Cms.Model;

namespace YouTong.WebSite.Childs
{   
    public partial class FamilyMedia_Catagory : PageBase
    {
        public Guid UserID;
        public WebBasics.Member.Model.User userB;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = RequestObject.ToGuid("userid");

            userB = WebBasics.Member.Common.MemberFactory.Instance.UserService.GetUser(UserID);

            List<Category> officCateList = new List<Category>();
            IList<Channel> officList = FamilyMediaAction.GetOfficialCategories();
            foreach (Channel item in officList)
            {
                officCateList.Add(new Category()
                {
                    Name = item.Name,
                    UserID = UserID,
                    ID = item.ID
                });
            }
            this.rp_OfficeCategory.DataSource = officCateList;
            this.rp_OfficeCategory.DataBind();

            IList<Category> catList = CategoryService.Instance.GetCategoriesByUser(UserID);
            this.rp_Categorys.DataSource = catList;
            this.rp_Categorys.DataBind();
        }
    }
}
