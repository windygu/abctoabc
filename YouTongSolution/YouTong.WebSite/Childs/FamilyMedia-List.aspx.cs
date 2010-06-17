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
using Itfort.Web;
using YouTong.WebSite.Codes;
using YouTong.Model;
using System.Collections.Generic;
using WebBasics.Cms.Model;
using MySoft.Data;

namespace YouTong.WebSite.Childs
{
    public partial class FamilMedia_List : PagingBase
    {
        public Guid UserID;
        public Guid ID;
        public WebBasics.Member.Model.User userB;
        public new Int32 PageSize = 30;
        public Category category;
        public int MediaType;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = RequestObject.ToGuid("userid");
            ID = RequestObject.ToGuid("id");

            userB = WebBasics.Member.Common.MemberFactory.Instance.UserService.GetUser(UserID);
            category = CategoryService.Instance.GetCategory(ID);

            IList<Guid> guidList = InCategoryService.Instance.GetEntityIDs(ID, PageIndex, PageSize);
            int rowCount = InCategoryService.Instance.GetEntityCount(ID);

            #region 显示列表
            this.MediaType = RequestObject.ToInt32("type");
            if (this.MediaType != 2) this.MediaType = 1;

            if (guidList.Count > 0)
            {
                IList<AnyFile> anyfileList = xCmsFactory.AnyFileService.GetAnyFiles(guidList.ToArray());
                this.rp_AnyFiles.DataSource = anyfileList;
                this.rp_AnyFiles.DataBind();


                IDataPage page = new DataPage(PageSize);
                page.CurrentPageIndex = PageIndex;
                page.RowCount = rowCount;
                MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page,
                    string.Format("FamilyMedia-List.aspx?userid={0}&id={1}&pIndex=$Page", UserID, ID));
                hPager.Style = HtmlPagerStyle.Custom;
                this.lt_Page.Text = hPager.ToString();
            }
            #endregion
        }
    }
}
