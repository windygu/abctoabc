﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyMedia.aspx.cs" Inherits="YouTong.WebSite.Childs.FamilyMedia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "show";

		function switchTab(type) {
			location = "FamilyMedia.aspx?userid=<%=UserID%>&type=" + type;
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/">首页</a>&gt;&gt;<a href="#">亲子影像</a>
			</div>
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">优童作品列表</a>
					<div class="nianfen">
						<h2>
							<%= this.Category==null ? "": this.Category.Name %></h2>
					</div>
					<div class="tab tab00">
						<ul class="nav">
							<li><a class='<%=(MediaType==1?"choose":"")%>' href="javascript:switchTab(1)"><span>照片</span></a></li>
							<li><a class='<%=(MediaType==2?"choose":"")%>' href="javascript:switchTab(2)"><span>视频</span></a></li>
						</ul>
					</div>
					<div class="clear">
					</div>
				</div>
				<div class="longblock02">
					<asp:Repeater ID="Repeater1" runat="server">
						<HeaderTemplate>
							<div class="longblock02">
								<div class="haveline">
						</HeaderTemplate>
						<ItemTemplate>
							<% i++; %>
							<% if (i != 1 && i % 3 == 1) %>
							<% { %><div class="clear">
							</div>
							</div>
							<div class="longblock02">
								<div class="haveline">
									<% } %>
									<div class="zuopin">
										<div class="listleft">
											<a href="FamilyMedia-Detail.aspx?id=<%# Eval("ID") %>" class="zuopinbg">
												<img width="100" height="75" border="0" src="<%# Eval("ThumbnailUrl") %>" alt=""></a>
										</div>
										<div class="zpxinxi">
											<a href='Media-Detail.aspx?id=<%# Eval("ID") %>' class="zpmclan">
												<%# Eval("Title") %></a>
											<p class="renqisc0">
												<span>人气：<em>131</em></span></p>
											<p class="renqisc0">
												<span>收藏：<em>13</em></span></p>
											<p class="renqisc0">
												<span>评论：<em>3</em></span></p>
										</div>
										<div class="clear">
										</div>
									</div>
						</ItemTemplate>
						<FooterTemplate>
							<div class="clear">
							</div>
							</div>
						</FooterTemplate>
					</asp:Repeater>
					<div class="fenye">
<%--						<a class="choose" title="[1]" href="#">[1]</a><a title="[2]" href="#">[2]</a><a title="[3]" href="#">[3]</a><a title="[4]" href="#">[4]</a><a title="[5]" href="#">[5]</a><a title="[6]" href="#">[6]</a><a title="[7]" href="#">[7]</a><a title="[8]" href="#">[8]</a><a title="[9]" href="#">[9]</a>
--%>					</div>
					<div class="clear">
					</div>
				</div>
				<div class="longblock03">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
