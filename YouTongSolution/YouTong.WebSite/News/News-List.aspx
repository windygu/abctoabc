<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News-List.aspx.cs" Inherits="YouTong.WebSite.News.News_List" %>

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
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/">首页</a>&gt;&gt;<a href="#">新闻</a>
			</div>
			<div class="main">
				<div class="leftblock">
					<div class="zuopinzhanshi">
						<div class="block1">
							<a href="#" class="title"><%=this.Channel.Name %></a>
							<div class="clear">
							</div>
						</div>
						<div class="block2 datuzhanshi">
							<div class="fenye">
								<%--								
								<a class="choose" title="[1]" href="#">[1]</a><a title="[2]" href="#">[2]</a><a title="[3]" href="#">[3]</a><a title="[4]" href="#">[4]</a><a title="[5]" href="#">[5]</a><a title="[6]" href="#">[6]</a><a title="[7]" href="#">[7]</a><a title="[8]" href="#">[8]</a><a title="[9]" href="#">[9]</a>
								--%>
							</div>
							<div class="clear">
							</div>
							<div class="zixunxinxi">
								<asp:Repeater ID="Repeater1" runat="server">
									<HeaderTemplate>
										<ul>
									</HeaderTemplate>
									<ItemTemplate>
										<li>
											<a href="#" class="choose"><span>
												<%# Eval("Title") %></span><em>
													<%# Eval("AddTime") %></em></a><div class="clear">
													</div>
									</ItemTemplate>
									<FooterTemplate>
										</ul>
									</FooterTemplate>
								</asp:Repeater>
							</div>
							<div class="fenye">
								<a class="choose" title="[1]" href="#">[1]</a><a title="[2]" href="#">[2]</a><a title="[3]" href="#">[3]</a><a title="[4]" href="#">[4]</a><a title="[5]" href="#">[5]</a><a title="[6]" href="#">[6]</a><a title="[7]" href="#">[7]</a><a title="[8]" href="#">[8]</a><a title="[9]" href="#">[9]</a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="block3">
						</div>
					</div>
				</div>
				<div class="rightblock">
					<div class="redianxinxi">
						<div class="duanblock1">
							<div class="kong">
								<a class="title" href="#">热点信息</a>
								<a href="#" class="more">&gt;&gt;更多</a>
							</div>
						</div>
						<div class="duanblock2">
							<ul class="zuixin">
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
							</ul>
						</div>
						<div class="duanblock3">
						</div>
					</div>
				</div>
				<div class="clear">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
