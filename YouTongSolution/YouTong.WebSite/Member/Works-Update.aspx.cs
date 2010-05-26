using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite.Member
{
	public partial class Works_Update : PageAuth
	{
		public Guid WorksID;
		public AnyFile Works;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksID = RequestObject.ToGuid("id");
			this.Works = xCmsFactory.AnyFileService.GetAnyFile(this.WorksID);

			if (!this.IsPostBack)
			{
				this.Works_Title.Text = this.Works.Title;
				this.Works_OccurTime.Text = this.Works.OccurTime.ToString("yyyy-MM-dd");
				this.Works_Tags.Text = this.Works.Tags;
				this.Works_Summary.Text = this.Works.Summary;

				try
				{
					var channels = WorksAction.GetOffiicalCategories();

					foreach (var channel in channels)
					{
						this.Works_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
					}

					this.Works_ChannelID.SelectedValue = this.Works.ChannelID.Value.ToString();
				}
				catch { }
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{

		}
	}
}
