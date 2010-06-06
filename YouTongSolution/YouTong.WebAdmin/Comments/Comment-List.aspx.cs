using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms;

namespace YouTong.WebAdmin.Comments
{
	public partial class Comment_List : System.Web.UI.Page
	{
		public string entity;
		public int rowCount, pageIndex, pageSize;

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BindUI()
		{
			this.entity = RequestObject.ToString("entity");
			HtmlPager.GetPagerParmsFromRequest(out pageIndex, out pageSize);

			var dataSource = CommentService.Instance.GetComments(entity, pageIndex, pageSize);
			var entityIdList = new List<Guid>();

			foreach (var item in dataSource)
			{
				entityIdList.Add(item.EntityID);
			}

			var entityList = ArticleService.Instance.GetArticles(entityIdList.ToArray());

			this.Repeater1.DataSource = dataSource;
			this.Repeater1.DataBind();
		}
	}
}
