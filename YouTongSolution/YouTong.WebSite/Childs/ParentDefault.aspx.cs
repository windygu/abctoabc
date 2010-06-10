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
using WebBasics.Cms.Model;
using System.Collections.Generic;
using Itfort.Web;
using YouTong.Data;

namespace YouTong.WebSite.Childs
{
    public partial class ParentDefault : PageBase
    {
        public Guid UserID;
        public WebBasics.Member.Model.User userB;
        public Child Child;
        public IList<Article> Articles;
        public int blogsCount;
        public int categoryCount;
        public Area area;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");


            this.Child = xUtFactory.ChildService.GetFirstChild(UserID);

            userB = WebBasics.Member.Common.MemberFactory.Instance.UserService.GetUser(UserID);

            area = DbArea.Instance.GetArea(userB.City);
            if (area == null)
                area = new Area()
                {
                    Name = "未填写"
                };

            this.Articles = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, this.UserID, 1, 10);
            blogsCount = this.Articles.Count;
            this.rp_Blogs.DataSource = this.Articles;
            this.rp_Blogs.DataBind();

            #region 亲子影像
            List<Category> catList = CategoryService.Instance.GetCategoriesByUser(UserID, YouTong.FamilyMediaAction.EntityName) as List<Category>;
            categoryCount = catList.Count;
            if (catList.Count > 4)
                catList.GetRange(0, 4);
            
            this.rp_Categorys.DataSource = catList;
            this.rp_Categorys.DataBind();
            #endregion
        }
    }
}
