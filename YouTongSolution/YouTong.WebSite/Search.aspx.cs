using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using YouTong.WebSite.Codes;
using Itfort.Web;
using WebBasics.Cms.Model;
using System.Collections.Generic;
using MySoft.Data;

namespace YouTong.WebSite
{
    public partial class Search : PagingBase
    {
        public Int32 i = 0;
        public new int PageSize=30;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid channelId = RequestObject.ToGuid("type");
            string text = RequestObject.ToString("text");

            int rowCount;
            IList<AnyFile> list =
                xCmsFactory.AnyFileService.GetAnyFiles(channelId, text, PageIndex, PageSize, out rowCount);

            this.rp_Search.DataSource = list;
            this.rp_Search.DataBind();
            if (rowCount > 0)
            {
                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("/Search.aspx?type={0}&text={1}&pIndex=$Page", channelId, text));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }
        }
    }
}
