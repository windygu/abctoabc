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
        public Area area;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");
            string action = RequestObject.ToString("action");
            Guid id = RequestObject.ToGuid("id");
            if (!string.IsNullOrEmpty(action) && action.ToLower().CompareTo("delete") == 0)
            {
                xCmsFactory.ArticleService.DeleteArticle(id);
            }

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
        }
    }
}
