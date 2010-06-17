using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
    public partial class FamilyMedia : PagingBase
    {
        public Int32 i = 0;
        public Guid UserID;
        public new Int32 PageSize = 30;
        public Int32 MediaType;
        public Guid CategoryID;
        public Channel Category;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");
            this.MediaType = RequestObject.ToInt32("type");
            if (this.MediaType != 2) this.MediaType = 1;
            this.CategoryID = RequestObject.ToGuid("cat");

            if (this.CategoryID == Guid.Empty) this.CategoryID = UtConfig.WorksChannelID;
            this.Category = xCmsFactory.ChannelService.GetChannel(this.CategoryID);

            IList<AnyFile> files;
            int rowCount = 0;
            if (this.UserID != Guid.Empty)
            {
                files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, UserID, MediaType, this.PageIndex, this.PageSize);
                rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(this.CategoryID, true, UserID, MediaType, null);
            }
            else
            {
                files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, null, MediaType, this.PageIndex, this.PageSize);
                rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(this.CategoryID, true, null, MediaType, null);
            }

            if (rowCount > 0)
            {
                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("FamilyMedia.aspx?UserID={0}&type={1}&cat={2}&pIndex=$Page", UserID, MediaType, CategoryID));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }

            this.Repeater1.DataSource = files;
            this.DataBind();
        }
    }
}
