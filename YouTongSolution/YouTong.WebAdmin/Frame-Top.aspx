<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frame-Top.aspx.cs" Inherits="YouTong.WebAdmin.Frame_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<script src="Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body id="top">
	<form id="form1" runat="server">
	<div class="topmain">
		<div class="toparc">
		</div>
		<div class="mlogo">
			<%--<img src="Resources/images/mlogo.gif" alt="信息管理系统" />--%></div>
		<div class="userinfo">
			欢迎您！ 张三， 系统管理员 &nbsp;<a href="#"><img src="Resources/images/exit.gif" alt="安全退出" /></a><br />
			您上次登录的时间：2010年04月30日 17:50:32
		</div>
		<div class="menu">
			<ul>
				<li>
					<a href="WBA/Cms/Articles/FrameLeft.aspx" target="leftFrame" xtarget="WBA/Cms/Articles/Index.aspx">文章管理</a></li>
				<li>
					<a href="WBA/Cms/Channels/FrameLeft.aspx" target="leftFrame" xtarget="WBA/Cms/Channels/Index.aspx">频道管理</a></li>
				<li>
					<a href="Activities/Activity-Left.aspx" target="leftFrame" xtarget="Activities/Activity-List.aspx">活动管理</a></li>
				<li>
					<a href="Comments/Comment-Left.aspx" target="leftFrame" xtarget="Comments/Comment-List.aspx">评论管理</a></li>
			</ul>
		</div>
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
	var currentMenuItem = null;
	function ClickMenuItem(pMenuItem) {
		if (currentMenuItem != null) {
			$(currentMenuItem).removeClass("topselect");
		}
		$(pMenuItem).addClass("topselect");
		currentMenuItem = pMenuItem;
		top.mainFrame.location = $(pMenuItem).find("a").first().attr("xtarget");
	}

	var menuItems = $(".menu li").get();

	for (i = 0; i < menuItems.length; i++) {
		var menuItem = menuItems[i];
		$(menuItem).click(
			function() {
				ClickMenuItem(this);
			}
		);
	}
	
</script>
