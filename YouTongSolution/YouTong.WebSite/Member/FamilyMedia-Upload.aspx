<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyMedia-Upload.aspx.cs" Inherits="YouTong.WebSite.Member.FamilyMedia_Upload" %>

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
	<script src="../js/Tudou/Tudou.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";

		$(function() {
			$("#BtnOK").click(function() {
				if ($("#Works_Type_1").attr("checked")) {
					uploadImage('<%=guid %>');
				}
				else if ($("#Works_Type_2").attr("checked")) {
					uploadVideo();
				}
				else {
					alert("错误");
				}

				return false;
			});
		})

		function imageUploadSuccess(id, big, small) {
			alert("上传成功");
			location = "../childs/works-detail.aspx?id=" + id;
		}
		function imageUploadFailure(msg) {
			alert(msg);
		}
		function uploadImage(id) {
			var action = "/_handlers/photo-upload.ashx?id="+id+"&successCallback=imageUploadSuccess&failureCallback=imageUploadFailure";
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
			$("#Works_FileSize").val(msg.filesize / 1024);
		}

		//上传完毕正在转码
		function tudou_processing(msg) {
			jQuery("#qingkuang").html("上传完毕，正在转码....请勿关闭或者刷新浏览器" + msg.progress + "%;  文件大小：约" + parseInt(msg.filesize / 1024 / 1024) + "MB");
			$("#Works_FileSize").val(msg.filesize / 1024);
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

			$("#Works_FileUrl").val(item.outerPlayerUrl);
			$("#Works_ThumbnailUrl").val(item.picUrl);
			$("#Works_FileName").val(item.id);

			var action = "FamilyMedia-Upload.aspx?action=video";
			var frm = $("#form1");
			frm.attr("action", action);
			frm.removeAttr("target");
			$("#Works_File").remove();

			frm.submit();
		}
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
				<a href="#" class="choose">上传影像</a>
			</div>
			<div class="jindu">
				<div class="jindublock01">
					<a class="title" href="#">上传亲子影像</a>
				</div>
				<div class="jindublock02">
					<div id="qingkuang">
					</div>
					<asp:HiddenField ID="Works_FileUrl" runat="server" />
					<asp:HiddenField ID="Works_ThumbnailUrl" runat="server" />
					<asp:HiddenField ID="Works_FileSize" runat="server" />
					<asp:HiddenField ID="Works_FileName" runat="server" />
					<table width="100%" cellspacing="0" cellpadding="0" border="0" class="sctable">
						<tbody>
							<tr>
								<td class="textright">
									选择上传类别：
								</td>
								<td>
									<span>
										<input id="Works_Type_1" type="radio" name="Works_Type" value="1" checked="checked" />图片</span><span><input id="Works_Type_2" type="radio" name="Works_Type" value="2" />视频</span>
								</td>
							</tr>
							<tr>
								<td class="textright" width="25%">
									选择上传文件：
								</td>
								<td width="75%">
									<input type="file" class="qunziinput" name="Works_File" id="Works_File" /><br />
									<em style="color: #b7b7b7;">上传文件图片不可超过5M，视频不可超过500M，文件至少大于50KB。</em>
								</td>
							</tr>
							<tr>
								<td class="textright">
									分类：
								</td>
								<td>
									<asp:DropDownList ID="Works_ChannelID" runat="server">
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="textright">
									标题（*）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="Works_Title" id="Works_Title" />
								</td>
							</tr>
							<tr>
								<td class="textright">
									创作年份(*)：
								</td>
								<td>
									<input type="text" class="qunziinput" name="Works_OccurTime" id="Works_OccurTime" onclick="WdatePicker()" />
								</td>
							</tr>
							<tr>
								<td class="textright">
									标签（*）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="Works_Tags" id="Works_Tags" />
								</td>
							</tr>
							<tr>
								<td valign="top" class="textright">
									介绍：
								</td>
								<td>
									<textarea class="quanzitextarea" rows="5" cols="10" name="Works_Summary" id="Works_Summary"></textarea>
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
				Works_File: { required: true },
				Works_Title: { required: true },
				Works_Tags: { required: true },
				Works_OccurTime: { required: true }
			},
			messages: {
				Works_File: { required: "必填(*)" },
				Works_Title: { required: "必填(*)" },
				Works_Tags: { required: "必填(*)" },
				Works_OccurTime: { required: "格式不正确" }
			}
		});
	});
</script>
