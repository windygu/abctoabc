<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Joined-List.aspx.cs" Inherits="YouTong.WebAdmin.Activities.Joined_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<link href="../Resources/css/jquery.css" rel="stylesheet" type="text/css" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../Resources/js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../Resources/ckeditor/ckeditor_basic.js" type="text/javascript"></script>
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
		&gt; 参与列表
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<div class="seach">
		<div class="seachleft">
		</div>
		<%= this.ActivityID %>
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td class="titab" style="width: 20px">
				活动编号
			</td>
			<td class="titab" style="width: 20px">
				参加情况
			</td>
			<td class="titab">
				电子邮箱
			</td>
			<td class="titab" style="width: 100px">
				孩子姓名
			</td>
			<td class="titab" style="width: 100px">
				出生年月
			</td>
			<td class="titab" style="width: 100px">
				家长姓名
			</td>
			<td class="titab" style="width: 100px">
				电话
			</td>
			<td class="titab" style="width: 100px">
				参与时间
			</td>
		</tr>
		<asp:Repeater ID="Repeater1" runat="server">
			<ItemTemplate>
				<tr>
					<td>
						<%# Eval("Number") %>
					</td>
					<td>
						<%# (Byte)Eval("AcceptStatus") == 1 ? "是" : "" %>
					</td>
					<td>
						<%# DataCache.GetUser((Guid)Eval("UserID"))!=null ? DataCache.GetUser((Guid)Eval("UserID")).Email : "" %>
					</td>
					<td>
						<%# DataCache.GetChild((Guid)Eval("UserID")) != null ? DataCache.GetChild((Guid)Eval("UserID")).Name : ""%>
					</td>
					<td>
						<%# DataCache.GetChild((Guid)Eval("UserID")) != null ? DataCache.GetChild((Guid)Eval("UserID")).Birthday.ToString("yyyy-MM-dd") : ""%>
					</td>
					<td>
						<%# DataCache.GetUser((Guid)Eval("UserID")) !=null ? DataCache.GetUser((Guid)Eval("UserID")).Name : "" %>
					</td>
					<td>
						<%# DataCache.GetUser((Guid)Eval("UserID")) !=null ? DataCache.GetUser((Guid)Eval("UserID")).Mobile : "" %>
					</td>
					<td>
						<%# Eval("AddTime") %>
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
