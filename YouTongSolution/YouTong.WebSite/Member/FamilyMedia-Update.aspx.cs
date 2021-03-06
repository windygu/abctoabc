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
using YouTong.Model;

namespace YouTong.WebSite.Member
{
    public partial class FamilyMedia_Update : PageAuth
    {
        public Guid MediaID;
        public Guid CatagoryID;
        public AnyFile Media;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MediaID = RequestObject.ToGuid("id");
            this.CatagoryID = RequestObject.ToGuid("cid");
            this.Media = xCmsFactory.AnyFileService.GetAnyFile(this.MediaID);

            if (!this.IsPostBack)
            {
                this.Media_Title.Text = this.Media.Title;
                this.Media_OccurTime.Text = this.Media.OccurTime.ToString("yyyy-MM-dd");
                this.Media_Tags.Text = this.Media.Tags;
                this.Media_Summary.Text = this.Media.Summary;


                var channels = FamilyMediaAction.GetOfficialCategories();

                foreach (var channel in channels)
                {
                    this.Media_ChannelID.Items.Add(new ListItem(channel.Name, channel.ID.ToString()));
                    if (channel.ID == this.Media.ChannelID)
                        this.Media_ChannelID.SelectedIndex = this.Media_ChannelID.Items.Count - 1;
                }
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

            try
            {
                xCmsFactory.AnyFileService.UpdateAnyFile(this.Media);
                JsAlert("修改亲子影像成功");
            }
            catch { JsAlert("修改亲子影像失败"); }
        }
    }
}
