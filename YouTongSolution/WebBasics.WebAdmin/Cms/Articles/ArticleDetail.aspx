<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Articles.ArticleDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<link href="../Resources/css/jquery.css" rel="stylesheet" type="text/css" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../Resources/js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../Resources/ckeditor/ckeditor_basic.js" type="text/javascript"></script>
</head>
<body id="right">
	<form id="form1" runat="server">
	<div class="tit">
		<div class="titleft">
		</div>
		当前位置： <a href="#">内容管理</a> &gt; <a href="#">文章管理</a> &gt; 查看图片/视频
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<div class="bigimg">
		<% if (Detail.FileType == 1) %>
		<% { %>
		<a href="<%= Detail.FileUrl %>" title="点击查看作品大图" target="_blank">
			<img src="<%= Detail.FileUrl %>" width="480" height="360" border="0" alt="点击查看作品大图" /></a>
		<% } %>
		<% else %>
		<% { %>
		<object width="480" height="360">
			<param name="movie" value="<%= Detail.FileUrl %>" />
			<param name="allowFullScreen" value="true" />
			<param name="allowscriptaccess" value="always" />
			<param name="wmode" value="opaque"></param>
			<embed src="<%= Detail.FileUrl %>" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" wmode="opaque" width="480" height="360"></embed>
		</object>
		<% } %>
	</div>
	<div class="space2">
	</div>
	</form>
</body>
</html>
