<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comment-List.aspx.cs" Inherits="YouTong.WebAdmin.Comments.Comment_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
		<a href="#">活动管理</a>
		&gt; 评论列表
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<div class="seach">
		<div class="seachleft">
		</div>
		关键字：<input name="" type="text" class="myinput" />&nbsp;&nbsp;&nbsp;<input name="" type="button" class="btn2word" value="查 询" />
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td class="titab" style="width: 20px">
				<input name="" type="checkbox" value="" />
			</td>
			<td class="titab">
				名称
			</td>
			<td class="titab" style="width: 150px">
				Score
			</td>
			<td class="titab" style="width: 150px">
				Reviewer
			</td>
			<td class="titab" style="width: 150px">
				添加时间
			</td>
			<td class="titab" style="width: 100px">
				操作
			</td>
		</tr>
		<asp:Repeater ID="Repeater1" runat="server">
			<ItemTemplate>
				<tr>
					<td>
						<input name="" type="checkbox" value="" />
					</td>
					<td>
						<%# Eval("Title") %>
					</td>
					<td>
						<%# Eval("Score")%>
					</td>
					<td>
						<%# Eval("Reviewer")%>
					</td>
					<td>
						<%# Eval("AddTime", "{0:yyyy:MM:dd HH:mm:ss}") %>
					</td>
					<td>
						<a href="Joined-List.aspx?activityid=<%# Eval("ID") %>">参与情况</a>
						<a href="Joined2-List.aspx?activityid=<%# Eval("ID") %>">参与情况2</a>
						<a href="Activity-Update.aspx?id=<%# Eval("ID") %>">修改</a>
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
