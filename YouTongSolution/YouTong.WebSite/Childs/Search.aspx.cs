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
using YouTong.Model;
using System.Collections.Generic;
using Itfort.Web;

namespace YouTong.WebSite.Childs
{
    public partial class Search : PagingBase
    {
        public Int32 i = 0;
        public int City;
        public int Region;
        public int Level;
        public int SchoolID;
        public new int PageSize = 30;

        protected void Page_Load(object sender, EventArgs e)
        {
            City = RequestObject.ToInt32("City");
            Region = RequestObject.ToInt32("Region");
            Level = RequestObject.ToInt32("Level");
            SchoolID = RequestObject.ToInt32("SchoolID");
            int rowCount;
            IList<Child> list =
                YouTong.ChildService.Instance.GetChilds(City, Region, Level, SchoolID, PageIndex, PageSize, out rowCount);
            this.rp_Search.DataSource = list;
            this.rp_Search.DataBind();
            if (rowCount > 0)
            {
                MySoft.Data.IDataPage page = new MySoft.Data.DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("/childs/Search.aspx?City={0}&Region={1}&Level={2}&SchoolID={3}&pIndex=$Page",
                    City, Region, Level, SchoolID));
                hPager.Style = MySoft.Data.HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }

            System.Text.StringBuilder sbJS = new System.Text.StringBuilder();
            sbJS.Append("<script type='text/javascript'>");
            sbJS.AppendFormat("var city = '{0}';", City);
            sbJS.AppendFormat("var region = '{0}';", Region);
            sbJS.AppendFormat("var level = '{0}';", Level);
            sbJS.AppendFormat("var school = '{0}';", SchoolID);
            sbJS.Append("</script>");
            this.ltr_JS.Text = sbJS.ToString();
        }

        protected int GetCommentCounts(object guid, string name)
        {
            return CommentService.Instance.GetCommentCount(name, new Guid(guid.ToString()));
        }
    }
}
