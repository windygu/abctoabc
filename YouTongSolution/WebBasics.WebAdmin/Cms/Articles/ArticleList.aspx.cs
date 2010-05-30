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
		public int AuditStatus;

		protected void Page_Load(object sender, EventArgs e)
		{
			HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize);
			this.ChannelID = RequestObject.ToGuid("ChannelID");
			this.Channel = xChannelService.GetChannel(ChannelID);
			this.AuditStatus = RequestObject.ToInt32("audit");

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



		void BindUI()
		{
			try
			{
				this.DdlAuditStatus.SelectedValue = this.AuditStatus.ToString();
			}
			catch
			{
				this.DdlAuditStatus.SelectedValue = "1";
			}

			byte[] audits;
			if (this.AuditStatus < 0)
			{
				audits = null;
			}
			else if (this.AuditStatus > 1)
			{
				audits = new byte[] { 2 };
			}
			else
			{
				audits = new byte[] { 0, 1 };
			}

			var list = xArticleService.GetArticles(ChannelID, false, audits, PageIndex, PageSize);

			this.Repeater1.DataSource = list;
			this.Repeater1.DataBind();

			int articleCount = xArticleService.GetArticleCount(ChannelID, false);

			String baseUrl = "ArticleList.aspx?ChannelID={0}&page={1}&size={2}&audit={3}";
			baseUrl = String.Format(baseUrl, ChannelID, "($ID)", PageSize, this.AuditStatus);
			HtmlPager hp = new HtmlPager(baseUrl, PageIndex, articleCount, PageSize, 10);

			this.Hp.Text = hp.GetHtmlNoWrapper();
		}

		protected void BtnQuery_Click(object sender, EventArgs e)
		{
			this.AuditStatus = RequestObject.ToInt32("DdlAuditStatus");
			this.BindUI();
		}

		protected void BtnBatchDelete_Click(object sender, EventArgs e)
		{
			var ids = RequestObject.ToGuidList("id");
			xCmsFactory.ArticleService.DeleteArticles(ids.ToArray());
			xCmsFactory.AnyFileService.DeleteAnyFiles(ids.ToArray());

			this.BindUI();
		}

		protected void BtnBatchAuditPass_Click(object sender, EventArgs e)
		{
			var ids = RequestObject.ToGuidList("id");
			xCmsFactory.ArticleService.AuditPass(ids.ToArray());
			xCmsFactory.AnyFileService.AuditPass(ids.ToArray());

			this.BindUI();
		}

		protected void BtnBatchAuditRefuse_Click(object sender, EventArgs e)
		{
			var ids = RequestObject.ToGuidList("id");
			xCmsFactory.ArticleService.AuditRefuse(ids.ToArray());
			xCmsFactory.AnyFileService.AuditRefuse(ids.ToArray());

			this.BindUI();
		}
	}
}
