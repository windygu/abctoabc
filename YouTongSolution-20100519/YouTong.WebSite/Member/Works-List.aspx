<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Works-List.aspx.cs" Inherits="YouTong.WebSite.Member.Works_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优童首页|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
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
			<div class="register">
				<ut:LeftNav ID="LeftNav" runat="server" />
				<div class="information_right">
					<div class="xxtitle">
						当前位置：<a href="/">优童首页</a>&gt;&gt;
						<a href="Index.aspx">管理中心</a>&gt;&gt;
						<a href="Works-List.aspx" class="choose">作品列表</a>
					</div>
					<div class="gerenxin">
						<ul>
							<li>
								<a href="#" class="choose"><span class="choose">优童作品</span></a></li>
							<li>
								<a href="Works-Upload.aspx" class="choose"><span class="choose">上传作品</span></a></li>
						</ul>
					</div>
					<table cellpadding="0" cellspacing="0" width="100%" border="0" class="zhanneixin">
						<thead>
							<td align="center" width="8%">
								选择
							</td>
							<td width="22%">
								操作
							</td>
							<td width="50%">
								标题
							</td>
							<td width="20%">
								时间
							</td>
						</thead>
						<tr style="height: 5px;">
							<td colspan="4" style="padding: 1px 0;">
							</td>
						</tr>
						<asp:Repeater ID="Repeater1" runat="server">
							<ItemTemplate>
								<tr class="color">
									<td align="center">
										<input name="" type="checkbox" value="" />
									</td>
									<td>
										<a href='Works-Update.aspx?id=<%# Eval("ID") %>' target="_blank">修改</a>
									</td>
									<td>
										<%# Eval("Title") %>
									</td>
									<td>
										<%# Eval("AddTime") %>
									</td>
								</tr>
							</ItemTemplate>
						</asp:Repeater>
					</table>
					<div class="gongnengbtn">
						<input type="submit" class="button01" value="全部选择">
						<input type="submit" class="button01" value="删除信息">
					</div>
				</div>
				<div class="clear">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
