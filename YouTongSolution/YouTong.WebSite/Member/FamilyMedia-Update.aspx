﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyMedia-Update.aspx.cs" Inherits="YouTong.WebSite.Member.FamilyMedia_Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优童首页|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/works.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
	</script>
</head>
<body>
	<form id="form1" runat="server" enctype="multipart/form-data" target="iframeUpload">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/">优童首页</a>&gt;&gt;
				<a href="Index.aspx">管理中心</a>&gt;&gt;
				<a href="FamilyMedia-List.aspx" class="choose">影像列表</a>&gt;&gt;
				<a href="#" class="choose">修改影像</a>
			</div>
			<div class="jindu">
				<div class="jindublock01">
					<a class="title" href="#">修改亲子影像</a>
				</div>
				<div class="jindublock02">
					<table width="100%" cellspacing="0" cellpadding="0" border="0" class="sctable">
						<tbody>
							<tr>
								<td class="textright">
									分类：
								</td>
								<td>
									<asp:DropDownList ID="Media_ChannelID" runat="server">
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="textright">
									标题（*）：
								</td>
								<td>
									<asp:TextBox ID="Media_Title" runat="server" CssClass="qunziinput"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="textright">
									创作年份(*)：
								</td>
								<td>
									<asp:TextBox ID="Media_OccurTime" runat="server" CssClass="qunziinput"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="textright">
									标签（*）：
								</td>
								<td>
									<asp:TextBox ID="Media_Tags" runat="server" CssClass="qunziinput"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td valign="top" class="textright">
									介绍：
								</td>
								<td>
									<asp:TextBox ID="Media_Summary" runat="server" CssClass="quanzitextarea" TextMode="MultiLine" Rows="5" Columns="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td>
									<asp:Button ID="BtnOK" runat="server" Text="确定修改" CssClass="button1" OnClick="BtnOK_Click" />
								</td>
							</tr>
						</tbody>
					</table>
				</div>
				<div class="jindublock03">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	<div style="display: none">
		<iframe id="iframeUpload" name="iframeUpload"></iframe>
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
	$(function() {
		$("#form1").validate({
			rules: {
				Media_Title: { required: true },
				Media_Tags: { required: true },
				Media_OccurTime: { required: true }
			},
			messages: {
				Media_Title: { required: "必填(*)" },
				Media_Tags: { required: "必填(*)" },
				Media_OccurTime: { required: "格式不正确" }
			}
		});
	});
</script>
