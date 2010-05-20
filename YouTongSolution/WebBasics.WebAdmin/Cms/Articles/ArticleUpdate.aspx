<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleUpdate.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Articles.ArticleUpdate" %>

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
		当前位置： <a href="#">内容管理</a> &gt; <a href="#">文章管理</a> &gt; 修改文章
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td style="width: 80px">
				所属频道：
			</td>
			<td>
				<asp:Label ID="LblChannel" runat="server" Text=""></asp:Label>
				<asp:HiddenField ID="Article_ChannelID" runat="server" />
			</td>
		</tr>
		<tr>
			<td>
				文章标题：
			</td>
			<td>
				<asp:TextBox ID="Article_Title" runat="server" class="myinput" Columns="50"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				文章内容：
			</td>
			<td>
				<asp:TextBox ID="Article_Body" runat="server" Columns="100" Rows="5" TextMode="MultiLine"></asp:TextBox>
				<script type="text/javascript">
					CKEDITOR.replace('Article_Body',
						{
							toolbarStartupExpanded: false,
							height: 300
						}
					);
				</script>
			</td>
		</tr>
		<tr>
			<td>
				文章概述：
			</td>
			<td>
				<asp:TextBox ID="Article_Summary" runat="server" class="myarea" Columns="100" Rows="5" TextMode="MultiLine"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				&nbsp;
			</td>
			<td>
				&nbsp;
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
				&nbsp;
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
