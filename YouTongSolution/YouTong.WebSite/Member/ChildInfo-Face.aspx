<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChildInfo-Face.aspx.cs" Inherits="YouTong.WebSite.Member.ChildInfo_Face" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>用户注册|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "default";

		$(function() {
			var frm = $("#form1");
			frm.attr("action", "/_Handlers/Head-Upload.ashx?callback=updateCompleted");
		})

		function updateCompleted(data) {
			if (!data.Error) {
				$("#hPic").attr("src", data.SmallUrl);
				$("#HeadPicture").val(data.SmallUrl);
				alert("上传完成");

				var frm = $("#form1");
				frm.removeAttr("target");
				frm.attr("action", "ChildInfo-Face.aspx?action=u");
				frm.removeAttr("enctype")
				frm.submit();
			}
			else {
				alert(data.Error);
			}
		}
	</script>
</head>
<body>
	<iframe id="iUpload" name="iUpload" style="display: none"></iframe>
	<form id="form1" runat="server" enctype="multipart/form-data" target="iUpload" action="/_Handlers/Head-Upload.ashx?callback=updateCompleted">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<div class="information_right">
					<div class="xxtitle">
						当前位置：<a href="/">首页</a>&gt;&gt;
						<a href="/Grow/Grow.aspx">成长档案</a>&gt;&gt;<a href="/Childs/ChildInfo.aspx?userid=<%=UserID %>">优童信息</a>&gt;&gt;上传优童头像
					</div>
					<div class="xxmain">
						<table class="eventmain" cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td>
								</td>
								<td class="textright">
									&nbsp;
								</td>
								<td class="textleft">
									<img src="<%= this.FirstChild.HeadPicture %>" id="hPic" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textleft">
									&nbsp; 选择头像：
								</td>
								<td class="textleft">
									<asp:FileUpload ID="FileUpload1" runat="server" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr height="25px">
								<td rowspan="4">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textleft" colspan="2">
								    <input type="submit" class="button1" value="确认提交" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr height="25px">
								<td rowspan="4">
								</td>
							</tr>
						</table>
					</div>
				</div>
			</div>
			<div class="clear">
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	<asp:HiddenField ID="HeadPicture" runat="server" />
	</form>
</body>
</html>
