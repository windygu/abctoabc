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
using Itfort.Web.Binder;
using YouTong.Model;
using System.Collections.Generic;

namespace YouTong.WebSite.Childs
{
    public partial class ChildInfo : PageAuth
    {
        public Child child;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInfo();

                ShowResume();
            }
            else
                child = xUtFactory.ChildService.GetFirstChild(UserID);
        }

        protected void lb_Add_Click(object sender, EventArgs e)
        {
            Resume resume = ConverterFactory.ConvertTo<Resume>(Request.Form, "Resume_");
            resume.EndDate = Convert.ToDateTime(Resume_EndDate.Text);
            resume.ID = Guid.NewGuid();
            resume.ChildID = FirstChild.ID;
            ResumeService resumeS = new ResumeService();
            resumeS.AddResume(resume);

            ShowResume();
        }

        protected void lb_SaveInfo_Click(object sender, EventArgs e)
        {
            var updateChild = ConverterFactory.ConvertTo<Child>(Request.Form, "Child_");
            updateChild.ParentID = this.UserID;
            updateChild.ID = FirstChild.ID;
            if (updateChild.Birthday == DateTime.MinValue) updateChild.Birthday = DateTime.Parse("1899-1-1");


            xUtFactory.ChildService.UpdateChild(updateChild);

            ShowInfo();
        }

        void ShowInfo()
        {
            child = xUtFactory.ChildService.GetFirstChild(UserID);
            if (child != null)
            {
                this.Child_Name.Text = child.Name;
                this.Child_NikcName.Text = child.NikcName;
                if (child.Gender == 0)
                    this.Child_Gender.SelectedIndex = 0;
                else
                    this.Child_Gender.SelectedIndex = 1;
                this.Child_Birthday.Text = child.Birthday.ToString("yyyy-MM-dd");

                this.Child_SchoolID.Value = child.CurrentSchool;

                this.Child_CurrentGrade.Value = child.CurrentGrade.ToString();
                this.Child_CurrentClass.Value = child.CurrentClass.ToString();
            }
        }

        void ShowResume()
        {
            #region 绑定数据
            ResumeService resumeS = new ResumeService();
            IList<Resume> resumeList = resumeS.GetResumesByChild(FirstChild.ID);
            this.rp_Resume.DataSource = resumeList;
            this.rp_Resume.DataBind();
            #endregion
        }
    }
}
