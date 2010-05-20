<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expo-File-Upload.aspx.cs" Inherits="YouTong.WebSite.Activities.Disney.Expo_File_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优童首页|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="/css/content.css" type="text/css" rel="stylesheet" />
	<link href="/css/works.css" type="text/css" rel="stylesheet" />
	<script src="../../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="/js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="/js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="/js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	<script src="/js/Tudou/Tudou.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";

		$(function() {
			$("#BtnOK").click(function() {
				if ($("#File_FileType").val() == "1") {
					uploadImage();
				}
				else if ($("#File_FileType") == "2") {
					uploadVideo();
				}
				else {
					alert("错误");
				}

				return false;
			});
		})

		function imageUploadSuccess(id, fileUrl, thumbnailUrl) {
			$("#FormPanel").hide();
			$("#FinshPanel").show();

			$("#FinshPanel img").attr("src", thumbnailUrl);
			$("#toViewWorks").attr("href", "/childs/works-detail.aspx?id=" + id);

		}
		function imageUploadFailure(msg) {
			alert(msg);
		}

		function videoUploadSuccess(id, fileUrl, thumbnailUrl) {
			$("#FormPanel").hide();
			$("#FinshPanel").show();

			$("#FinshPanel img").attr("src", thumbnailUrl);
			$("#toViewWorks").attr("href", "/childs/works-detail.aspx?id=" + id);

		}

		function uploadImage() {
			var action = "/_Handlers/CmsAnyFile-Upload.ashx?successCallback=imageUploadSuccess&failureCallback=imageUploadFailure";
			var frm = $("#form1");
			frm.attr("action", action);
			frm.attr("target", "iframeUpload");
			frm.submit();
		}

		function uploadVideo() {
			var frm = $("#form1");
			Tudou_VideoCreate({
				callUploading: tudou_uploading,
				callProcessing: tudou_processing,
				callFail: tudou_fail,
				callTimeout: tudou_timeout,
				callFinish: tudou_finish,
				iframeName: "iframeUpload",
				form: jQuery('#form1')
			});
		}

		//上传中
		function tudou_uploading(msg) {
			jQuery("#qingkuang").html("正在上传...请勿关闭或者刷新浏览器" + msg.progress + "%;  文件大小：约" + parseInt(msg.filesize / 1024 / 1024) + "MB");
			$("#File_FileSize").val(msg.filesize / 1024);
		}

		//上传完毕正在转码
		function tudou_processing(msg) {
			jQuery("#qingkuang").html("上传完毕，正在转码....请勿关闭或者刷新浏览器" + msg.progress + "%;  文件大小：约" + parseInt(msg.filesize / 1024 / 1024) + "MB");
			$("#File_FileSize").val(msg.filesize / 1024);
		}

		//上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误
		function tudou_fail(msg) {
			jQuery("#qingkuang").html("上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误。");
		}

		//用户中途取消上传或用户的网络中途中断
		function tudou_timeout(msg) {
			jQuery("#qingkuang").html("用户中途取消上传或用户的网络中途中断。");

		}

		//上传完成，转码成功
		function tudou_finish(item) {
			jQuery("#qingkuang").html("上传完成");

			$("#File_FileUrl").val(item.outerPlayerUrl);
			$("#File_ThumbnailUrl").val(item.picUrl);
			$("#File_FileName").val(item.id);

			var action = "Expo-File-Upload.aspx?action=video";
			var frm = $("#form1");
			frm.attr("action", action);
			frm.removeAttr("target");
			$("#File_File").remove();

			frm.submit();
		}
	</script>
</head>
<body>
	<form id="form1" runat="server" enctype="multipart/form-data">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div style="text-align: center; margin-bottom: 10px; margin-top: 10px;">
				<img src="images/北京活动banner.jpg" /></div>
			<div class="jindu">
				<div class="jindublock01">
					<a class="title" href="#">上传作品</a>
				</div>
				<div class="jindublock02" id="FormPanel">
					<div id="qingkuang">
					</div>
					<table width="100%" cellspacing="0" cellpadding="0" border="0" class="sctable">
						<tbody>
							<tr>
								<td class="textright" width="25%">
									选择上传文件：
								</td>
								<td width="75%">
									<input type="file" class="qunziinput" name="File_File" id="File_File" /><br />
									<em style="color: #b7b7b7;">上传文件图片不可超过5M，视频不可超过500M，文件至少大于50KB。</em>
								</td>
							</tr>
							<tr>
								<td class="textright">
									标题（*）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="File_Title" id="File_Title" />
								</td>
							</tr>
							<tr>
								<td class="textright">
									标签（*）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="File_Tags" id="File_Tags" />
								</td>
							</tr>
							<tr>
								<td class="textright">
									创作年份(*)：
								</td>
								<td>
									<input type="text" class="qunziinput" name="File_OccurTime" id="File_OccurTime" onclick="WdatePicker()" />
								</td>
							</tr>
							<tr>
								<td class="textright">
									才艺类别：
								</td>
								<td>
									<%= this.TypeName %>
								</td>
							</tr>
							<tr>
								<td valign="top" class="textright">
									介绍：
								</td>
								<td>
									<textarea class="quanzitextarea" rows="5" cols="10" name="File_Summary" id="File_Summary"></textarea>
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
									<h6>
										<input name="" type="checkbox" value="true" checked="checked" />已阅读并且同意优童协议及土豆协议</h6>
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
									<input id="BtnOK" type="submit" value="确定上传" class="button1" />
								</td>
							</tr>
						</tbody>
					</table>
				</div>
				<div id="FinshPanel">
					<h1>
						上传成功
					</h1>
					<img src='' width="200px" height="200px" alt="上传成功" />
					<a href="Expo-File-Upload.aspx?type=<%= Type %>">继续上传</a>
					<a href="" id="toViewWorks" target="_blank">查看作品</a>
					<a href="Expo-File-List.aspx?type=<%= Type %>">返回列表</a>
				</div>
				<div class="jindublock03">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	<asp:HiddenField ID="File_FileType" runat="server" />
	<asp:HiddenField ID="File_ChannelID" runat="server" />
	<asp:HiddenField ID="File_From" runat="server" />
	<asp:HiddenField ID="File_FileUrl" runat="server" />
	<asp:HiddenField ID="File_ThumbnailUrl" runat="server" />
	<asp:HiddenField ID="File_FileSize" runat="server" />
	<asp:HiddenField ID="File_FileName" runat="server" />
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
				File_File: { required: true },
				File_Title: { required: true },
				File_Tags: { required: true },
				File_OccurTime: { required: true }
			},
			messages: {
				File_File: { required: "必填(*)" },
				File_Title: { required: "必填(*)" },
				File_Tags: { required: "必填(*)" },
				File_OccurTime: { required: "格式不正确" }
			}
		});
	});
</script>
