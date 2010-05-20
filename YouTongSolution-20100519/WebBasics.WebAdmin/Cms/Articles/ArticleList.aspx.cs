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

		protected void Page_Load(object sender, EventArgs e)
		{
			int _PageIndex, _PageSize;

			HtmlPager.GetPagerParmsFromRequest(out _PageIndex, out _PageSize);

			this.ChannelID = RequestObject.ToGuid("ChannelID");

			this.Channel = xChannelService.GetChannel(ChannelID);

			var contents = xArticleService.GetArticles(ChannelID, false, _PageIndex, _PageSize);

			this.Repeater1.DataSource = contents;
			this.DataBind();

			int articleCount = xArticleService.GetArticleCount(ChannelID, false);

			String baseUrl = "ArticleList.aspx?ChannelID={0}&page={1}&size={2}";
			baseUrl = String.Format(baseUrl, ChannelID, "($ID)", _PageSize);
			HtmlPager hp = new HtmlPager(baseUrl, _PageIndex, articleCount, _PageSize, 10);

			this.Hp.Text = hp.GetHtmlNoWrapper();
		}
	}
}
