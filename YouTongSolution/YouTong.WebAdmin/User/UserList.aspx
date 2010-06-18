<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="YouTong.WebAdmin.User.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body id="right">
	<form id="form1" runat="server">
	<div class="tit">
		<div class="titleft">
		</div>
		当前位置：
		<a href="#">后台管理</a>
		&gt;
		<a href="#">用户管理</a>
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<div class="seach">
		<div class="seachleft">
		</div>
        <asp:RadioButton ID="RadioButton1" runat="server" Checked="true" Text="未删除用户" GroupName="Users"/>
        <asp:RadioButton ID="RadioButton2" runat="server" Text="删除用户" GroupName="Users" />
		<input type="submit" class="btn2word" value="查 询" />
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td class="titab">
				用户名
			</td>			
			<td class="titab">
				Email
			</td>
			<td class="titab">手机号码</td>
			<td class="titab">
				姓名
			</td>
			<td class="titab">
				昵称
			</td>
			<td class="titab">
				性别
			</td>
			<td class="titab">
				生日
			</td>
		</tr>
		<asp:Repeater ID="Repeater1" runat="server">
			<ItemTemplate>
				<tr>
					<td>
						<%# Eval("UserName")%>
					</td>
					<td>
						<%# Eval("Email")%>
					</td>
					<td>
						<%# Eval("Mobile")%>
					</td>
					<td>
						<%# Eval("Name")%>
					</td>
					<td>
					    <%# Eval("NickName")%>
					</td>
					<td>
					    <%# Eval("Gender")%>
					</td>
					<td>
					    <%# Eval("Birthday", "{0:yyyy:MM:dd HH:mm:ss}")%>
					</td>
				</tr>
			</ItemTemplate>
		</asp:Repeater>
	</table>
	<div class="space2">
	</div>
	<div class="page">
		<asp:Literal ID="Hp" runat="server"></asp:Literal>
	</div>
	</form>
</body>
</html>
