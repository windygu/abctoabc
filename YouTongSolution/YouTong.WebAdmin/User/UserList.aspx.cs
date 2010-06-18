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
using WebBasics.Member;
using System.Collections.Generic;
using MySoft.Data;

namespace YouTong.WebAdmin.User
{
    public partial class UserList : PageAuth
    {
        public new int PageSize = 20;
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<WebBasics.Member.Model.User> list=new List<WebBasics.Member.Model.User>();
            int rowCount = 0;
            if (RadioButton1.Checked)
            {
                list = UserService.Instance.GetUsers(PageIndex, PageSize);
                rowCount = UserService.Instance.GetUserCount();                
            }
            else
            {
                list = UserService.Instance.GetDeletedUsers(PageIndex, PageSize);
                rowCount = UserService.Instance.GetDeletedUserCount();
            }

            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();

            IDataPage page = new DataPage(PageSize);
            page.CurrentPageIndex = PageIndex;
            page.RowCount = rowCount;
            MySoft.Data.HtmlPager hPager = new MySoft.Data.HtmlPager(page, "UserList.aspx?pIndex=$Page");
            hPager.Style = HtmlPagerStyle.Custom;
            this.Hp.Text = hPager.ToString();
        }
    }
}
