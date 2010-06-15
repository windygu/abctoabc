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
using WebBasics.Cms.Common;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
	public partial class FamilyMedia_Detail : PagingBase
	{
		public Guid MediaID;
		public AnyFile Media;
		public Child Child;
        public Int32 PageIndex, PageSize;
        public int CatagoryCount = 0;
        public string TypeName = string.Empty;
        public string CatagoryName = string.Empty;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.MediaID = RequestObject.ToGuid("id");
			Media = xCmsFactory.AnyFileService.GetAnyFile(MediaID);
			this.Child = xUtFactory.ChildService.GetFirstChild(Media.UserID.Value);
			if (this.Child == null) this.Child = new Child();
            else
            {
                CatagoryCount = CategoryService.Instance.GetCategoryCountByUser(this.Child.ParentID.Value);

                Channel channel = CmsFactory.Instance.ChannelService.GetChannel(Media.ChannelID.Value);
                if (channel != null)
                    TypeName = channel.Name;

                InCategory inCategory = InCategoryService.Instance.GetCatatoryIDByAnyFileID(MediaID);
                if (inCategory != null)
                {
                    Category category = CategoryService.Instance.GetCategory(inCategory.CategoryID);
                    if (category != null)
                        CatagoryName = category.Name;
                }
            }

            if (!IsPostBack)
            {
                ShowComment();
            }
		}

        void ShowComment()
        {
            #region 评论
            IList<Comment> commentList = CommentService.Instance.GetComments(Codes.EntityName.MediaCommentEntity, MediaID, PageIndex, PageSize);
            int rowCount = CommentService.Instance.GetCommentCount(Codes.EntityName.MediaCommentEntity, MediaID);
            this.rp_Comments.DataSource = commentList;
            this.rp_Comments.DataBind();

            IDataPage page = new DataPage(PageSize);
            page.CurrentPageIndex = PageIndex;
            page.RowCount = rowCount;
            MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                string.Format("FamilyMedia-Detail.aspx?id={0}&pIndex=$Page", MediaID));
            hPager.Style = HtmlPagerStyle.Custom;
            this.lt_Page.Text = hPager.ToString();
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
