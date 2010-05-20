<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleResult.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Articles.ArticleResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
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
			<a href="ArticleUpdate.aspx?id=<%= this.ArticleID %>">修改文章</a></p>
		<p>
			<a href="ArticleInsert.aspx?ChannelID=<%= this.Article.ChannelID %>">继续添加</a></p>
	</div>
	<% } %>
	<% if (this.Action == 2) %>
	<% { //修改 %>
	<div>
		<p>
			修改成功</p>
		<p>
			<a href="ArticleUpdate.aspx?id=<%= this.ArticleID %>">修改文章</a></p>
		<p>
			<a href="../Articles/ArticleInsert.aspx?ChannelID=<%= this.Article.ChannelID %>">添加文章</a></p>
	</div>
	<% } %>
	<div>
	</div>
	<div class="space2">
	</div>
	</form>
</body>
</html>
