<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelInsert.aspx.cs"
	Inherits="WebBasics.WebAdmin.Cms.Channels.ChannelInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<link href="../Resources/css/jquery.css" rel="stylesheet" type="text/css" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../Resources/js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
</head>
<body id="right">
	<form id="form1" runat="server">
	<div class="tit">
		<div class="titleft">
		</div>
		当前位置： <a href="#">内容管理</a> &gt; <a href="#">频道管理</a> &gt; 添加频道
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td style="width: 150px">
				父级频道信息：
			</td>
			<td>
				<asp:Label ID="LblParentChannel" runat="server" Text="顶级频道"></asp:Label>
				<asp:HiddenField ID="Channel_ParentID" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				频道标识名称：
			</td>
			<td>
				<asp:TextBox ID="Channel_Name" runat="server" class="myinput" Columns="50"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				频道显示名称：
			</td>
			<td>
				<asp:TextBox ID="Channel_DisplayName" runat="server" class="myinput" Columns="50"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td>
				<asp:Button ID="BtnOK" runat="server" Text="添加" class="btn2word" OnClick="BtnOK_Click" />
			</td>
		</tr>
	</table>
	<div class="space2">
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
	$(function() {
		$("#form1").validate({
			rules: {
				Channel_Name: { required: true },
				Channel_DisplayName: { required: true }
			},
			messages: {
				Channel_Name: { required: "必填(*)" },
				Channel_DisplayName: { required: "必填(*)" }
			}
		});
	});
</script>
