<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterSuccess.aspx.cs" Inherits="YouTong.WebSite.Member.RegisterSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>注册|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com,优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com,优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<h2>
					<span>
						<a href="#">优童首页</a><a>&gt;&gt;</a><a>注册成功</a></span></h2>
				<div class="event">
					<div class="wancheng">
						<img src="../images/xiao.gif" width="52" height="52" border="0" />
						<%--<h5>
							您已经完成了孩子成长档案的基本建立。下面，您可以进入<a href="MyChild.aspx">孩子成长档案</a>，<br />
							完成孩子作品及成长经历的部分。</h5>--%>
						<div class="clear">
						</div>
						<div class="guanxianniu">
							<input type="button" class="button10" value="点击体验" onclick="javascript:location='MyChild.aspx'">
						</div>
					</div>
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
