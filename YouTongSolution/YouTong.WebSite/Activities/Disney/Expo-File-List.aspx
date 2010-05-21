﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expo-File-List.aspx.cs" Inherits="YouTong.WebSite.Activities.Disney.Expo_File_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="/css/content.css" type="text/css" rel="stylesheet" />
	<link href="/css/default.css" type="text/css" rel="stylesheet" />
	<script src="../../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "show";

		function switchTab(type) {
			location = "expo-file-list.aspx?&type=" + type;
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
		<div style="text-align:center; margin-bottom:10px; margin-top:10px;"><img  src="images/北京活动banner.jpg" /></div>
		
			<div class="erjinav" style="text-align: center;">
			    <input type="button" value="上传绘画" onclick="window.open('Expo-File-Upload.aspx?type=huihua');"/>
			    <input type="button" value="上传摄影"  onclick="window.open('Expo-File-Upload.aspx?type=sheying');"/>
			    <input type="button" value="上传摄像"  onclick="window.open('Expo-File-Upload.aspx?type=shexiang');"/>
			    <%--<a href="Expo-File-Upload.aspx?type=huihua">上传绘画</a>
			    <a href="Expo-File-Upload.aspx?type=sheying">上传摄影</a>
			    <a href="Expo-File-Upload.aspx?type=shexiang">上传摄像</a>--%>
			</div>
			<div class="erjinav">			    
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">活动影像列表</a>
					<div class="nianfen">
						<h2>
						</h2>
					</div>
					<div class="tab tab00">
						<ul class="nav">
							<li><a class='<%=(TypeSpell=="huihua"?"choose":"")%>' href="javascript:switchTab('huihua');"><span>绘画</span></a></li>
							<li><a class='<%=(TypeSpell=="sheying"?"choose":"")%>' href="javascript:switchTab('sheying');"><span>摄影</span></a></li>
							<li><a class='<%=(TypeSpell=="shexiang"?"choose":"")%>' href="javascript:switchTab('shexiang');"><span>摄像</span></a></li>
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
											<a href="/Childs/Works-Detail.aspx?id=<%# Eval("ID") %>" class="zuopinbg">
												<img width="100" height="75" border="0" src="<%# Eval("ThumbnailUrl") %>" alt=""></a>
										</div>
										<div class="zpxinxi">
											<a href='/Childs/Works-Detail.aspx?id=<%# Eval("ID") %>' class="zpmclan">
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
						<asp:Literal ID="Hp" runat="server"></asp:Literal>
					</div>
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
