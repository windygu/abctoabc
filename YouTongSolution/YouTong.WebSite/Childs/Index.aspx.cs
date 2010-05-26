using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Childs
{
	public partial class Index : PageBase
	{
		public Int32 i;
		public IList<Channel> WorksCategories;
		public IList<Channel> MediaCategories;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksCategories = WorksAction.GetOffiicalCategories();
			this.MediaCategories = FamilyMediaAction.GetOfficialCategories();

			var tjWorks = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, 1, 5);
			this.RepeaterTjWorks.DataSource = tjWorks;

			var works = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, 1, 10);
			this.RepeaterWorks.DataSource = works;

			var tjChilds = xUtFactory.ChildService.GetChilds(1, 5);
			this.RepeaterTjChild.DataSource = tjChilds;

			var douxiuNews = xCmsFactory.ArticleService.GetArticles(UtConfig.DouXiuChannelID, true, 1, 3);
			this.RepeaterDouXiu.DataSource = douxiuNews;

			var topWorkses = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, 1, 5);
			this.RepeaterTopWorks.DataSource = topWorkses;

			var topChilds = xUtFactory.ChildService.GetChilds(1, 5);
			this.RepeaterTopChild.DataSource = topChilds;

			this.RepeaterMedia.DataSource = xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.FamilyMediaChannelID, true, 1, 5);

			this.DataBind();
		}
	}
}
