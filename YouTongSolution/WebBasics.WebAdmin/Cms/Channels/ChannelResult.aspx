<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelResult.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Channels.ChannelResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body id="right">
	<form id="form1" runat="server">
	<div class="tit">
		<div class="titleft">
		</div>
		当前位置： <a href="#">内容管理</a> &gt; <a href="#">频道管理</a> &gt; 操作结果
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<% if (this.Action == 1) %>
	<% { //插入 %>
	<div>
		<p>
			添加成功</p>
		<p>
			<a href="ChannelUpdate.aspx?id=<%= this.ChannelID %>">修改频道</a></p>
		<p>
			<a href="ChannelInsert.aspx">继续添加</a></p>
		<script type="text/javascript">
			$(function() {
				top.leftFrame.location = "FrameLeft.aspx"
			})
		</script>
	</div>
	<% } %>
	<% if (this.Action == 2) %>
	<% { //修改 %>
	<div>
		<p>
			修改成功</p>
		<p>
			<a href="ChannelUpdate.aspx?id=<%= this.ChannelID %>">修改频道</a></p>
		<p>
			<a href="../Articles/ArticleInsert.aspx?channelid=<%= this.ChannelID %>">添加文章</a></p>
		<script type="text/javascript">
			$(function() {
				top.leftFrame.location = "FrameLeft.aspx"
			})
		</script>
	</div>
	<% } %>
	<div>
	</div>
	<div class="space2">
	</div>
	</form>
</body>
</html>
