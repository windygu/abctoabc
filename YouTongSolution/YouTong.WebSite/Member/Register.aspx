<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YouTong.WebSite.Member.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
	</script>
	<script src="../Datas/AreaJson.aspx" type="text/javascript"></script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="register">
				<h2>
					<span>
						<a href="#">优童首页</a><a>>></a><a>用户注册</a></span></h2>
				<div class="event">
					<div class="leftevent">
						<% if (this.IsAnonymous) %>
						<% { %><p style="color: #a6ce39">
							填写家长或老师个人信息： * 为必填</p>
						<table class="eventmain" cellspacing="0" cellpadding="0" border="0" width="100%">
							<tr>
								<td width="19">
								</td>
								<td width="100" class="textright">
									<em>* </em>登录用户名：
								</td>
								<td width="170" class="textleft">
									<asp:TextBox ID="User_UserName" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td width="310" class="textleft" id="tipUserName">
									登录名可以是英文或者数字
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>登录密码：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Password" runat="server" TextMode="Password" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft" id="tipPassword">
									最少6个字符，请使用英文字母（不区分大小写）、符号或数字
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>再次输入密码：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Password2" runat="server" TextMode="Password" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft" id="tipPassword2">
									请再次输入密码
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>真实姓名：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Name" runat="server" CssClass="input1" MaxLength="5"></asp:TextBox>
								</td>
								<td class="textleft" id="tipName">
									请填写<b style="color: #a6ce39">家长</b>或<b style="color: #a6ce39">老师本人</b>的的真实姓名，作为参加活动、发送奖品时的重要核对信息
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									昵称：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_NickName" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft" id="tipNickName">
									昵称长度1-5位，可由中英文、数字、字符组成
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>手机：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Mobile" runat="server" CssClass="input1" MaxLength="11"></asp:TextBox>
								</td>
								<td class="textleft" id="tipMobile">
									请正确填写您的11位手机号码，我们会将最新教育考试信息发送给您
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>您的E-mail：
								</td>
								<td class="textleft">
									<asp:TextBox ID="User_Email" runat="server" CssClass="input1"></asp:TextBox>
								</td>
								<td class="textleft" id="tipEmail">
									请输入有效邮箱地址，方便日后找回密码
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									性别：
								</td>
								<td class="textleft">
									<input name="User_Gender" type="radio" value="1" checked="checked" />
									男
									<input name="User_Gender" type="radio" value="2" />
									女
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>地区：
								</td>
								<td class="textleft" colspan="2">
									<asp:DropDownList ID="User_City" runat="server">
									</asp:DropDownList>
									&nbsp;<asp:DropDownList ID="User_Region" runat="server">
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									孩子：
								</td>
								<td class="textleft">
									<asp:RadioButton ID="HasChildA" runat="server" Text="有" GroupName="User_HasChild" Checked="true" value="true" />
									<asp:RadioButton ID="HasChildB" runat="server" Text="无" GroupName="User_HasChild" value="false" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<em>* </em>验证码：
								</td>
								<td class="textleft">
									<input type="text" class="input1" name="VerifyCode" id="VerifyCode" />
								</td>
								<td class="textleft">
									<img src="../VerifyCode.aspx?action=Register" />
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<input name="AcceptAgreement" id="AcceptAgreement" type="checkbox" value="true" checked="checked" />
								</td>
								<td class="textleft" id="xieyi">
									我已阅读并接受优童网注册协议
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr>
								<td>
								</td>
								<td class="textright">
									<input name="AcceptReceive" id="AcceptReceive" type="checkbox" value="true" checked="checked" />
								</td>
								<td class="textleft">
									是的！我希望收到来自优童网的活动、新闻和服务的定期更新消息。
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
									<asp:Button ID="BtnOK" runat="server" Text="确定" CssClass="button1" OnClick="BtnOK_Click" />
								</td>
								<td class="textleft">
								</td>
							</tr>
							<tr height="25px">
								<td rowspan="4">
								</td>
							</tr>
						</table>
						<% } %>
						<% else %>
						<% { %>
						你处于登录状态，请先<a href="SignOut.aspx">登出</a>
						<% } %>
					</div>
					<%--<div class="rightevent">
					</div>--%>
					<div class="clear">
					</div>
					<%--					<div class="tishiyu">
						<p>
							<span>未完成注册！ </span>请重新填写 登录密码 部分。</p>
					</div>--%>
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
<script type="text/javascript">
	$(function() {
		//		$("#AcceptAgreement").click(function() {
		//			if ($(this).attr("checked")) {
		//				$("#BtnOK").enable(true);
		//			}
		//			else {
		//				$("#BtnOK").enable(false);
		//			}
		//		});


		var roots = getRootAreas();
		var len = roots.length;
		for (var i = 0; i < len; i++) {
			$("<option value='" + roots[i].ID + "'>" + roots[i].Name + "</option>").appendTo("#User_City");
		}

		$("#User_City").change(
			function() {
				var rootId = $(this).val();
				var childs = getChildAreas(rootId);

				$("#User_Region").empty();

				for (var i = 0; i < childs.length; i++) {
					$("<option value='" + childs[i].ID + "'>" + childs[i].Name + "</option>").appendTo("#User_Region");
				}
			}
		);

		$("#User_City").change();

		jQuery.validator.addMethod(
			"letterAndNumber",
			function(username, element) {
				username = username.replace(/\s+/g, "");
				return this.optional(element) || username.match(/^[0-9a-zA-Z]+\w*$/);
			},
			"请使用英文或数字或两者组合");

		jQuery.validator.addMethod(
			"zhWord",
			function(username, element) {
				username = username.replace(/\s+/g, "");
				return this.optional(element) || username.match(/^[\u4E00-\u9FA5]+\w*$/);
			},
			"只能使用中文");

		$("#form1").validate({
			rules: {
				User_UserName: { letterAndNumber: true, required: true,
					minlength: 2, maxlength: 15,
					remote: "/_Handlers/ValidateUnique.ashx"
				},
				User_Password: { required: true, minlength: 6, maxlength: 20 },
				User_Password2: { required: true, equalTo: "#User_Password" },
				User_Name: { required: true, zhWord: true },
				User_Mobile: { required: true, number: true, minlength: 11, maxlength: 11,
					remote: "/_Handlers/ValidateUnique.ashx"
				},
				User_Email: { required: true, email: true,
					remote: "/_Handlers/ValidateUnique.ashx"
				},
				VerifyCode: { required: true },
				AcceptAgreement: { required: true }
			},
			messages: {
				User_UserName: { required: "必填(*)",
					minlength: "至少2个字符", maxlength: "最长15个字符",
					remote: "用户名已被占用"
				},
				User_Password: { required: "必填(*)", minlength: "至少6个字符", maxlength: "最长20个字符" },
				User_Password2: { required: "必填(*)", equalTo: "两次密码输入必须相等" },
				User_Name: { required: "必填(*)" },
				User_Mobile: { required: "必填(*)", number: "格式不正确", minlength: "格式不正确", maxlength: "格式不正确",
					remote: "手机号已被占用"
				},
				User_Email: { required: "必填(*)", email: "格式不正确",
					remote: "Email已被占用"
				},
				VerifyCode: { required: "必填(*)" },
				AcceptAgreement: { required: function() { alert("请勾选注册协议") } }
			}
		});

		//		$("#User_UserName").focusout(
		//			function() {
		//				$.getJSON("/_Handlers/ValidateUnique.ashx", { User_UserName: $(this).val() },
		//					function(data) {
		//						if (data.result) {
		//							$("#tipUserName").html("用户名已被占用");
		//						} else {
		//							$("#tipUserName").html("");
		//						}
		//					}
		//				)
		//			});
	});
</script>
