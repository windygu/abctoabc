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

namespace YouTong.WebSite.Childs
{
	public partial class FamilyMedia_Detail : PageBase
	{
		public Guid MediaID;
		public AnyFile Media;
		public Child Child;
        public Int32 PageIndex, PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.MediaID = RequestObject.ToGuid("id");
			Media = xCmsFactory.AnyFileService.GetAnyFile(MediaID);
			this.Child = xUtFactory.ChildService.GetFirstChild(Media.UserID.Value);
			if (this.Child == null) this.Child = new Child();
            if (!IsPostBack)
            {
                ShowComment();
            }
		}

        void ShowComment()
        {
            #region 评论
            HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 10);
            IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.MediaCommentEntity, MediaID, PageIndex, PageSize);
            int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.MediaCommentEntity, MediaID);
            this.rp_Comments.DataSource = commentList;
            this.rp_Comments.DataBind();

            var baseUrl = "ChildDefault.aspx?id=" + MediaID + "&Page=($ID)&Size=" + PageSize;
            HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize);
            this.lt_Page.Text = hp.GetHtml(rowCount, PageSize);
            #endregion
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
                comment.Entity = Codes.EntityName.MediaCommentEntity;
                comment.EntityID = MediaID;
                CommentService.Instance.AddComment(comment);

                ShowComment();
            }
            else
            {
                JsAlert("请先登录!");
            }
        }
	}
}
