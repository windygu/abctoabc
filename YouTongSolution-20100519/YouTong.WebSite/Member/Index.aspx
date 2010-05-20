<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YouTong.WebSite.Member.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>用户注册|优童|越秀越优秀|中国儿童优秀展示平台</title>
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
				<ut:LeftNav ID="LeftNav" runat="server" />
				<div class="information_right">
					<div class="xxtitle">
						当前位置：<a href="/">优童首页</a>&gt;&gt;
						<a href="Index.aspx">管理中心</a>
					</div>
					<div class="gerenxin">
						<ul>
							<li>
								<a href="Index.aspx" class="choose"><span class="choose">基本信息</span></a></li>
							<li>
								<a href="Info-Face.aspx"><span class="choose">上传头像</span></a></li>
						</ul>
					</div>
					<div class="xxmain">
						<table class="eventmain" cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td>
								</td>
								<td class="textright">
									姓名：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Name" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									昵称：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_NickName" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									手机：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Mobile" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									性别：
								</td>
								<td class="textleft">
									<asp:DropDownList ID="User_Gender" runat="server">
										<asp:ListItem Value="1">男</asp:ListItem>
										<asp:ListItem Value="2">女</asp:ListItem>
									</asp:DropDownList>
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
