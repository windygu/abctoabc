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
	public partial class Home : PageBase
	{
		public Int32 i;
		public Guid UserID;
		public Child Child;
		public IList<Channel> WorksCategories;
		public IList<Channel> MediaCategories;
		public IList<AnyFile> Workses;
		public IList<AnyFile> Medias;
		public IList<Article> Blogs;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.UserID = RequestObject.ToGuid("userid");
			this.Child = xUtFactory.ChildService.GetFirstChild(UserID);
			this.WorksCategories = WorksAction.GetOffiicalCategories();
			this.MediaCategories = FamilyMediaAction.GetOfficialCategories();

			this.Workses = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, UserID, null, 1, 6);
			this.RepeaterWorks.DataSource = this.Workses;

			this.Medias = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, UserID, null, 1, 6);
			this.RepeaterMedia.DataSource = this.Medias;

			this.Blogs = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, this.UserID, 1, 5);
			this.RepeaterBlog.DataSource = this.Blogs;

			this.DataBind();
		}
	}
}
