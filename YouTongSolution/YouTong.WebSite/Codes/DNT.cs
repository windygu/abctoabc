using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Discuz.Common;
using Discuz.Forum;
using Discuz.Config;
using Discuz.Entity;

public class DNT
{
	/// <summary>
	/// 登录论坛
	/// </summary>
	/// <param name="username"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	public static int Login(string username, string password)
	{
		try
		{
			Discuz.Config.GeneralConfigInfo config = Discuz.Config.GeneralConfigs.GetConfig();
			int uid = Users.CheckPassword(username, password, true);
			LoginLogs.DeleteLoginLog(DNTRequest.GetIP());

			UserCredits.UpdateUserCredits(uid);

			ForumUtils.WriteUserCookie(uid, Utils.StrToInt(DNTRequest.GetString("expires"), -1), config.Passwordkey, DNTRequest.GetInt("templateid", 0), DNTRequest.GetInt("loginmode", -1));
			Users.UpdateUserCreditsAndVisit(uid, DNTRequest.GetIP());
			return uid;
		}
		catch
		{
			return 0;
		}
	}

	/// <summary>
	/// 获取当前论坛用户名
	/// </summary>
	/// <returns></returns>
	public static string GetCurrentUserName()
	{
		GeneralConfigInfo config = GeneralConfigs.GetConfig();
		OnlineUserInfo oluserinfo = new OnlineUserInfo();
		UserGroupInfo usergroupinfo = new UserGroupInfo();

		oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
		usergroupinfo = UserGroups.GetUserGroupInfo(oluserinfo.Groupid);

		return oluserinfo.Username;
	}

	public static OnlineUserInfo GetCurrentUser()
	{
		GeneralConfigInfo config = GeneralConfigs.GetConfig();
		OnlineUserInfo oluserinfo = new OnlineUserInfo();
		// UserGroupInfo usergroupinfo = new UserGroupInfo();

		oluserinfo = OnlineUsers.UpdateInfo(config.Passwordkey, config.Onlinetimeout);
		// usergroupinfo = UserGroups.GetUserGroupInfo(oluserinfo.Groupid);

		return oluserinfo;
	}


	/// <summary>
	/// 获取用户信息
	/// </summary>
	/// <param name="forumUser"></param>
	/// <returns></returns>
	public static UserInfo GetUserInfoByForumName(string forumUser)
	{
		UserInfo ui = Users.GetUserInfo(forumUser);
		return ui;
	}

	/// <summary>
	/// 用户注册
	/// </summary>
	/// <param name="tmpUsername"></param>
	/// <param name="password"></param>
	/// <returns></returns>
	public static bool Regedit(string tmpUsername, string password)
	{
		try
		{
			//以下为用户注册代码
			Discuz.Config.GeneralConfigInfo config = Discuz.Config.GeneralConfigs.GetConfig();

			UserGroupInfo usergroupinfo = new UserGroupInfo();
			usergroupinfo.Groupid = 10; //新手上路

			//如果用户名符合注册规则, 则判断是否已存在
			// if (Users.Exists(tmpUsername))  
			if (Users.GetUserId(tmpUsername) < 0)
			{
				//
				// 这里提示错误信息"用户名已经存在！"
				//
				return false;
			}

			UserInfo __userinfo = new UserInfo();
			__userinfo.Username = Utils.HtmlEncode(tmpUsername);
			__userinfo.Nickname = Utils.HtmlEncode(DNTRequest.GetString(""));
			__userinfo.Password = Utils.MD5(password);
			__userinfo.Secques = "";// ForumUtils.GetUserSecques(DNTRequest.GetInt("question", 0), DNTRequest.GetString("answer"));
			__userinfo.Gender = DNTRequest.GetInt("gender", 0);
			__userinfo.Adminid = 0;
			__userinfo.Groupexpiry = 0;
			__userinfo.Extgroupids = "";
			__userinfo.Regip = DNTRequest.GetIP();
			__userinfo.Joindate = Utils.GetDateTime();
			__userinfo.Lastip = DNTRequest.GetIP();
			__userinfo.Lastvisit = Utils.GetDateTime();
			__userinfo.Lastactivity = Utils.GetDateTime();
			__userinfo.Lastpost = Utils.GetDateTime();
			__userinfo.Lastpostid = 0;
			__userinfo.Lastposttitle = "";
			__userinfo.Posts = 0;
			__userinfo.Digestposts = 0;
			__userinfo.Oltime = 0;
			__userinfo.Pageviews = 0;
			__userinfo.Credits = 0;
			__userinfo.Extcredits1 = Scoresets.GetScoreSet(1).Init;
			__userinfo.Extcredits2 = Scoresets.GetScoreSet(2).Init;
			__userinfo.Extcredits3 = Scoresets.GetScoreSet(3).Init;
			__userinfo.Extcredits4 = Scoresets.GetScoreSet(4).Init;
			__userinfo.Extcredits5 = Scoresets.GetScoreSet(5).Init;
			__userinfo.Extcredits6 = Scoresets.GetScoreSet(6).Init;
			__userinfo.Extcredits7 = Scoresets.GetScoreSet(7).Init;
			__userinfo.Extcredits8 = Scoresets.GetScoreSet(8).Init;
			//  __userinfo.Avatarshowid = 0;
			__userinfo.Email = "";
			__userinfo.Bday = "";
			__userinfo.Sigstatus = DNTRequest.GetInt("sigstatus", 0);

			if (__userinfo.Sigstatus != 0)
			{
				__userinfo.Sigstatus = 1;
			}
			__userinfo.Tpp = DNTRequest.GetInt("tpp", 0);
			__userinfo.Ppp = DNTRequest.GetInt("ppp", 0);
			__userinfo.Templateid = DNTRequest.GetInt("templateid", 1);
			__userinfo.Pmsound = DNTRequest.GetInt("pmsound", 0);
			__userinfo.Showemail = DNTRequest.GetInt("showemail", 0);

			int receivepmsetting = 1;
			foreach (string rpms in DNTRequest.GetString("receivesetting").Split(','))
			{
				if (rpms != string.Empty)
				{
					int tmp = int.Parse(rpms);
					receivepmsetting = receivepmsetting | tmp;
				}
			}

			if (config.Regadvance == 0)
			{
				receivepmsetting = 7;
			}

			__userinfo.Newsletter = (ReceivePMSettingType)receivepmsetting;
			__userinfo.Invisible = DNTRequest.GetInt("invisible", 0);
			__userinfo.Newpm = 0;
			__userinfo.Medals = "";
			if (config.Welcomemsg == 1)
			{
				__userinfo.Newpm = 1;
			}
			__userinfo.Accessmasks = DNTRequest.GetInt("accessmasks", 0);
			//
			__userinfo.Website = Utils.HtmlEncode(DNTRequest.GetString("website"));
			__userinfo.Icq = Utils.HtmlEncode(DNTRequest.GetString("icq"));
			__userinfo.Qq = Utils.HtmlEncode(DNTRequest.GetString("qq"));
			__userinfo.Yahoo = Utils.HtmlEncode(DNTRequest.GetString("yahoo"));
			__userinfo.Msn = Utils.HtmlEncode(DNTRequest.GetString("msn"));
			__userinfo.Skype = Utils.HtmlEncode(DNTRequest.GetString("skype"));
			__userinfo.Location = Utils.HtmlEncode(DNTRequest.GetString("location"));
			if (usergroupinfo.Allowcstatus == 1)
			{
				__userinfo.Customstatus = Utils.HtmlEncode(DNTRequest.GetString("customstatus"));
			}
			else
			{
				__userinfo.Customstatus = "";
			}


			//__userinfo.Avatar = @"avatars\common\0.gif";
			//  __userinfo.Avatarwidth = 0;
			//  __userinfo.Avatarheight = 0;

			__userinfo.Bio = DNTRequest.GetString("bio");
			__userinfo.Signature = Utils.HtmlEncode(ForumUtils.BanWordFilter(DNTRequest.GetString("signature")));

			PostpramsInfo _postpramsinfo = new PostpramsInfo();
			_postpramsinfo.Usergroupid = usergroupinfo.Groupid;
			_postpramsinfo.Attachimgpost = config.Attachimgpost;
			_postpramsinfo.Showattachmentpath = config.Showattachmentpath;
			_postpramsinfo.Hide = 0;
			_postpramsinfo.Price = 0;
			_postpramsinfo.Sdetail = __userinfo.Signature;
			_postpramsinfo.Smileyoff = 1;
			_postpramsinfo.Bbcodeoff = 1 - usergroupinfo.Allowsigbbcode;
			_postpramsinfo.Parseurloff = 1;
			_postpramsinfo.Showimages = usergroupinfo.Allowsigimgcode;
			_postpramsinfo.Allowhtml = 0;
			_postpramsinfo.Smiliesinfo = Smilies.GetSmiliesListWithInfo();
			_postpramsinfo.Customeditorbuttoninfo = Editors.GetCustomEditButtonListWithInfo();
			_postpramsinfo.Smiliesmax = config.Smiliesmax;

			__userinfo.Sightml = UBB.UBBToHTML(_postpramsinfo);

			//
			__userinfo.Authtime = Utils.GetDateTime();

			//邮箱激活链接验证
			if (config.Regverify == 1)
			{
				__userinfo.Authstr = ForumUtils.CreateAuthStr(20);
				__userinfo.Authflag = 1;
				__userinfo.Groupid = 8;
				//SendEmail(tmpUsername, DNTRequest.GetString("password").Trim(), DNTRequest.GetString("email").Trim(), __userinfo.Authstr);
			}
			//系统管理员进行后台验证
			else if (config.Regverify == 2)
			{
				__userinfo.Authstr = DNTRequest.GetString("website");
				__userinfo.Groupid = 8;
				__userinfo.Authflag = 1;
			}
			else
			{
				__userinfo.Authstr = "";
				__userinfo.Authflag = 0;
				__userinfo.Groupid = UserCredits.GetCreditsUserGroupId(0).Groupid;
			}
			__userinfo.Realname = DNTRequest.GetString("realname");
			__userinfo.Idcard = DNTRequest.GetString("idcard");
			__userinfo.Mobile = DNTRequest.GetString("mobile");
			__userinfo.Phone = DNTRequest.GetString("phone");

			int uid = Users.CreateUser(__userinfo);


			if (config.Welcomemsg == 1)
			{
				PrivateMessageInfo __privatemessageinfo = new PrivateMessageInfo();

				string curdatetime = Utils.GetDateTime();
				// 收件箱
				__privatemessageinfo.Message = config.Welcomemsgtxt;
				__privatemessageinfo.Subject = "欢迎您的加入! (请勿回复本信息)";
				__privatemessageinfo.Msgto = __userinfo.Username;
				__privatemessageinfo.Msgtoid = uid;
				__privatemessageinfo.Msgfrom = PrivateMessages.SystemUserName;
				__privatemessageinfo.Msgfromid = 0;
				__privatemessageinfo.New = 1;
				__privatemessageinfo.Postdatetime = curdatetime;
				__privatemessageinfo.Folder = 0;
				PrivateMessages.CreatePrivateMessage(__privatemessageinfo, 0);
			}

			if (config.Regverify == 0)
			{
				UserCredits.UpdateUserCredits(uid);
				//ForumUtils.WriteUserCookie(uid, -1, config.Passwordkey);
				OnlineUsers.UpdateAction(0, UserAction.Register.ActionID, 0, config.Onlinetimeout);

				Statistics.ReSetStatisticsCache();

				//SetUrl("index.aspx");
				//SetMetaRefresh();
				//SetShowBackLink(false);
				//这里添加代码提示“注册成功, 返回登录页"并return退出
				//...
				//
				return true;
			}
			else
			{
				//SetUrl("index.aspx");
				//SetMetaRefresh(5);
				//SetShowBackLink(false);

				if (config.Regverify == 1)
				{
					//这里添加代码提示“注册成功, 请您到您的邮箱中点击激活链接来激活您的帐号"并return退出
					//...
					//
				}

				if (config.Regverify == 2)
				{
					//这里添加代码提示“您注册成功, 但需要系统管理员审核您的帐户后才可登陆使用"并return退出
					//...
					//
				}
				return true;

			}
		}
		catch
		{
			return false;
		}

	}
}