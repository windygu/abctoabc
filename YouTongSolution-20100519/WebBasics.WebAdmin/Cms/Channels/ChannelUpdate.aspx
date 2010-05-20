<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelUpdate.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Channels.ChannelUpdate" %>

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
		当前位置： <a href="#">内容管理</a> &gt; <a href="#">频道管理</a> &gt; 修改频道
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td style="width: 150px">
				相关操作：
			</td>
			<td>
				<a href="../Articles/ArticleInsert.aspx?ChannelID=<%= this.ChannelID %>">添加文章</a> &nbsp;&nbsp; <a href="ChannelInsert.aspx?ParentID=<%= this.ChannelID %>">添加子频道</a>
			</td>
		</tr>
		<tr>
			<td>
				频道编号：
			</td>
			<td>
				<asp:Label ID="LblID" runat="server" Text=""></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				父级频道信息：
			</td>
			<td>
				<asp:Label ID="LblParentChannel" runat="server" Text="顶级频道"></asp:Label>
				<a href="#" id="selchl" style="margin: 0 0 0 10px">重选</a>
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
				首次添加时间：
			</td>
			<td>
				<asp:Label ID="LblAddTime" runat="server" Text="Label"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				上次修改时间：
			</td>
			<td>
				<asp:Label ID="LblUpdateTime" runat="server" Text="Label"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td>
				<asp:Button ID="BtnOK" runat="server" Text="修改" class="btn2word" OnClick="BtnOK_Click" />
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
