<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Video-Upload.aspx.cs" Inherits="YouTong.WebSite.Member.Video_Upload" %>

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
				当前位置：<a href="#">首页</a><a>&gt;&gt;</a> <a href="#" class="choose">上传亲子影像秀</a>
			</div>
			<div class="jindu">
				<div class="jindublock01">
					<a class="title" href="#">上传作品</a>
				</div>
				<div class="jindublock02">
					<table width="100%" cellspacing="0" cellpadding="0" border="0" class="sctable">
						<tbody>
							<tr>
								<td class="textright">
									选择上传类别：
								</td>
								<td>
									<span>
										<input type="radio" value="" name="">图片</span><span><input type="radio" value="" name="">视频</span>
								</td>
							</tr>
							<tr>
								<td class="textright" width="25%">
									选择上传文件：
								</td>
								<td width="75%">
									<input type="file" class="qunziinput" name="" value="文件大小不超过500K"><em style="color: #b7b7b7; padding: 0 0 0 20px;">上传文件图片不可超过5M，视频不可超过500M，文件至少大于50KB。</em>
								</td>
							</tr>
							<tr>
								<td class="textright">
									标题（必填）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="">
								</td>
							</tr>
							<tr>
								<td class="textright">
									标签（必填）：
								</td>
								<td>
									<input type="text" class="qunziinput" name="">
								</td>
							</tr>
							<tr>
								<td class="textright">
									创作年份(必填)：
								</td>
								<td>
									<select class="select001" onchange="#">
										<option selected="" value="">年</option>
										<option selected="" value="">2001年</option>
										<option selected="" value="">2000年</option>
										<option selected="" value="">2009年</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="textright">
									才艺类别：
								</td>
								<td>
									<select class="select001" onchange="#">
										<option selected="" value="">美术绘画 </option>
										<option selected="" value="">书 法</option>
										<option selected="" value="">作文</option>
										<option selected="" value="">摄影摄像</option>
										<option selected="" value="">器乐演奏</option>
										<option selected="" value="">歌曲演唱</option>
										<option selected="" value="">舞蹈表演</option>
										<option selected="" value="">少儿英语</option>
										<option selected="" value="">戏剧小品</option>
										<option selected="" value="">手工制作</option>
										<option selected="" value="">体育运动</option>
										<option selected="" value="">科技创意</option>
										<option selected="" value="">朗诵表演</option>
										<option selected="" value="">动画制作</option>
										<option selected="" value="">奥数</option>
										<option selected="" value="">另类其他</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="textright">
									指导老师：
								</td>
								<td>
									<input type="text" class="qunziinput" name=""><!--input type="submit" value="邀请加入" class="button0001"-->
								</td>
							</tr>
							<tr>
								<td valign="top" class="textright">
									介绍：
								</td>
								<td>
									<textarea class="quanzitextarea" rows="5" cols="10" name=""></textarea>
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
									<h6>
										<input name="" type="checkbox" value="" checked />已阅读并且同意优童协议及土豆协议</h6>
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
									<input type="submit" value="确定上传" class="button1">
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
	</form>
</body>
</html>
