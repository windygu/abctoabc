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
using Itfort.Web;

namespace YouTong.WebSite.Childs
{
    public partial class ChildInfo : PageBase
    {
        public Child child;
        public Guid UserID;
        public School school;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = RequestObject.ToGuid("userid");
            child = xUtFactory.ChildService.GetFirstChild(UserID);

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
            resume.ChildID = child.ID;
            ResumeService resumeS = new ResumeService();
            resumeS.AddResume(resume);

            ShowResume();
        }

        protected void lb_SaveInfo_Click(object sender, EventArgs e)
        {
            var updateChild = ConverterFactory.ConvertTo<Child>(Request.Form, "Child_");
            updateChild.ParentID = this.UserID;
            updateChild.ID = child.ID;
            if (updateChild.Birthday == DateTime.MinValue) updateChild.Birthday = DateTime.Parse("1899-1-1");

            xUtFactory.ChildService.UpdateChild(updateChild);
            child = updateChild;

            ShowInfo();
        }

        void ShowInfo()
        {
            
            if (child != null)
            {
                this.Child_Name.Text = child.Name;
                this.Child_NikcName.Text = child.NikcName;
                if (child.Gender == 1)
                    this.Child_Gender.Items[0].Selected = true;
                else
                    this.Child_Gender.Items[1].Selected = true;
                this.Child_Birthday.Text = child.Birthday.ToString("yyyy-MM-dd");

                this.Child_SchoolID.Value = child.CurrentSchool;

                this.Child_CurrentGrade.Value = child.CurrentGrade.ToString();
                this.Child_CurrentClass.Value = child.CurrentClass.ToString();

                school = YouTong.Data.DbSchool.Instance.GetSchool(child.SchoolID);

                System.Text.StringBuilder sbJS = new System.Text.StringBuilder();
                sbJS.Append("<script type='text/javascript'>");
                sbJS.AppendFormat("var city = '{0}';", this.child.City);
                sbJS.AppendFormat("var region = '{0}';", this.child.Region);
                sbJS.AppendFormat("var level = '{0}';", this.school.Level);
                sbJS.AppendFormat("var school = '{0}';", this.school.Name);
                sbJS.AppendFormat("var talents = '{0}';", this.child.Talent);
                sbJS.Append("</script>");
                this.ltr_JS.Text = sbJS.ToString();
            }
        }

        void ShowResume()
        {
            #region 绑定数据
            ResumeService resumeS = new ResumeService();
            IList<Resume> resumeList = resumeS.GetResumesByChild(child.ID);
            this.rp_Resume.DataSource = resumeList;
            this.rp_Resume.DataBind();
            #endregion
        }
    }
}
