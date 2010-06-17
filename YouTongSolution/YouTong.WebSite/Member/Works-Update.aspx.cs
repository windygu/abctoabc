using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using Itfort.Web.Binder;

namespace YouTong.WebSite.Member
{
	public partial class Works_Update : PageAuth
	{
		public Guid WorksID;
        public Guid CategoryID;
        public Int32 WorksType;
		public AnyFile Works;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.WorksID = RequestObject.ToGuid("id");
            this.WorksType = RequestObject.ToInt32("type");
            if (this.WorksType != 2) this.WorksType = 1;
            this.CategoryID = RequestObject.ToGuid("cat");
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
            var xWorks = ConverterFactory.ConvertTo<AnyFile>(Request.Params, "Works_");

            this.Works.Title = xWorks.Title;
            this.Works.OccurTime = xWorks.OccurTime;
            this.Works.Tags = xWorks.Tags;
            this.Works.Summary = xWorks.Summary;
            this.Works.ChannelID = xWorks.ChannelID;

            try
            {
                xCmsFactory.AnyFileService.UpdateAnyFile(Works);
                JsAlert("修改作品成功");
            }
            catch { JsAlert("修改作品失败"); }
		}
	}
}
