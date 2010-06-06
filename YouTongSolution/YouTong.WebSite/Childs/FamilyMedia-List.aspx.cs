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

namespace YouTong.WebSite.Childs
{
    public partial class FamilMedia_List : PageBase
    {
        public Guid UserID;
        public Guid ID;
        public WebBasics.Member.Model.User userB;
        public Int32 PageIndex, PageSize;
        public Category category;
        public int MediaType;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = RequestObject.ToGuid("userid");
            ID = RequestObject.ToGuid("id");
            HtmlPager.GetPagerParmsFromRequest(out PageIndex, out PageSize, 20);

            userB = WebBasics.Member.Common.MemberFactory.Instance.UserService.GetUser(UserID);
            category = CategoryService.Instance.GetCategory(ID);

            IList<Guid> guidList = InCategoryService.Instance.GetEntityIDs(ID, PageIndex, PageSize);
            int rowCount = InCategoryService.Instance.GetEntityCount(ID);

            #region 显示列表
            this.MediaType = RequestObject.ToInt32("type");
            if (this.MediaType != 2) this.MediaType = 1;

            IList<AnyFile> anyfileList = xCmsFactory.AnyFileService.GetAnyFiles(guidList.ToArray());

            //IList<AnyFile> anyfileList = xCmsFactory.AnyFileService.GetAnyFiles(ID, true, this.UserID, MediaType, PageIndex, PageSize);
            //int rowCount = xCmsFactory.AnyFileService.GetAnyFileCount(ID, true, this.UserID, MediaType, null);
            this.rp_AnyFiles.DataSource = anyfileList;
            this.rp_AnyFiles.DataBind();

            var baseUrl = "FamilyMedia-List.aspx?UserID=" + UserID + "&id" + ID + "&Page=($ID)&Size=" + PageSize;
            HtmlPager hp = new HtmlPager(baseUrl, PageIndex, rowCount, PageSize);
            this.lt_Page.Text = hp.GetHtml(rowCount, PageSize);
            #endregion
        }
    }
}
