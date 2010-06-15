<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog-Update.aspx.cs" Inherits="YouTong.WebSite.Member.Blog_Update" %>

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
	<script src="../_Resources/ckeditor/ckeditor_basic.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/">优童首页</a>&gt;&gt;
				<a href="Index.aspx">管理中心</a>&gt;&gt;
				<a href="Blog-List.aspx" class="choose">博客列表</a>&gt;&gt;
				<a href="#" class="choose">修改博客</a>
			</div>
			<div class="wapper01">
			</div>
			<div class="wapper02">
				<div class="topneirong titleblock">
					修改博文
				</div>
				<div class="mainsc">
					<table width="96%" cellspacing="10" cellpadding="10" border="0">
						<tbody>
							<tr>
								<td class="textright" style="width: 50px">
									标题：
								</td>
								<td>
									<asp:TextBox ID="Blog_Title" runat="server" CssClass="qunziinput"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="textright">
									正文：
								</td>
								<td>
									<asp:TextBox ID="Blog_Body" runat="server" TextMode="MultiLine" Rows="10" Width="90%"></asp:TextBox>
									<script type="text/javascript">
										CKEDITOR.replace('Blog_Body', {
											toolbarStartupExpanded: true,
											height: 500
										});
									</script>
								</td>
							</tr>
							<tr style="height: 5px;">
								<td>
									&nbsp;
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td>
									<asp:Button ID="BtnOK" runat="server" Text="提交" CssClass="button1" OnClick="BtnOK_Click" />
								</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
			<div class="wapper03">
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
