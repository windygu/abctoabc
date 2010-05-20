<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterChild.aspx.cs" Inherits="YouTong.WebSite.Member.RegisterChild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>孩子注册|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	<script src="../Datas/AreaJson.aspx" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "default";
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<h2>
					<span>
						<a href="#">优童首页</a><a>&gt;&gt;</a><a>优童信息</a></span></h2>
				<div class="event">
					<div class="leftevent">
						<p style="color: #a6ce39">
							完善您孩子的信息，为您的孩子建立成长档案，记录孩子的精彩 *为必填</p>
						<table class="eventmain" cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td width="19">
								</td>
								<td width="100" class="textright">
									<em>* </em>孩子姓名：
								</td>
								<td width="170" class="textleft">
									<asp:TextBox ID="Child_Name" runat="server" CssClass="input1" MaxLength="5"></asp:TextBox>
								</td>
								<td width="310" class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									昵称：
								</td>
								<td class="textleft">
									<asp:TextBox ID="Child_NickName" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft">
									昵称长度1-5位，可由中英文、数字、字符组成
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									孩子性别：
								</td>
								<td class="textleft">
									<input name="Gender" type="radio" value="1" checked="checked" />
									男
									<input name="Gender" type="radio" value="2" />
									女
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>出生年月：
								</td>
								<td class="textleft" colspan="2">
									<asp:TextBox ID="Child_Birthday" runat="server" CssClass="input1" onclick="WdatePicker()"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>目前就读学校：
								</td>
								<td class="textleft" colspan="2">
									<select id="Child_City" class="select1">
									</select>
									<select id="Child_Region" class="select1">
									</select>
									<select id="Child_Level" class="select1">
										<option value="0">学校类型</option>
										<option value="1">幼儿园</option>
										<option value="2">小学</option>
									</select>
									<select id="Child_School" class="select1">
									</select>
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>入学年份：
								</td>
								<td class="textleft">
									<select class="select1">
										<option selected="1996" value="">1996</option>
										<option selected="1997" value="">1997</option>
										<option selected="1998" value="">1998</option>
										<option selected="1999" value="">1999</option>
										<option selected="2000" value="">2000</option>
										<option selected="2001" value="">2001</option>
										<option selected="2002" value="">2002</option>
										<option selected="2003" value="">2003</option>
										<option selected="2004" value="">2004</option>
										<option selected="2005" value="">2005</option>
										<option selected="2006" value="">2006</option>
										<option selected="2007" value="">2007</option>
										<option selected="2008" value="">2008</option>
										<option selected="2009" value="">2009</option>
										<option selected="2010" value="">2010</option>
										<option selected="2011" value="">2011</option>
									</select>
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>学校班级：
								</td>
								<td class="textleft">
									<select class="select1">
										<option value="1">一班</option>
										<option value="2">二班</option>
										<option value="3">三班</option>
										<option value="4">四班</option>
										<option value="5">五班</option>
										<option value="6">六班</option>
										<option value="7">七班</option>
										<option value="8">八班</option>
										<option value="9">九班</option>
										<option value="10">十班</option>
										<option value="11">其他</option>
									</select>
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright" valign="top">
									<em>* </em>才艺类别：
								</td>
								<td class="textleft" colspan="2">
									<div class="check">
										<span>
											<input name="chkInter" value="1" type="checkbox" class="checkbox" id="chk_0" /><label for="chk_0">美术绘画</label></span><span><input name="chkInter" value="2" type="checkbox" class="checkbox" id="chk_1" /><label for="chk_1">书法</label></span><span><input name="chkInter" value="3" type="checkbox" class="checkbox" id="chk_2" /><label for="chk_2">摄影摄像</label></span><span><input name="chkInter" value="4" type="checkbox" class="checkbox" id="chk_3" /><label for="chk_3">器乐演奏</label></span><span><input name="chkInter" value="5" type="checkbox" class="checkbox" id="chk_4" /><label for="chk_4">歌曲演唱</label></span><span><input name="chkInter" value="6" type="checkbox" class="checkbox" id="chk_5" /><label for="chk_5">舞蹈表演</label></span><span><input name="chkInter" value="7" type="checkbox" class="checkbox" id="chk_6" /><label for="chk_6">少儿英语</label></span><span><input name="chkInter" value="8" type="checkbox" class="checkbox" id="chk_7" /><label for="chk_7">戏剧小品</label></span><span><input name="chkInter" value="9" type="checkbox" class="checkbox" id="chk_8" /><label for="chk_8">手工制作</label></span><span><input name="chkInter" value="10" type="checkbox" class="checkbox" id="chk_9" /><label for="chk_9">体育运动</label></span><span><input name="chkInter" value="11" type="checkbox" class="checkbox" id="chk_10" /><label for="chk_10">科技创意</label></span><span><input name="chkInter" value="12" type="checkbox" class="checkbox" id="chk_11" /><label for="chk_11">朗诵表演</label></span><span><input name="chkInter" value="13" type="checkbox" class="checkbox" id="chk_12" /><label for="chk_12">奥数</label></span><span><input name="chkInter" value="14" type="checkbox" class="checkbox" id="chk_13" /><label for="chk_13">作文</label></span><span><input name="chkInter" value="15" type="checkbox" class="checkbox" id="chk_14" /><label for="chk_14">另类其他</label></span>
									</div>
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
									<asp:Button ID="BtnOK" runat="server" Text="确&nbsp;&nbsp;认" CssClass="button1" OnClick="BtnOK_Click" />
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
					<%--<div class="rightevent">
					</div>--%>
					<div class="clear">
					</div>
					<%--<div class="tishiyu">
						<p>
							<span>未完成注册！ </span>
							<br />
							没有填写*项：您有未填写完整的内容，请继续填写 或者 跳过。</p>
					</div>--%>
					<div class="tongming" style="display: none;">
						<div class="tou">
							<h4>
								优童网已经发现共有“<span> 张楚楚</span>”4名，如果您发现下列孩子中有您的孩子，<br />
								那么您可以不必重复填写孩子资料。<br />
								选择后，您可以确认孩子与您是否是（亲戚/朋友）关系。</h4>
							<a href="#" class="delete">
								<img src="../images/delete.gif" width="31" height="31" border="0" /></a>
						</div>
						<div class="clear">
						</div>
						<ul>
							<li><em>
								<input name="" type="checkbox" value="" class="checkbox" /></em>
								<a href="#"><span>张楚楚</span><br />
									6岁<br />
									上海市虹口区<br />
									虹口中心小学</a></li>
							<li><em>
								<input name="" type="checkbox" value="" class="checkbox" /></em>
								<a href="#"><span>张楚楚</span><br />
									6岁<br />
									上海市虹口区<br />
									虹口中心小学</a></li>
							<li><em>
								<input name="" type="checkbox" value="" class="checkbox" /></em><a href="#"><span>张楚楚</span><br />
									6岁<br />
									上海市虹口区<br />
									虹口中心小学</a></li>
							<li><em>
								<input name="" type="checkbox" value="" class="checkbox" /></em><a href="#"><span>张楚楚</span><br />
									6岁<br />
									上海市虹口区<br />
									虹口中心小学</a></li>
						</ul>
						<div class="guanxianniu">
							<input type="submit" class="button10" value="与选中孩子建立关系"><input type="submit" class="button10" value="不，继续完善孩子信息">
						</div>
					</div>
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
<script type="text/javascript">

	jQuery.validator.addMethod(
			"zhWord",
			function(username, element) {
				username = username.replace(/\s+/g, "");
				return this.optional(element) || username.match(/^[\u4E00-\u9FA5]+\w*$/);
			},
			"只能使用中文");

	$(function() {
		$("#form1").validate({
			rules: {
				Child_Name: { required: true, zhWord: true },
				Child_Birthday: { required: true }
			},
			messages: {
				Child_Name: { required: "必填(*)" },
				Child_Birthday: { required: "必填(*)" }
			}
		});

		var roots = getRootAreas();
		var len = roots.length;
		$("<option value='0'>请选择城市</option>").appendTo("#Child_City");
		for (var i = 0; i < len; i++) {
			$("<option value='" + roots[i].ID + "'>" + roots[i].Name + "</option>").appendTo("#Child_City");
		}

		$("#Child_City").change(
			function() {
				var rootId = $(this).val();
				var childs = getChildAreas(rootId);

				$("#Child_Region").empty();

				$("<option value='0'>请选择地区</option>").appendTo("#Child_Region");
				for (var i = 0; i < childs.length; i++) {
					$("<option value='" + childs[i].ID + "'>" + childs[i].Name + "</option>").appendTo("#Child_Region");
				}

				$("#Child_Region").change();
			}
		);

		$("#Child_Region").change(function() { $("#Child_Level").change() });

		$("#Child_Level").change(
			function() {
				var id = $("#Child_Region").val();
				var level = $(this).val();

				$("#Child_School").empty();

				$.getJSON("/_Handlers/GetSchools.ashx", { region: id, level: level },
					function(data) {
						for (var i = 0; i < data.length; i++) {
							$("<option value='" + data[i].ID + "'>" + data[i].Name + "</option>").appendTo("#Child_School");
						}
					}
				 );
			}
		);

		$("#Child_City").change();
		$("#Child_Region").change();
		$("#Child_Level").change();
	});
</script>
