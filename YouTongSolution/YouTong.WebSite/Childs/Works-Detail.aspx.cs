﻿using System;
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
	public partial class Works_Detail : PageBase
	{
		public Guid WorksID;
		public AnyFile Works;
		public Child Child;
        public Int32 PageIndex, PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksID = RequestObject.ToGuid("id");
			Works = xCmsFactory.AnyFileService.GetAnyFile(WorksID);
			this.Child = xUtFactory.ChildService.GetFirstChild(Works.UserID.Value);
			if (this.Child == null) this.Child = new Child();

            if (!IsPostBack)
            {
                #region 评论
                HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 10);
                IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.WorkCommentEntity, this.Child.ID, PageIndex, PageSize);
                int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.WorkCommentEntity, this.Child.ID);
                this.rp_Comments.DataSource = commentList;
                this.rp_Comments.DataBind();

                var baseUrl = "ChildDefault.aspx?id=" + WorksID + "&Page=($ID)&Size=" + PageSize;
                HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize);
                this.lt_Page.Text = hp.GetHtml(rowCount, PageSize);
                #endregion
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
                comment.EntityID = this.Child.ID;
                CommentService.Instance.AddComment(comment);

                #region 评论
                HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 10);
                IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.WorkCommentEntity, this.Child.ID, PageIndex, PageSize);
                this.rp_Comments.DataSource = commentList;
                this.rp_Comments.DataBind();
                #endregion
            }
            else
            {
                JsAlert("请先登录!");
            }
        }
	}
}
