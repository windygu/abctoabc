<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebBasics.WebAdmin.SignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>后台登陆|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="/css/content.css" type="text/css" rel="stylesheet" />
	<link href="/css/register.css" type="text/css" rel="stylesheet" />
	<script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="/js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="./js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<div class="header">
			<div class="head">
				<div class="logo">
					<a href="http://www.no1child.com" title="优童网 越秀越优秀，中国儿童优秀展示平台">
						<img src="/images/logo.gif" border="0" alt="优童网 越秀越优秀，中国儿童优秀展示平台" /></a>
				</div>
				<div class="text">
				</div>
				<div class="clear">
				</div>
			</div>
			<div class="menu">
				<ul class="navgation">
					<li>
						<a href="/" title="首页" class="choose"><span>首页</span></span></a></li>
					<li>
						<a href="/Member/MyChild.aspx" title="我的优童"><span>我的优童</span></a></li>
					<li>
						<a href="/childs/" title="优童秀"><span>优童秀</span></a></li>
					<li id="Li1">
						<a href="../Jianshezhong.aspx" title="优童圈"><span>优童圈</span></a></li>
					<li>
						<a href="../Jianshezhong.aspx" title="优童经"><span>优童经</span></a></li>
					<li>
						<a href="../Jianshezhong.aspx" title="优童in品"><span>优童in品</span></a></li>
					<li>
						<a href="../Jianshezhong.aspx" title="优童小铺"><span>优童小铺</span></a></li>
				</ul>
				<div class="seach">
					<input type="text" class="input01" name="search_text" id="discover_text" value="从你感兴趣的东西开始" title="从你感兴趣的东西开始">
					<select class="select01">
						<option selected="" value="">请选择</option>
						<option selected="" value="">作品名称</option>
						<option selected="" value="">作者</option>
						<option selected="" value="">学校</option>
					</select>
				</div>
			</div>
		</div>
		<div class="content">
			<div class="register">
				<h2>
					<span>
						<a href="#">优童首页</a><a>》</a><a class="choose">后台登录</a></span></h2>
				<div class="event hydl">
					<table class="eventmain duandl" cellspacing="0" cellpadding="0" border="0" width="100%">
						<tr>
							<td>
							</td>
							<td class="textright">
								登录帐户：
							</td>
							<td class="textleft">
								<p>
									<asp:TextBox ID="User_UserName" runat="server" CssClass="input1"></asp:TextBox></p>
							</td>
							<td class="textleft">
							</td>
						</tr>
						<tr>
							<td>
							</td>
							<td class="textright">
								登录密码：
							</td>
							<td class="textleft">
								<asp:TextBox ID="User_Password" runat="server" TextMode="Password" CssClass="input1"></asp:TextBox>
							</td>
							<td class="textleft">
							</td>
						</tr>
						<tr>
							<td>
							</td>
							<td class="textright">
							</td>
							<td class="textleft">
								&nbsp;
							</td>
							<td class="textleft">
							</td>
						</tr>
						<tr height="25px">
							<td rowspan="4">
							</td>
						</tr>
						<tr>
							<td>
							</td>
							<td class="textleft" colspan="2">
								<asp:Button ID="BtnOK" runat="server" Text="立即登录" CssClass="button1" OnClick="BtnOK_Click" />
							</td>
							<td class="textleft">
							</td>
						</tr>
						<tr height="25px">
							<td rowspan="4">
							</td>
						</tr>
					</table>
					<div class="clear">
					</div>
				</div>
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
	</div>
	</form>
</body>
</html>
