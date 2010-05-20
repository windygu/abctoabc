<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activity-Insert.aspx.cs" Inherits="YouTong.WebAdmin.Activities.Activity_Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
		当前位置： <a href="#">后台管理</a> &gt; <a href="#">活动管理</a> &gt; 添加活动
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td style="width: 80px">
				&nbsp;
			</td>
			<td>
				&nbsp;
			</td>
		</tr>
		<tr>
			<td>
				名称：
			</td>
			<td>
				<asp:TextBox ID="Activity_Name" runat="server" class="myinput" Columns="50"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				前缀：
			</td>
			<td>
				<asp:TextBox ID="Activity_Prefix" runat="server" class="myinput" Columns="50"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td>
				<asp:Button ID="BtnOK" runat="server" Text="确定" class="btn2word" OnClick="BtnOK_Click" />
			</td>
		</tr>
	</table>
	<div class="space2">
	</div>
	</form>
</body>
</html>
