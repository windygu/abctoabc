<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YouTong.WebSite.Member.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>会员登录|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "default";
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<h2>
					<span>
						<a href="#">优童首页</a><a>》</a><a class="choose">会员登录</a></span></h2>
				<div class="event hydl">
					<% if (this.IsAnonymous) %>
					<% { %>
					<table class="eventmain duandl" cellspacing="0" cellpadding="0" border="0" width="100%">
						<tr>
							<td>
							</td>
							<td class="textright">
								登录帐户：
							</td>
							<td class="textleft">
								<p>
									<input type="text" class="input1" name="User_UserName" id="User_UserName" value=""></p>
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
								<input type="password" class="input1" name="User_Password" id="User_Password" value="" />
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
								<input name="User_Remember" id="User_Remember" type="checkbox" value="true" />记住我的帐号下次访问直接登录
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
					<% } %>
					<% else %>
					<% { %><table class="eventmain duandl" cellspacing="0" cellpadding="0" border="0" width="100%">
						<tr>
							<td>
								你处于登录状态，请先<a href="SignOut.aspx">登出</a>
							</td>
						</tr>
					</table>
					<% } %>
					<div class="duandltext">
						<p>
							您还不是优童网会员吗？快点免费<a href="Register.aspx">注册</a>吧！</p>
						<ol>
							<li>
								<a href="#">上传宝宝照片</a></li>
							<li>
								<a href="#">记录宝宝成长</a></li>
							<li>
								<a href="#">分享育儿经验</a></li>
						</ol>
					</div>
					<div class="clear">
					</div>
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
	$(function() {
		$("#form1").validate({
			rules: {
				User_UserName: { required: true },
				User_Password: { required: true }
			},
			messages: {
				User_UserName: { required: "必填(*)" },
				User_Password: { required: "必填(*)" }
			}
		});
	});
</script>
