using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.Model;
using YouTong.WebSite.Codes;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
    public partial class Works_Detail : PageBase
    {
        public Guid WorksID;
        public AnyFile Works;
        public Child Child;
        public Int32 PageIndex, PageSize;
        public int CatagoryCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.WorksID = RequestObject.ToGuid("id");
            Works = xCmsFactory.AnyFileService.GetAnyFile(WorksID);
            this.Child = xUtFactory.ChildService.GetFirstChild(Works.UserID.Value);
            if (this.Child == null) this.Child = new Child();
            else
            {
                CatagoryCount = CategoryService.Instance.GetCategoryCountByUser(this.Child.ParentID.Value);
            }

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
                comment.Entity = Codes.EntityName.WorkCommentEntity;
                comment.EntityID = WorksID;
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
            IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.WorkCommentEntity, WorksID, PageIndex, PageSize);
            int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.WorkCommentEntity, WorksID);
            this.rp_Comments.DataSource = commentList;
            this.rp_Comments.DataBind();

            IDataPage page = new DataPage(PageSize);
            page.CurrentPageIndex = PageIndex;
            page.RowCount = rowCount;
            MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                string.Format("Works-Detail.aspx?id={0}&pIndex=$Page", WorksID));
            hPager.Style = HtmlPagerStyle.Custom;
            this.lt_Page.Text = hPager.ToString();
            #endregion
        }
    }
}
