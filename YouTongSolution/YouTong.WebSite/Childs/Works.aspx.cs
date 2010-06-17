using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Itfort.Web;
using WebBasics.Cms.Common;
using WebBasics.Cms.Model;
using YouTong.WebSite.Codes;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
    public partial class Works : PagingBase
    {
        public Int32 i = 0;
        public Guid UserID;
        public new int PageSize = 30;
        public Int32 WorksType;
        public Guid CategoryID;
        public Channel Category;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserID = RequestObject.ToGuid("userid");
            this.WorksType = RequestObject.ToInt32("type");
            if (this.WorksType != 2) this.WorksType = 1;
            this.CategoryID = RequestObject.ToGuid("cat");

            if (this.CategoryID == Guid.Empty) this.CategoryID = UtConfig.WorksChannelID;
            this.Category = xCmsFactory.ChannelService.GetChannel(this.CategoryID);

            IList<AnyFile> files;
            int rowCount = 0;
            if (this.UserID != Guid.Empty)
            {
                files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, UserID, WorksType, this.PageIndex, this.PageSize);
                rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(this.CategoryID, true, UserID, WorksType, null);
            }
            else
            {
                files = xCmsFactory.AnyFileService.GetAnyFiles(this.CategoryID, true, null, WorksType, this.PageIndex, this.PageSize);
                rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(this.CategoryID, true, null, WorksType, null);
            }
            if (rowCount > 0)
            {
                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("Works.aspx?UserID={0}&type={1}&cat={2}&pIndex=$Page", UserID, WorksType, CategoryID));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }

            this.RepeaterWorks.DataSource = files;
            this.DataBind();
        }
    }
}
