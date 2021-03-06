﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using Itfort.Web;
using YouTong.WebSite.Codes;
using Itfort.Web.Binder;

namespace YouTong.WebSite.Member
{
	public partial class FamilyMedia_Update : PageAuth
	{
		public Guid MediaID;
		public AnyFile Media;

		protected void Page_Load(object sender, EventArgs e)
		{
			this.MediaID = RequestObject.ToGuid("id");
			this.Media = xCmsFactory.AnyFileService.GetAnyFile(this.MediaID);

			if (!this.IsPostBack)
			{
				this.Media_Title.Text = this.Media.Title;
				this.Media_OccurTime.Text = this.Media.OccurTime.ToString("yyyy-MM-dd");
				this.Media_Tags.Text = this.Media.Tags;
				this.Media_Summary.Text = this.Media.Summary;

				try
				{
					var channels = FamilyMediaAction.GetMediaCategories();

					foreach (var channel in channels)
					{
						this.Media_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
					}

					this.Media_ChannelID.SelectedValue = this.Media.ChannelID.Value.ToString();
				}
				catch { }
			}
		}

		protected void BtnOK_Click(object sender, EventArgs e)
		{
			var xMedia = ConverterFactory.ConvertTo<AnyFile>(Request.Params, "Media_");

			this.Media.Title = xMedia.Title;
			this.Media.OccurTime = xMedia.OccurTime;
			this.Media.Tags = xMedia.Tags;
			this.Media.Summary = xMedia.Summary;
			this.Media.ChannelID = xMedia.ChannelID;

			xCmsFactory.AnyFileService.UpdateAnyFile(this.Media);

			Response.Redirect("/childs/familymedia-detail.aspx?id=" + Media.ID);
		}
	}
}
