<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="WebBasics.WebAdmin.Cms.Articles.ArticleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>信息管理系统</title>
	<link href="../Resources/css/admin.css" type="text/css" rel="stylesheet" />
	<link href="../Resources/css/jquery.css" rel="stylesheet" type="text/css" />
	<script src="../Resources/js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../Resources/js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../Resources/ckeditor/ckeditor_basic.js" type="text/javascript"></script>
	<script type="text/javascript">
		$(function() {
			$("#BtnBatchDelete").click(function() {
				if (!confirm("确认删除？删除后将不可恢复！")) {
					return false;
				}
			})
		})

		function del(id) {
			$("#HfArticleID").val(id);
			if (confirm("确认删除？删除后将不可恢复！")) {
				$("#BtnSingleDelete").click();
			}
		}
	</script>
</head>
<body id="right">
	<form id="form1" runat="server">
	<div class="tit">
		<div class="titleft">
		</div>
		当前位置：
		<a href="#">内容管理</a>
		&gt;
		<a href="#">文章管理</a>
		&gt; 文章列表 | &nbsp;&nbsp;
		<a href="ArticleInsert.aspx?ChannelID=<%= this.ChannelID %>">添加文章</a>
		<div class="titright">
		</div>
	</div>
	<div class="space">
	</div>
	<div class="seach">
		<div class="seachleft">
		</div>
		审核状态：
		<asp:DropDownList ID="DdlAuditStatus" runat="server">
			<asp:ListItem Value="-1">未筛选</asp:ListItem>
			<asp:ListItem Value="1" Selected="True">通过</asp:ListItem>
			<asp:ListItem Value="2">未通过</asp:ListItem>
		</asp:DropDownList>
		&nbsp;&nbsp;<asp:Button ID="BtnQuery" runat="server" Text="查 询" CssClass="btn2word" OnClick="BtnQuery_Click" />
	</div>
	<div class="space">
	</div>
	<table cellpadding="0" cellspacing="0" width="100%" class="mytab">
		<tr>
			<td class="titab" style="width: 20px">
				<input name="" type="checkbox" value="" id="checkAll" />
			</td>
			<td class="titab">
				标题
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
						<input name="ID" type="checkbox" value="<%# Eval("ID") %>" />
					</td>
					<td>
						<%# Eval("Title") %>
					</td>
					<td>
						<%# Eval("AddTime", "{0:yyyy:MM:dd HH:mm:ss}") %>
					</td>
					<td>
						<a href="ArticleUpdate.aspx?id=<%# Eval("ID") %>">修改</a>
						<a href="#" onclick="del('<%# Eval("ID") %>')">删除</a>
					</td>
				</tr>
			</ItemTemplate>
		</asp:Repeater>
	</table>
	<div class="space2">
	</div>
	<div class="seach">
		<div class="seachleft">
		</div>
		<asp:Button ID="BtnBatchDelete" runat="server" CssClass="btn2word" OnClick="BtnBatchDelete_Click" Text="删除" />
		&nbsp;<asp:Button ID="BtnBatchAuditPass" runat="server" Text="审核通过" CssClass="btn4word" onclick="BtnBatchAuditPass_Click" />
		&nbsp;<asp:Button ID="BtnBatchAuditRefuse" runat="server" Text="拒绝通过" CssClass="btn4word" onclick="BtnBatchAuditRefuse_Click" />
	</div>
	<div class="page">
		<asp:Literal ID="Hp" runat="server"></asp:Literal>
	</div>
	<div style="display: none">
		<asp:HiddenField ID="HfArticleID" runat="server" />
		<asp:Button ID="BtnSingleDelete" runat="server" OnClick="BtnSingleDelete_Click" Text="单个删除" />
	</div>
	</form>
</body>
</html>
