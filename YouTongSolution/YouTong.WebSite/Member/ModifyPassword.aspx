<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="YouTong.WebSite.Member.ModifyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>修改密码|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<ut:LeftNav ID="LeftNav" runat="server" />
				<div class="information_right">
					<div class="xxtitle">
						当前位置：<a href="/">优童首页</a>&gt;&gt;
						<a href="/Grow/Grow.aspx">管理中心</a>&gt;&gt;
						<a href="" class="choose">修改密码</a>&gt;&gt;
					</div>
					<div class="xxmain">
						<table class="eventmain" cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td>
								</td>
								<td class="textright">
									原密码：
								</td>
								<td class="textleft">
									<input type="password" class="input1" name="OldPassword" id="OldPassword" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									新密码：
								</td>
								<td class="textleft">
									<input type="password" class="input1" name="NewPassword" id="NewPassword" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									确认新密码：
								</td>
								<td class="textleft">
									<input type="password" class="input1" name="NewPassword2" id="NewPassword2" />
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
									<asp:Button ID="BtnOK" runat="server" Text="确认提交" CssClass="button1" OnClick="BtnOK_Click" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr height="25px">
								<td rowspan="4">
								</td>
							</tr>
						</table>
					</div>
				</div>
			</div>
			<div class="clear">
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
				OldPassword: { required: true, minlength: 4, maxlength: 15 },
				NewPassword: { required: true, minlength: 6, maxlength: 20 },
				NewPassword2: { required: true, equalTo: "#NewPassword" }
			},
			messages: {
				OldPassword: { required: "必填(*)", minlength: "至少4个字符", maxlength: "最长15个字符" },
				NewPassword: { required: "必填(*)", minlength: "至少6个字符", maxlength: "最长20个字符" },
				NewPassword2: { required: "必填(*)", equalTo: "两次密码输入必须相等" }
			}
		});
	});
</script>
