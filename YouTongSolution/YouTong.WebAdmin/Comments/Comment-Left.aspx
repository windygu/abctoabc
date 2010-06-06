<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment-Left.aspx.cs" Inherits="YouTong.WebAdmin.Comments.Comment_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
</head>
<body id="left">
	<form id="form1" runat="server">
	<div class="leftit">
		评论管理</div>
	<div class="space">
	</div>
	<ul>
		<li>
			<a href="Comment-List.aspx?entity=亲子影像" target="mainFrame">亲子影像</a></li>
		<li>
			<a href="Comment-List.aspx?entity=优童作品" target="mainFrame">优童作品</a></li>
	</ul>
	<div class="space2">
	</div>
	</form>
</body>
</html>
