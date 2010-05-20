<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expo.aspx.cs" Inherits="YouTong.WebSite.Activities.Disney.Expo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>世博活动</title>
	<link rel="stylesheet" type="text/css" href="css/css.css" />
	<link href="../../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		function join() {
			if ($("#join_true").attr("checked")) {
				location = "join.aspx";
			}
			else {
				alert("请先同意参加活动");
			}
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<div class="main_container">
		    <!--<ut:WebHeader ID="WebHeader" runat="server" />-->
			<div class="m_top">
				<img class="ico1" src="images/ico1.jpg" /><img src="images/top1.jpg" border="0" usemap="#Map" />
				
				<div style="text-align:center; margin-bottom:10px; margin-top:10px;"><img  src="images/北京活动banner.jpg" /></div>
				</div>
			
			<div class="m_left" style="position: absolute;">
				<div class="disney_box">
					<div style="float: left; width: 220px; height: 300px;">
					</div>
					<div style="width: 386px; float: left;">
					<p align="left" style="">
						<b style="font-size:12px;">“我爱北京，大家一起赛”2010年北京市少年儿童知识竞赛</b></p>
					<p style="">
						“赫赫京都千百年，钟灵毓秀萃龙渊。始由金国迁燕地，及至赤都照蓟川。”</p>
<p>
   如此气势磅礴的诗句，也只有北京这样的城市才够以匹配。而今，您学习、生活在北京这座城市中，您对北京又有着多少的认知和了解呢？ </p>
     <p>为了加深大家对北京的认知及了解，体现出当今“人文北京，绿色北京”的京城文化，北京市妇女联合会儿童工作部、北京市家庭教育研究会推出了“我爱北京，大家一起赛”主题活动，让大家可以从多方面地了解北京历史的变迁发展过程、城市概况、风土人情以及民风习俗，从而更好地激发大家热爱北京、热爱故乡的情怀。 </p>
    <p> 相信，您的参与定能更好的描绘出“北海清波浮画舫，香山红叶染霜天。华夏血脉情相系，九州同心亿众欢”这般的美丽画卷。我们更相信，北京有了您赞许和期待，定能屹立于世界之巅！</p>
<p>
     我们期待您全家的参与，我们更感谢您和您家人的行动。让我们一起为北京更美好的明天加油、喝彩！</p></div>
					<table border="0" cellspacing="0" cellpadding="0" style="display: block; width: 550px; position: absolute; top: 360px; left: 35px;">
						<tr>
							<td>
								&nbsp;
							</td>
							<td height="30">
								&nbsp;
							</td>
							<td>
								&nbsp;
							</td>
						</tr>
						<tr>
							<td width="30">
								&nbsp;
							</td>
							<td>
								为了感谢您对活动的支持，我们将邀请您参加“迪士尼英语亲子家庭日活动”。 和您一起激发孩子的学次热情，在欢乐的卡通故事中畅快的学习英语和利礼仪，在独特的亲子互动中体验无限的乐趣，更为世博会做更好的准备。<br />
								您是否愿意参加?
								<input type="radio" class="checkbox" name="join" id="join_true" checked="checked" />
								愿意
								<input type="radio" class="checkbox" name="join" id="join_false" />
								不愿意
							</td>
							<td width="30">
								&nbsp;
							</td>
						</tr>
						<tr>
							<td height="60">
								&nbsp;
							</td>
							<td align="center" valign="bottom">
								<% if (!this.IsAnonymous) %>
								<% { %>
								<% if (this.ActivityJoined != null) %>
								<% { %>
								你已经参与过该活动，活动编号：disneyexpo_<%=this.ActivityJoined.Number.ToString()%>&nbsp;&nbsp;&nbsp;<a href="http://www.no1child.com/activities/disney/disneyext/index.html">再浏览活动网站</a>
								<% } %>
								<% else %>
								<% { %>
								<a href="javascript:join()" class="disney_a1"></a>
								<% } %>
								<% } %>
								<% else %>
								<% { %>
								你尚未登录，请在右边登录框登录
								<% } %>
							</td>
							<td>
								&nbsp;
							</td>
						</tr>
					</table>
				</div>
			</div>
			<div class="m_right">
				<div class="right1">
					<% if (this.IsAnonymous) %>
					<% { %>
					<table width="255" border="0" cellspacing="0" cellpadding="0" class="login">
						<tr>
							<td height="48" width="255" align="left" style="background: url(images/login_bg1.gif) no-repeat; position: relative;">
								<input type="text" name="User_UserName" id="User_UserName" class="t1" />
								<input type="password" name="User_Password" id="User_Password" class="t2" />
								<a href="javascript:$('#BtnSignIn').click()" class="btn1"></a>
							</td>
						</tr>
						<tr>
							<td class="mr_t1">
								<div style="display: none">
									<asp:Button ID="BtnSignIn" runat="server" Text="登录" OnClick="BtnSignIn_Click" /></div>
								<span>
									<asp:Literal ID="LiInfo" runat="server"></asp:Literal></span>
							</td>
						</tr>
						<tr>
							<td height="40" align="center">
								<img src="images/line1.gif" width="246" height="2" />
							</td>
						</tr>
						<tr>
							<td class="mr_t2">
								优童网用户无需<a title="注册" href="http://www.no1child.com/Member/Register.aspx">注册</a>，请直接登录
							</td>
						</tr>
					</table>
					<% } %>
					<% else %>
					<% { %>
					<% var myChild = this.GetFirstChild(); %>
					<table width="255" cellspacing="0" cellpadding="0" border="0" class="login">
						<tbody>
							<tr>
								<td width="75" valign="top" align="left" class="mr1_img">
									<img src="<%= DataCache.GetHeadPicture(myChild.HeadPicture) %>" />
								</td>
								<td width="180" valign="top" align="left" class="mr_t3">
									用户：<%= this.User.Name %><br>
									我的优童：<span><%= myChild.Name %>&nbsp;&nbsp;<%= myChild.Age %>岁</span><br />
									消息：<span>0</span>条<br />
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<a class="mr_a1" href="/member/index.aspx">[个人帐号管理]</a>&nbsp;&nbsp;
									<a class="mr_a1" href="/member/signout.aspx?back=/activities/disney/expo.aspx">[退出登录]</a>
								</td>
							</tr>
							<tr>
								<td valign="middle" height="40" align="center" colspan="2">
									<img width="246" height="2" src="/disney/images/line1.gif">
								</td>
							</tr>
							<tr>
								<td class="mr_t4" colspan="2">
									<% if (this.ActivityJoined != null) %>
									<% { %>
									你已经参与过该活动<br />活动编号：disneyexpo_<%=this.ActivityJoined.Number.ToString()%><br /><a href="http://www.no1child.com/activities/disney/disneyext/index.html">再浏览活动网站</a>
									<% } %>
								</td>
							</tr>
						</tbody>
					</table>
					<% } %>
				</div>
			</div>
			<div style="height: 300px;">
			</div>
		</div>
		<div class="footer">
			<div class="footer_main">
				<ul>
					<li>
						<a href="#">关于优童</a></li>
					<li>
						<a>|</a></li>
					<li>
						<a href="#">提交问题</a></li>
					<li>
						<a>|</a></li>
					<li>
						<a href="#">联系我们</a></li>
					<li>
						<a>|</a></li>
					<li>
						<a href="#">版权声明</a></li>
					<li>
						<a>|</a></li>
					<li>
						<a href="#">关于隐私</a></li>
					<li>
						<a>|</a></li>
					<li>
						<a href="#">合作伙伴</a></li>
				</ul>
				<div class="clear">
				</div>
			</div>
			<p>
				沪ICP 00000000号 www.no1child.com 2010-2011</p>
		</div>
		<map name="Map" id="Map">
			<area shape="rect" coords="221, 33, 268, 62" href="/" />
			<area shape="rect" coords="314, 32, 386, 64" href="/Member/MyChild.aspx" />
			<area shape="rect" coords="423, 31, 494, 64" href="/childs/" />
			<area shape="rect" coords="529, 33, 603, 63" href="/Jianshezhong.aspx" />
			<area shape="rect" coords="626, 31, 703, 63" href="http://old.no1child.com/bbs/index.aspx" />
			<area shape="rect" coords="736, 31, 811, 61" href="/Jianshezhong.aspx" />
			<area shape="rect" coords="850, 32, 924, 65" href="/Jianshezhong.aspx" />
		</map>
		<map name="Map3" id="Map3">
			<area shape="rect" coords="565, 0, 690, 36" href="#" />
		</map>
	</div>
	</form>
</body>
</html>
