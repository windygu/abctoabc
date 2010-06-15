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
using YouTong.Model;
using Itfort.Web;
using YouTong.WebSite.Codes;
using WebBasics.Cms.Model;
using System.Collections.Generic;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
    public partial class ChildDefault : PageBase
    {
        public Guid UserID;
        public Child Child;
        public IList<Channel> WorksCategories;
        public Int32 PageIndex, PageSize;
        public WebBasics.Member.Model.User reviewer;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");
            this.Child = xUtFactory.ChildService.GetFirstChild(UserID);
            
            this.WorksCategories = WorksAction.GetOffiicalCategories();

            Guid workGuid = Guid.NewGuid();
            if (WorksCategories.Count > 0)
                workGuid = WorksCategories[0].ID;
            else
                workGuid = UtConfig.WorksChannelID;

            IList<AnyFile> workList = xCmsFactory.AnyFileService.GetAnyFiles(workGuid, true, UserID, null, 1, 6);
            this.rp_works.DataSource = workList;
            this.rp_works.DataBind();

            if (!IsPostBack)
            {
                ShowComment();
            }
        }

        protected void imgComment_Click(object sender, ImageClickEventArgs e)
        {
            if (User != null)
            {
                Comment comment = new Comment();
                comment.ID = Guid.NewGuid();
                comment.Reviewer = User.ID;
                comment.Title = Request["new_Title"];
                comment.Body = comment.Title;
                comment.Entity = Codes.EntityName.ChildCommentEntity;
                comment.EntityID = this.Child.ID;
                CommentService.Instance.AddComment(comment);

                ShowComment();
            }
            else
            {
                JsAlert("请先登录!");
            }
        }

        void ShowComment()
        {
            #region 评论
            IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.ChildCommentEntity, this.Child.ID, PageIndex, PageSize);
            int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.ChildCommentEntity, this.Child.ID);
            this.rp_Comments.DataSource = commentList;
            this.rp_Comments.DataBind();
            if (rowCount > 0)
            {
                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("ChildDefault-Detail.aspx?UserID={0}&pIndex=$Page", UserID));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }
            #endregion
        }
    }
}
