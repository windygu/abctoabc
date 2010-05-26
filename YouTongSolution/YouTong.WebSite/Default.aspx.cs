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
        public int anyFilesCount;
        public int registerCount;

		protected void Page_Load(object sender, EventArgs e)
		{
            registerCount = WebBasics.Member.UserService.Instance.GetUserCount();

			this.WorksCategories = WorksAction.GetOffiicalCategories();
			this.MediaCategories = FamilyMediaAction.GetOfficialCategories();
			this.StarChild = xUtFactory.ChildService.GetChild(UtConfig.StarChildID);

            Guid workGuid = Guid.NewGuid();
            if (WorksCategories.Count > 0)
                workGuid = WorksCategories[0].ID;
            else
                workGuid = UtConfig.WorksChannelID;
            //得到第一个分类的作品或所有作品
            var workses = xCmsFactory.AnyFileService.GetAnyFiles(workGuid, true, 1, 6);
            //得到所有作品
            anyFilesCount = xCmsFactory.AnyFileService.GetAnyFileCount(UtConfig.WorksChannelID, true);

			var medias = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, 1, 6);
			this.RepeaterMedia.DataSource = medias;

			var childs = xUtFactory.ChildService.GetChilds(1, 6);

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
