<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Works-Detail.aspx.cs" Inherits="YouTong.WebSite.Childs.Works_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/common.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "show";
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/">首页</a>&gt;&gt;<a href="#">优童作品</a>
			</div>
			<div class="main">
				<div class="leftblock">
					<div class="zuopinzhanshi">
						<div class="block1">
							<a href="#" class="title">作品展示</a>
							<div class="zhanshiwenzi">
								<p>
									<%= Works.Title %></p>
								<div class="chakanbtn">
									<a href="#" title="查看大图">
										<img src="../images/chakandatu.gif" width="63" height="19" border="0" alt="查看大图" /></a>
									<a href="#" title="加入收藏">
										<img src="../images/jiarusc_btn.gif" width="63" height="19" border="0" alt="加入收藏" /></a>
								</div>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="block2 datuzhanshi">
							<div class="bigimg">
								<% if (Works.FileType == 1) %>
								<% { %>
								<a href="<%= Works.FileUrl %>" title="点击查看作品大图" target="_blank">
									<img src="<%= Works.FileUrl %>" width="480" height="360" border="0" alt="点击查看作品大图" /></a>
								<% } %>
								<% else %>
								<% { %>
								<object width="480" height="360">
									<param name="movie" value="<%= Works.FileUrl %>" />
									<param name="allowFullScreen" value="true" />
									<param name="allowscriptaccess" value="always" />
									<param name="wmode" value="opaque"></param>
									<embed src="<%= Works.FileUrl %>" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" wmode="opaque" width="480" height="360"></embed>
								</object>
								<% } %>
							</div>
							<div class="djan0">
								<h3>
									分享给朋友</h3>
								<input name="" type="text" class="dizhilan" value="http://www.no1child.com/child/works-detail.aspx?id=<%= Works.ID %>" />
								<input type="button" value="复制链接" class="fangdabtn" onclick="javascript:CopyUrl()">
								<div class="clear">
								</div>
							</div>
							<div class="zhanshiyingxiang">
								<a href="#" class="leftimages">
									<img src="../images/leftimages.gif" width="14" height="77" border="0" /></a>
								<ul>
									<li>
										<a class="zuopinbg" title=" " href="#">
											<img width="100" height="75" border="0" alt="" src="../images/zuopin_sp01.gif"><span>作品名称</span></a></li>
									<li>
										<a class="zuopinbg" title=" " href="#">
											<img width="100" height="75" border="0" alt="" src="../images/zuopin_sp01.gif"><span>作品名称</span></a></li>
									<li>
										<a class="zuopinbg" title=" " href="#">
											<img width="100" height="75" border="0" alt="" src="../images/zuopin_sp01.gif"><span>作品名称</span></a></li>
									<li>
										<a class="zuopinbg" title=" " href="#">
											<img width="100" height="75" border="0" alt="" src="../images/zuopin_sp01.gif"><span>作品名称</span></a></li>
								</ul>
								<a href="#" class="rightimages">
									<img src="../images/rightimages.gif" width="14" height="77" border="0" /></a>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="caiyixiu">
						<div class="block1">
							<a href="#" class="title">评论</a>
							<div class="clear">
							</div>
						</div>
						<div class="block2">
							<asp:Repeater ID="rp_Comments" runat="server">
                                <ItemTemplate>
                                <div class="dpneirong newpl">
								    <div class="plneirong changdu">
									    <img width="60" height="60" border="none" src="" class="toux0">
									    <div class="textkp zhanshitext">
										    <p><span class="people">[<%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy-MM-dd HH:mm:ss")%>]</span><span><em><%#WebBasics.Member.Common.MemberFactory.Instance.UserService.GetUser(new Guid(Eval("Reviewer").ToString())).Name%></em>说：</span> </p>
										    <p class="jieshaowenzi"><%#Eval("Title") %></p>
									    </div>
									    <div class="clear"></div>
								     </div>
							    </div>
                                </ItemTemplate>
                            </asp:Repeater>					
							<div class="fenye">
                                <asp:Literal ID="lt_Page" runat="server"></asp:Literal>
							</div>
							<div class="clear"></div>
							<div class="fabiao_pinglun">
								<h3>
									<a name="one">我要评论</a></h3>
								<textarea class="newscomment" name="new_Title" id="" rows="4" cols="70"></textarea>
								<div class="tijiaobtn">
									<asp:ImageButton ID="imgComment" runat="server" 
                                        src="/images/tijiao_btn.gif" width="61" height="21" alt="提交" border="0" 
                                        onclick="imgComment_Click" />
								&nbsp;</div>
								<div class="clear">
								</div>
							</div>
							<div class="kongzhiheight">
							</div>
						</div>
						<div class="block3">
						</div>
					</div>
				</div>
				<div class="rightblock">
					<div id="rukou">
						<dl>
							<img src="../images/top_055.gif"></dl>
						<div id="rukoumain">
							<div class="toubu">
								<a href="#" class="rentx">
									<img src="../images/zuozhe_renwu.gif" width="59" height="59" border="0" align="" /></a>
								<div class="wenzi01">
									<a href="#">作者名称：<span class="yonglan"><%= this.Child.Name %></span></a>
									<a href="#">影像集：<span class="hongse">13个</span></a>
									<a href="#" class="jinru">进入TA的个人主页 ></a>
								</div>
								<div class="clear">
								</div>
							</div>
							<h3>
								影像信息</h3>
							<div class="thing">
								<p>
									影像集：<span>名称名称</span></p>
								<p>
									类别：<span>酷宝宝</span></p>
								<p>
									人气：<span class="shuzi">131</span></p>
								<p>
									收藏：<span class="shuzi">8</span></p>
								<p>
									介绍：<span>我们一家人周末去踏青郊游，大家围在 一起烧烤中...<a href="#">[全部]</a></span></p>
							</div>
						</div>
						<dl>
							<img src="../images/di_27.gif"></dl>
					</div>
					<div class="douxiucang">
						<div class="zhuanjiablock1">
							<div class="kong">
								<a href="#" class="title">其他影像集</a>
								<a href="#" class="more00">全部21个影像集>></a>
							</div>
						</div>
						<div class="zhuanjiablock2">
							<div class="zuopin">
								<div class="listyinji">
									<a href="#" class="yingji"></a>
									<a href="#" class="wydianping00">作品名称</a>
								</div>
								<div class="listyinji">
									<a href="#" class="yingji"></a>
									<a href="#" class="wydianping00">作品名称</a>
								</div>
								<div class="listyinji">
									<a href="#" class="yingji"></a>
									<a href="#" class="wydianping00">作品名称</a>
								</div>
								<div class="listyinji">
									<a href="#" class="yingji"></a>
									<a href="#" class="wydianping00">作品名称</a>
								</div>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="zhuanjiablock3">
						</div>
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
