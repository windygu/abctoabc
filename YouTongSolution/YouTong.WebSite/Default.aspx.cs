﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBasics.Cms.Model;
using YouTong.Common;
using YouTong.Model;
using YouTong.WebSite.Codes;

namespace YouTong.WebSite
{
    public partial class _Default : PageBase
    {
        public Int32 i;
        public IList<Channel> WorksCategories;
        public IList<Channel> MediaCategories;
        public IList<Article> list_Blogs;
        public IList<Article> 网站动态;
        public Article StarArticle;
        public Child StarChild;
        public Article StarTitleArticle;
        public int anyFilesCount;
        public int registerCount;
        public IList<Comment> workComments;

        protected void Page_Load(object sender, EventArgs e)
        {
            registerCount = WebBasics.Member.UserService.Instance.GetUserCount();

            网站动态 = xCmsFactory.ArticleService.GetArticles(
                    new Guid("7501879d-2af8-e66d-f089-29f46b4bab03"), true, 1, 5);
            this.Repeater网站动态.DataSource = 网站动态;

            //才艺
            this.WorksCategories = WorksAction.GetOffiicalCategories();
            //亲子影像分类
            this.MediaCategories = FamilyMediaAction.GetOfficialCategories();
            //本月优童秀
            StarArticle =
                xCmsFactory.ArticleService.GetArticle(new Guid("4301849d-e94a-b816-b469-7adfd24ea9fa"));

            this.StarChild = xUtFactory.ChildService.GetChild(new Guid(StarArticle.Summary));//faff0cdc-fc75-4cc9-8300-149a57fde995

            this.StarTitleArticle = xCmsFactory.ArticleService.GetArticle(new Guid("4601849d-62de-0645-3f52-8c442745912f"));


            Guid workGuid = Guid.NewGuid();
            if (WorksCategories.Count > 0)
                workGuid = WorksCategories[0].ID;
            else
                workGuid = UtConfig.WorksChannelID;
            //得到第一个分类的作品或所有作品
            var workses = xCmsFactory.AnyFileService.GetAnyFiles(workGuid, true, 1, 6);
            //得到所有作品
            anyFilesCount = xCmsFactory.AnyFileService.GetAnyFileCount(UtConfig.WorksChannelID, true);
            //亲子影像
            Guid mediaID = Guid.Empty;
            if (MediaCategories.Count > 0)
                mediaID = MediaCategories[0].ID;
            else
                mediaID = UtConfig.FamilyMediaChannelID;
            var medias = xCmsFactory.AnyFileService.GetAnyFiles(mediaID, true, 1, 6);
            this.RepeaterMedia.DataSource = medias;

            var childs = xUtFactory.ChildService.GetChilds(1, 6);
            //斗秀场
            var douxiuNews = xCmsFactory.ArticleService.GetArticles(UtConfig.DouXiuChannelID, true, 1, 5);
            this.RepeaterDouXiu.DataSource = douxiuNews;
            //优童新闻
            var huodongNews = xCmsFactory.ArticleService.GetArticles(UtConfig.HuoDongChannelID, true, 1, 5);
            this.RepeaterHuoDong.DataSource = huodongNews;

            var topWorkses = workses;
            this.RepeaterTopWorks.DataSource = topWorkses;

            var topChilds = childs;
            this.RepeaterTopChild.DataSource = topChilds;

            if (this.StarChild != null)
            {
                Article StarFileArticle =
                    xCmsFactory.ArticleService.GetArticle(new Guid("4601849d-4042-f8e4-1826-39ddfb48813f"));
                List<Guid> listGuid = new List<Guid>();
                string[] sfaArray = StarFileArticle.Summary.Split('|');
                foreach (string item in sfaArray)
                {
                    listGuid.Add(new Guid(item));
                }

                var starChildWorkses = xCmsFactory.AnyFileService.GetAnyFiles(listGuid.ToArray());//xCmsFactory.AnyFileService.GetAnyFiles(UtConfig.WorksChannelID, true, this.StarChild.ParentID.Value, null, 1, 4);
                this.RepeaterStarChildWorks.DataSource = starChildWorkses;
            }

            //才艺秀
            this.RepeaterWorks.DataSource = workses;

            this.RepeaterChild.DataSource = childs;

            #region 热门话题
            IList<Article> hotTopicList = xCmsFactory.ArticleService.GetArticles(new Guid("8401849d-ddb7-dab8-a033-4b7edc4c97f4 "), false, 1, 10);
            this.rp_HotTopic.DataSource = hotTopicList;
            #endregion

            #region 博客
            list_Blogs = xCmsFactory.ArticleService.GetArticles(UtConfig.BlogChannelID, true, 1, 25);
            this.rp_Blogs.DataSource = this.list_Blogs;

            this.DataBind();
            #endregion


            this.DataBind();
        }

        protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var username = Request["User_UserName"];
                var password = Request["User_Password"];

                this.SignIn(username, password, false);

                DNT.Login(username, password);

                Response.Redirect("Default.aspx");
            }
            catch
            {
                this.JsAlert("登录失败");
            }
        }

        protected Child GetFirstChild()
        {
            var childs = UtFactory.Instance.ChildService.GetChildsByParent(this.User.ID);
            return childs.Count == 0 ? null : childs[0];
        }

        protected string GetItemByObject(object summary, int index)
        {
            string result = string.Empty;
            if (summary != null)
            {
                string[] strArray = summary.ToString().Split('|');
                if (strArray.Length > index)
                    result = strArray[index];
            }
            return result;
        }

        protected string GetComment(object guid, string name)
        {
            string result = string.Empty;
            string title = string.Empty;
            string value = "评论";

            if (name == Codes.EntityName.ChildCommentEntity)
                value = "寄语";
            workComments = CommentService.Instance.GetComments(name, new Guid(guid.ToString()), 1, 1);
            if (workComments != null && workComments.Count > 0)
            {
                title = workComments[0].Title;
                if (workComments[0].Title.Length > 15)
                    title = workComments[0].Title.Substring(0, 15);
                result = string.Format("{0}[{1}{2}]", title, DataCache.GetUserNameByUserID(workComments[0].Reviewer.Value), value);
            }
            return result;
        }

        protected int GetCommentCounts(object guid, string name)
        {
            return CommentService.Instance.GetCommentCount(name, new Guid(guid.ToString()));
        }
    }
}
