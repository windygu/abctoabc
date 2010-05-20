using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using YouTong.Common;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite
{
	public partial class _Default : PageBase
	{
		public Int32 i;
		public IList<Channel> WorksCategories;
		public IList<Channel> MediaCategories;
		public Child StarChild;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksCategories = WorksAction.GetWorksCategories();
			this.MediaCategories = FamilyMediaAction.GetMediaCategories();
			this.StarChild = xUtFactory.ChildService.GetChild(UtConfig.StarChildID);

			var workses = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, 1, 4);

			var medias = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, 1, 4);
			this.RepeaterMedia.DataSource = medias;

			var childs = xUtFactory.ChildService.GetChilds(1, 4);

			var douxiuNews = xCmsFactory.ArticleService.GetArticles(UtConfig.DouXiuChannelID, true, 1, 5);
			this.RepeaterDouXiu.DataSource = douxiuNews;

			var huodongNews = xCmsFactory.ArticleService.GetArticles(UtConfig.HuoDongChannelID, true, 1, 5);

			var topWorkses = workses;
			this.RepeaterTopWorks.DataSource = topWorkses;

			var topChilds = childs;
			this.RepeaterTopChild.DataSource = topChilds;

			if (this.StarChild != null)
			{
				var starChildWorkses = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, this.StarChild.ParentID.Value, null, 1, 4);
				this.RepeaterStarChildWorks.DataSource = starChildWorkses;
			}

			this.RepeaterWorks.DataSource = workses;

			this.RepeaterChild.DataSource = childs;
			this.RepeaterHuoDong.DataSource = huodongNews;

			this.DataBind();
		}

		protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				var username = Request["User_UserName"];
				var password = Request["User_Password"];

				this.SignIn(username, password, false);

				Response.Redirect("Default.aspx");
			}
			catch
			{
				this.JsAlert("登录失败");
			}
		}

		protected Child GetFirstChild()
		{
			var childs = UtFactory.Instance.ChildService.GetChildsByParent(this.User.ID);
			return childs.Count == 0 ? null : childs[0];
		}
	}
}
