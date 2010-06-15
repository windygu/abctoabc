using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using WebBasics.Member.Model;
using YouTong.Model;
using MySoft.Data;

namespace YouTong.WebSite.Blogs
{
	public partial class Detail : PagingBase
	{
		public Guid BlogID;
		public Article Blog;
		public User Owner;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.BlogID = RequestObject.ToGuid("id");
			this.Blog = xCmsFactory.ArticleService.GetArticle(BlogID);

            if (!IsPostBack)
            {
                ShowComment();
            }
		}

        void ShowComment()
        {
            #region 评论
            IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.BlogCommentEntity, BlogID, PageIndex, PageSize);
            int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.BlogCommentEntity, BlogID);
            this.rp_Comments.DataSource = commentList;
            this.rp_Comments.DataBind();
            if (rowCount > 0)
            {
                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("Detail.aspx?id={0}&pIndex=$Page", BlogID));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }
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
                comment.Entity = Codes.EntityName.BlogCommentEntity;
                comment.EntityID = BlogID;
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
