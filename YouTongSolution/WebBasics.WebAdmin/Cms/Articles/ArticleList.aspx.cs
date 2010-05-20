using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using WebBasics.WebAdmin.Cms.Codes;

namespace WebBasics.WebAdmin.Cms.Articles
{
	public partial class ArticleList : PageAuth
	{
		public Guid ChannelID { get; set; }
		public Channel Channel { get; set; }
		public int PageIndex, PageSize;

		protected void Page_Load(object sender, EventArgs e)
		{
			HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize);
			this.ChannelID = RequestObject.ToGuid("ChannelID");
			this.Channel = xChannelService.GetChannel(ChannelID);

			if (!this.IsPostBack)
			{
				this.BindUI();
			}
		}

		protected void BtnSingleDelete_Click(object sender, EventArgs e)
		{
			Guid id = new Guid(this.HfArticleID.Value);
			xCmsFactory.ArticleService.DeleteArticle(id);
			xCmsFactory.AnyFileService.DeleteAnyFile(id);

			this.BindUI();
		}

		protected void BtnBatchDelete_Click(object sender, EventArgs e)
		{
			var ids = RequestObject.ToGuidList("id");
			xCmsFactory.ArticleService.DeleteArticles(ids.ToArray());
			xCmsFactory.AnyFileService.DeleteAnyFiles(ids.ToArray());

			this.BindUI();
		}

		void BindUI()
		{
			var list = xArticleService.GetArticles(ChannelID, false, PageIndex, PageSize);

			this.Repeater1.DataSource = list;
			this.DataBind();

			int articleCount = xArticleService.GetArticleCount(ChannelID, false);

			String baseUrl = "ArticleList.aspx?ChannelID={0}&page={1}&size={2}";
			baseUrl = String.Format(baseUrl, ChannelID, "($ID)", PageSize);
			HtmlPager hp = new HtmlPager(baseUrl, PageIndex, articleCount, PageSize, 10);

			this.Hp.Text = hp.GetHtmlNoWrapper();
		}
	}
}
