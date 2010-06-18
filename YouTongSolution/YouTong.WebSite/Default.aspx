<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YouTong.WebSite._Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优童首页|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="css/content.css" type="text/css" rel="stylesheet" />
	<link href="css/default.css" type="text/css" rel="stylesheet" />
	<script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="js/走马灯/jcarousellite.js" type="text/javascript"></script>
	<script src="js/common.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "default";

		$(function() {
			$('.yousanjiao').click(function() {
				var p = $(this).parent();
				var d = $(p).find(".move").css('left');
				var distance = getValue(d);
				var newdistance = distance - 82;
				if (newdistance >= Number(-($(p).find('.nav li').length - 4) * 82)) {
					$(p).find('.move').animate({ 'left': newdistance + "px" }, "200");
				}
			});

			$('.zuosanjiao').click(function() {
				var p = $(this).parent();
				var d = $(p).find('.move').css('left');
				var distance = getValue(d);
				var newdistance = distance + 82;
				if (newdistance <= 0) {
					$(p).find('.move').animate({ 'left': newdistance + "px" }, "200");
				}
			});

			$('#nav li').children('a').click(function() {
				$('#nav li').find('a').each(function() {
					if ($(this).hasClass('choose')) {
						$(this).removeClass('choose');
						var cls = $(this).attr('id');
						var c = cls.substring(cls.length - 1, cls.length);
						$('#KidInfo' + c).css('display', 'none');
					}
				});
				$(this).addClass('choose');
				var cls = $(this).attr('id');
				var c = cls.substring(cls.length - 1, cls.length);
				$('#KidInfo' + c).css('display', 'block');
			});

			$('.nav').each(function() {
				$(this).find('li').eq(0).children('a').addClass('choose');
            });

            $(".jCarouselLite").jCarouselLite({
                auto: 3000,
                speed: 100,
                vertical: "vertically",
                visible: 1
            });
			
		});

		function getValue(target) {
			var val = target.substring(0, target.length - 2);
			return Number(val);
		}
	</script>
</head>
<body>

    
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="main">
				<div class="leftblock">
					<div class="jiaodiantu">
						<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" id="scriptmain" name="scriptmain" codebase="http://download.macromedia.com/pub/shockwave/cabs/
                                flash/swflash.cab#version=6,0,29,0" width="580px" height="206px">
							<param name="movie" value="_Resources/bcastr.swf?bcastr_xml_url=_Resources/bcastr.xml" />
							<param name="quality" value="high" />
							<param name="scale" value="noscale" />
							<param name="LOOP" value="false" />
							<param name="menu" value="false" />
							<param name="wmode" value="transparent" />
							<embed src="_Resources/bcastr.swf?bcastr_xml_url=_Resources/bcastr.xml" width="580px" height="206px" loop="false" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" salign="T" name="scriptmain" menu="false" wmode="transparent"></embed>
						</object>
					</div>
					<div class="wenzi">
						<p>
							网站动态:</p>
						<ol>
						
							<li>
							    <div class="jCarouselLite" style="visibility:hidden;">
                                    <ul>
                                        <asp:Repeater ID="Repeater网站动态" runat="server">
                                            <ItemTemplate>
                                                <li><a href="news/news-detail.aspx?id=<%# Eval("ID") %>" target="_blank" class="choose">
											        <%# Eval("Title") %></a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
								</li>
						</ol>
						<div class="ziti">
							<p>
								已注册优童 <span><%=registerCount %></span></p>
							<p>
								已上传作品 <span><%=anyFilesCount %></span></p>
						</div>
						<div class="clear">
						</div>
					</div>
					<div class="caiyixiu">
						<div class="block1">
							<a href="/childs/works.aspx" class="title">才艺秀</a>
							<div class="tab">
								<a style="cursor: pointer" id="left" class="zuosanjiao"></a>
								<div style="width: 328px; overflow: hidden; float: left; height: 27px; padding: 0px; margin: 0px; position: relative;">
									<div class="move" style="width: 800%; float: left; position: relative; left: 0px">
										<ul class="nav" id="nav">
											<% foreach (var channel in WorksCategories) %>
											<% { %>
											<li>
												<a href="javascript:void(0);" onclick="GetWords(this, '<%=channel.ID%>');"><span>
													<%= channel.Name %></span></a></li>
											<% } %>
										</ul>
									</div>
								</div>
								<a style="cursor: pointer" id="right" class="yousanjiao"></a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="block2">
							<asp:Repeater ID="RepeaterWorks" runat="server">
								<HeaderTemplate>
									<div class="waibu" id="workContainer">
										<div class="fenline">
								</HeaderTemplate>
								<ItemTemplate>
									<% i++; %>
									<% if (i != 1 && i % 2 == 1) %>
									<% { %><div class="clear">
									</div>
									</div>
									<div class="fenline">
										<% } %>
										<div class="zuopin">
											<div class="listleft">
												<a href="/childs/works-detail.aspx?id=<%# Eval("ID") %>" class="zuopinbg">
													<img src="<%# Eval("ThumbnailUrl") %>" width="100" height="75" border="0" alt="" /></a>
											</div>
											<div class="zpxinxi">
												<a href="/childs/works-detail.aspx?id=<%# Eval("ID") %>" class="zpmclan">
													<%# Eval("Title") %></a>
												<p class="zpzz">
													作者： <span>
														<%# DataCache.GetChildNameByUserID((Guid)Eval("UserID"))%>
													</span>
												</p>
												<p class="zpzz">
													学校： <span>
														<%# DataCache.GetSchoolNameByUserID((Guid)Eval("UserID"))%></span>
												</p>
												<div class="clear">
												</div>
											</div>
											<div class="clear">
											</div>
											<p class="renqisc">
												<span>人气：<em>131</em></span><span> 评分：<em>4.2分</em></span></p>
											<a href='/childs/works-detail.aspx?id=<%# Eval("ID") %>' class='dcpl'><%#GetComment(Eval("ID"),YouTong.WebSite.Codes.EntityName.WorkCommentEntity) %></a>
										</div>
								</ItemTemplate>
								<FooterTemplate>
									<div class="clear">
									</div>
									</div> </div>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="lipin">
						<a href="http://www.no1child.com/3m/" target="_blank">
							<img src="/_Resources/images/思高大banner.jpg" width="583" height="86" border="0" alt="" /></a>
					</div>
					<div class="youtongxing">
						<div class="block1">
							<a href="#" class="title">本月优童星</a>
						</div>
						<div class="block2">
							<% if (this.StarChild != null) %>
							<% { %>
							<div class="waibu tongxing">
								<div class="ertongtu">
									<a href="/childs/ChildDefault.aspx?userid=<%= StarChild.ParentID %>" title="" class="touxiang">
										<img src="<%= DataCache.GetHeadPicture("/images/child(5).jpg") %>" alt="" />
										<span>
											<%= StarChild.Name %><em><%= StarChild.Age %>岁</em></span>
									    <div style="padding:0 0 0 10px;color:#666666;">学校： <em style="color:#000000;"><%=DataCache.GetSchoolNameByUserID(StarChild.ParentID.Value)%></em></div>
											</a>
								</div>
								<div class="jieshao">
									<a href="#">采访标题</a>
									<p><%=StarTitleArticle.Title%></p>
									<a href="http://www.no1child.com/news/news-detail.aspx?id=<%=StarTitleArticle.ID %>" class="ydqw">[阅读全文]</a>
								</div>
								<div class="etzuopin">
									<ul>
										<asp:Repeater ID="RepeaterStarChildWorks" runat="server">
											<ItemTemplate>
												<li>
													<a href="childs/works-detail.aspx?id=<%# Eval("ID") %>" title="" class="">
														<img width="80" height="60" border="0" alt="" src="<%# Eval("ThumbnailUrl") %>"></a></li>
											</ItemTemplate>
										</asp:Repeater>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
							<% } %>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="youtongxiu">
						<div class="block1">
							<a href="/childs/index.aspx" class="title">优童秀</a>
							<%--							<div class="tab">
								<a style="cursor: pointer" id="left" class="zuosanjiao"></a>
								<ul class="nav">
									<li><a href="#" class="choose"><span>美术绘画</span></a></li>
									<li><a href="#"><span>器乐演奏</span></a></li>
									<li><a href="#"><span>歌曲演唱</span></a></li>
									<li><a href="#"><span>舞蹈表演</span></a></li>
								</ul>
								<a style="cursor: pointer" id="right" class="yousanjiao"></a>
							</div>--%>
							<div class="clear">
							</div>
						</div>
						<div class="block2">
							<asp:Repeater ID="RepeaterChild" runat="server">
								<HeaderTemplate>
									<div class="waibu">
										<div class="fenline">
								</HeaderTemplate>
								<ItemTemplate>
									<% i++; %>
									<% if (i != 1 && i % 2 == 1) %>
									<% { %><div class="clear">
									</div>
									</div>
									<div class="fenline">
										<% } %>
										<div class="zuopin">
											<div class="listleft">
												<a href="/childs/ChildDefault.aspx?userid=<%# Eval("ParentID") %>" class="zuopinbg youfloat">
													<img src='<%# DataCache.GetHeadPicture(String.Format("/images/child({0}).jpg",Container.ItemIndex+1)) %>' width="100" height="75" border="0" alt="" /></a>
											</div>
											<div class="zpxinxi">
												<a href="/childs/ChildDefault.aspx?userid=<%# Eval("ParentID") %>" title=" " class="zpmclan">
													<%# Eval("Name") %></a>
												<p class="zpzz">
													学校： <span><%#DataCache.GetSchoolNameByUserID(new Guid(Eval("ParentID").ToString()))%></span>
												</p>
												<p class="zpzz">
													最新寄语<span><%#GetCommentCounts(Eval("ID"), YouTong.WebSite.Codes.EntityName.ChildCommentEntity)%></span>条</p>
												<div class="clear">
												</div>
											</div>
											<div class="clear">
											</div>
											<p class="renqisc">
												<span>人气：<em>131</em></span><span> 关注：<em>131</em></span></p>
										    <a href="/childs/ChildDefault.aspx?userid=<%# Eval("ParentID") %>" class="dcpl"><%#GetComment(Eval("ID"), YouTong.WebSite.Codes.EntityName.ChildCommentEntity) %></a>
										</div>
								</ItemTemplate>
								<FooterTemplate>
									<div class="clear">
									</div>
									</div> </div>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="qinzixiu">
						<div class="block1">
							<a href="/childs/familymedia.aspx" class="title">亲子影像秀</a>
							<div class="tab">
								<a style="cursor: pointer" class="zuosanjiao"></a>
								<div style="width: 328px; overflow: hidden; float: left; height: 27px; padding: 0px; margin: 0px; position: relative;">
									<div class="move" style="width: 800%; float: left; position: relative; left: 0px">
										<ul class="nav" id="mediaNav">
											<% foreach (var channel in MediaCategories) %>
											<% { %>
											<li>
												<a href="javascript:void(0);" onclick="GetMedias(this,'<%=channel.ID %>');"><span>
													<%= channel.Name %></span></a></li>
											<% } %>
										</ul>
									</div>
								</div>
								<a style="cursor: pointer" id="A2" class="yousanjiao"></a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="block2">
							<% i = 0; %>
							<asp:Repeater ID="RepeaterMedia" runat="server">
								<HeaderTemplate>
									<div class="waibu" id="mediaContainer">
										<div class="fenline">
								</HeaderTemplate>
								<ItemTemplate>
									<% i++; %>
									<% if (i != 1 && i % 2 == 1) %>
									<% { %><div class="clear">
									</div>
									</div>
									<div class="fenline">
										<% } %>
										<div class="zuopin">
											<div class="listleft">
												<a href="/childs/familymedia-detail.aspx?id=<%# Eval("ID") %>" title=" " class="zuopinbg">
													<img src="<%# Eval("ThumbnailUrl") %>" width="100" height="75" border="0" alt="" /></a>
											</div>
											<div class="zpxinxi">
												<a href="/childs/familymedia-detail.aspx?id=<%# Eval("ID") %>" title=" " class="zpmclan">
													<%# Eval("Title") %></a>
												<p class="zpzz">
													作者： <span>
														<a href="/Childs/ParentDefault.aspx?userid=<%# Eval("UserID") %>"><%# DataCache.GetChildNameByUserID((Guid)Eval("UserID"))%></a></span></p>
												<p class="zpzz">
													学校： <span>
														<%# DataCache.GetSchoolNameByUserID((Guid)Eval("UserID"))%>
													</span>
												</p>
												<div class="clear">
												</div>
											</div>
											<div class="clear">
											</div>
											<p class="renqisc">
												<span>人气：<em>131</em></span><span> 评分：<em>4.2分</em></span></p>
											<a href='/childs/works-detail.aspx?id=<%# Eval("ID") %>' class='dcpl'><%#GetComment(Eval("ID"), YouTong.WebSite.Codes.EntityName.MediaCommentEntity) %></a>
										</div>
								</ItemTemplate>
								<FooterTemplate>
									<div class="clear">
									</div>
									</div> </div>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="hotnews">
						<div class="block1">
							<div class="kong">
								<a href="javascript:void(0)" class="title">热门话题</a>
							</div>
						</div>
						<div class="clear">
						</div>
						<div class="block2">
							<div class="huatimain">
								<table class="huati" cellpadding="0" cellspacing="0" border="0" width="100%">
									<thead>
										<th width="60%">
											话题
										</th>
										<th width="15%">
											作者
										</th>
										<th width="25%">发表日期</th>
									</thead>
									<tbody>
									<asp:Repeater ID="rp_HotTopic" runat="server">
									    <ItemTemplate>
									    <tr>
										<td><a href="<%#GetItemByObject(Eval("Summary"), 3)%>" target="_blank"><%#Eval("Title") %></a>
										</td>
										<td>
											<%#GetItemByObject(Eval("Summary"), 0)%>
										</td>
										<td align="center">
											<%#GetItemByObject(Eval("Summary"), 1)%>
										</td>
									</tr>
									    </ItemTemplate>
									</asp:Repeater>
									
									</tbody>
								</table>
							</div>
						</div>
						<div class="block3">
						</div>
					</div>
				</div>
				<div class="rightblock">
					<div class="login">
						<% if (this.IsAnonymous) %>
						<% { %>
						<div class="denglv" id="denglv">
							<div class="kuai01">
								<div class="yonghm">
									<span class="white">用户名</span>
									<asp:TextBox ID="User_UserName" runat="server" CssClass="shurukuang"></asp:TextBox>
								</div>
								<div class="clear">
								</div>
								<div class="mima">
									<span class="white">密&nbsp;&nbsp;码</span>
									<asp:TextBox ID="User_Password" CssClass="shurukuang" TextMode="Password" runat="server"></asp:TextBox>
								</div>
								<div class="clear">
								</div>
								<a href="Member/Register.aspx" class="zcbtn">
									<img src="images/zc_btn.gif" width="110" height="32" border="0" alt="注册" /></a>
							</div>
							<div class="kuai02">
								<asp:ImageButton ID="BtnLogin" runat="server" ImageUrl="images/dl_btn.gif" Width="62px" Height="48px" OnClick="BtnLogin_Click" />
								<div class="wangji">
									<a href="javascript:void(0)">忘记密码？</a>
								</div>
							</div>
						</div>
						<% } %>
						<% else %>
						<% { %>
						<% var myChild = this.GetFirstChild(); %>
						<div class="denglvhou">
							<div class="toubu xintoubu">
								<% if (myChild != null) %>
								<% { %>
								<a class="rentx" href="/member/index.aspx">
									<img width="59" height="59" border="0" src="<%= DataCache.GetHeadPicture(User.HeadPicture) %>"></a>
								<div class="wenzi01">
									<a href="/childs/parentdefault.aspx?userid=<%=User.ID %>">用户：<span><%= this.User.UserName %></span></a>
									<a href="/childs/childdefault.aspx?userid=<%=User.ID %>">我的优童：<span class="hongse"><%= myChild.Name %></span><span class="hongse"><%= myChild.Age %>岁</span></a>
									<%--<a href="#">消息：<span class="hongse">0条</span></a>--%>
									<%--<a class="jinru" href="#" style="display: none;">[添加优童档案]</a>--%>
								</div>
								<% } %>
								<% else %>
								<% { %>
								<span>
									<%= this.User.UserName %></span>，<br />
								你还没有添加孩子信息，请在<a href="Member/RegisterChild.aspx">这里</a>添加
								<% } %>
								<div class="clear">
								</div>
								<div class="jiekou">
									<a class="jinru" href="/grow/grow.aspx">[用户管理中心]</a><a class="jinru" href="Member/SignOut.aspx">[退出登录]</a>
								</div>
							</div>
						</div>
						<% } %>
						<div class="kuaijie">
						<% if (this.IsAnonymous)
         {%>
							<ul>
								<li>
									<a href="/Member/Login.aspx">
										<img src="images/czll.gif" width="63" height="63" border="0" alt="成长履历" /></a></li>
								<li>
									<a href="Member/Works-Upload.aspx">
										<img src="images/sccy.gif" width="63" height="63" border="0" alt="上传才艺" /></a></li>
								<li>
									<a href="/Member/Login.aspx">
										<img src="images/qzyx.gif" width="63" height="63" border="0" alt="亲子影像" /></a></li>
								<li>
									<a href="/Blogs/Blog-Write.aspx">
										<img src="images/zxbk.gif" width="63" height="63" border="0" alt="撰写博客" /></a></li>
								<li>
									<a href="#">
										<img src="images/bjzy.gif" width="63" height="63" border="0" alt="班级主页" /></a></li>
								<li>
									<a href="#">
										<img src="images/rchd.gif" width="63" height="63" border="0" alt="日程活动" /></a></li>
							</ul>
							<%}
         else
         {%>
							<ul>
								<li>
									<a href="/Childs/ChildInfo.aspx?userid=<%=this.User.ID %>">
										<img src="images/czll.gif" width="63" height="63" border="0" alt="成长履历" /></a></li>
								<li>
									<a href="Member/Works-Upload.aspx">
										<img src="images/sccy.gif" width="63" height="63" border="0" alt="上传才艺" /></a></li>
								<li>
									<a href="/childs/FamilyMedia-Catagory.aspx?userid=<%=this.User.ID %>">
										<img src="images/qzyx.gif" width="63" height="63" border="0" alt="亲子影像" /></a></li>
								<li>
									<a href="Member/Blog-Write.aspx">
										<img src="images/zxbk.gif" width="63" height="63" border="0" alt="撰写博客" /></a></li>
								<li>
									<a href="#">
										<img src="images/bjzy.gif" width="63" height="63" border="0" alt="班级主页" /></a></li>
								<li>
									<a href="#">
										<img src="images/rchd.gif" width="63" height="63" border="0" alt="日程活动" /></a></li>
							</ul>
							<%} %>
							<div class="clear">
							</div>
						</div>
					</div>
					<div class="douxiucang">
						<div class="duanblock1">
							<div class="kong">
								<a href="#" class="title">斗秀场</a>
								<a href="news/news-list.aspx?id=<%= UtConfig.DouXiuChannelID %>" class="more">&gt;&gt;更多</a>
							</div>
						</div>
						<div class="duanblock2">
							<%--<ul class="zuixin">
							    <li><a href="http://no1child.goodbaby.com/" class="choose">小模特：2009上海市学生艺术单项比赛--少儿模特大赛</a></li>
							    <li><a href="http://www.no1child.com/disneybj/" class="choose">迪士尼北京 ：我爱北京百万家庭大家一起赛</a></li>
							    <li><a href="http://www2.no1child.com/3m/" class="choose">3M ：小手牵大手 思高好帮手 2010思高杯创意绘画大赛</a></li>
							    <li><a href="http://no1child.babytree.com/promo/paint2010/" class="choose">奇异果: 2010年幼儿明信片创意绘画活动</a></li>
							</ul>--%>
							<asp:Repeater ID="RepeaterDouXiu" runat="server">
								<HeaderTemplate>
									<ul class="zuixin">
								</HeaderTemplate>
								<ItemTemplate>
									<li>
										<a href="news/news-detail.aspx?id=<%# Eval("ID") %>" class="choose">
											<%# Eval("Title") %></a></li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<div class="douxiucang" style="text-align:right;">
					    <a href="http://www.no1child.com/health/" target="_blank">
					        <img style="width:290px;" src="/_Resources/images/凯思立小banner.jpg" alt="凯思立"  />
					    </a>
					</div>
					
					<div class="douxiucang">
						<div class="duanblock1">
							<div class="kong">
								<a href="#" class="title">优童新闻</a>
								<a href="news/news-list.aspx?id=<%= UtConfig.HuoDongChannelID %>" class="more">&gt;&gt;更多</a>
							</div>
						</div>
						<div class="duanblock2">
						    <%--<ul class="zuixin">
						        <li><a href="http://www2.no1child.com/expo/newave" class="choose">绿光世博活动：百万家庭世博志愿服务行动</a></li>
						        <li><a href="http://www2.no1child.com/parent/content/48" class="choose">美职棒: 2010 MLB PLAY BALL！全国青少年棒球联赛展开角逐</a></li>
						        <li><a href="http://www2.no1child.com/health/" class="choose">凯思丽 : 小骨骼，大梦想，凯思立D助成长</a></li>
						    </ul>--%>
							<asp:Repeater ID="RepeaterHuoDong" runat="server">
								<HeaderTemplate>
									<ul class="zuixin">
								</HeaderTemplate>
								<ItemTemplate>
									<li>
										<a href="news/news-detail.aspx?id=<%# Eval("ID") %>" class="choose">
											<%# Eval("Title") %></a></li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<!--div class="banner">
						<p>品牌活动banner位</p>
					</div-->
					<div class="caiyibang">
						<div class="duanblock1">
							<div class="kong">
								<a href="/childs/index.aspx" class="title">才艺榜</a>
								<div class="tab cyshow">
									<ul class="nav">
										<li>
											<a href="#" class="choose"><span>评分</span></a></li>
										<li>
											<a href="#"><span>人气</span></a></li>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="duanblock2">
							<% i = 0; %>
							<asp:Repeater ID="RepeaterTopWorks" runat="server">
								<HeaderTemplate>
									<div class="caiyi">
								</HeaderTemplate>
								<ItemTemplate>
									<div class="caiyi01">
										<img src="images/icon<%= (++i).ToString("D2") %>.gif" width="21" height="21" border="0" alt="1" class="paixu" />
										<a href="/childs/works-detail.aspx?id=<%# Eval("ID") %>" class="zpmingcheng00">
											<%# Eval("Title") %></a>
										<a href="" class="zzmingcheng00"></a>
										<p class="fenshuzhi">
											4.2分</p>
										<div class="clear">
										</div>
									</div>
								</ItemTemplate>
								<FooterTemplate>
									</div>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<div class="youtongbang">
						<div class="duanblock1">
							<div class="kong">
								<a href="/childs/index.aspx" class="title">优童榜</a>
								<div class="tab cyshow">
									<ul class="nav">
										<li>
											<a href="#" class="choose"><span>人气</span></a></li>
										<li>
											<a href="#"><span>关注度</span></a></li>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="duanblock2">
							<% i = 0; %>
							<div class="caiyi">
								<asp:Repeater ID="RepeaterTopChild" runat="server">
									<ItemTemplate>
										<div class="caiyi01">
											<img src="images/icon<%= (++i).ToString("D2") %>.gif" width="21" height="21" border="0" alt="1" class="paixu" />
											<a href="/childs/home.aspx?userid=<%# Eval("ParentID") %>" class="zpmingcheng00">
												<%# Eval("Name") %></a>
											<a href="#" class="zzmingcheng01">作品数 <span>131</span></a>
											<p class="fenshuzhi">
												<span>人气</span>99999</p>
											<div class="clear">
											</div>
										</div>
									</ItemTemplate>
								</asp:Repeater>
							</div>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<%--<div class="ertongyule">
						<div class="duanblock1">
							<div class="kong">
								<a href="javascript:void(0)" class="title">儿童娱乐</a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="duanblock2">
							<ul class="yulepian">
								<li>
									<a href="http://www2.no1child.com/inter/play/49346073">
										<img src="http://i01.img.tudou.com/data/imgs/i/049/346/073/p.jpg" width="80" height="50" border="0" alt="火影忍者" /><span>火影忍者</span></a></li>
								<li>
									<a href="http://www2.no1child.com/inter/play/44011033">
										<img src="http://i01.img.tudou.com/data/imgs/i/044/011/033/m10.jpg" width="80" height="50" border="0" alt="海底总动员" /><span>海底总动员</span></a></li>
								<li>
									<a href="http://www2.no1child.com/inter/play/47921604">
										<img src="http://i01.img.tudou.com/data/imgs/i/047/921/604/p.jpg" width="80" height="50" border="0" alt="天书奇谭" /><span>天书奇谭</span></a></li>
							</ul>
							<div class="clear">
							</div>
						</div>
						<div class="duanblock3">
						</div>
					</div>--%>
					<div class="youtongquanzi">
						<div class="duanblock1">
							<div class="kong">
								<a href="#" class="title">最新博客</a>
								<a href="news/news-list.aspx?id=<%= UtConfig.BlogChannelID %>" class="more">&gt;&gt;更多</a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="duanblock2">
							<asp:Repeater ID="rp_Blogs" runat="server">
								<HeaderTemplate>
									<ul class="zuixin">
								</HeaderTemplate>
								<ItemTemplate>
									<li>
											<a href="/Blogs/Detail.aspx?id=<%#Eval("ID") %>" class="choose">
												<%# Eval("Title") %></a></li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<%--<div class="youtongquanzi">
						<div class="duanblock1">
							<div class="kong">
								<a href="#" class="title">热门圈子</a>
								<a href="#" class="more">&gt;&gt;更多</a>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="duanblock2">
							<div class="caiyi">
								<div class="caiyi01">
									<img src="images/icon01.gif" width="21" height="21" border="0" alt="1" class="quanzipaixu" />
									<a href="#" class="quanziimg">
										<img src="images/quanzi_img01.gif" width="32" height="32" border="0" alt="圈子" /></a>
									<a href="#" class="quanzi01">圈子名称</a>
									<a href="#" class="chengyuan shaodian">成员<span>99</span></a>
									<p class="fenshuzhi jianshao">
										<span>人气</span>99999</p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01">
									<img src="images/icon02.gif" width="21" height="21" border="0" alt="1" class="quanzipaixu" />
									<a href="#" class="quanziimg">
										<img src="images/quanzi_img01.gif" width="32" height="32" border="0" alt="圈子" /></a>
									<a href="#" class="quanzi01">圈子名称</a>
									<a href="#" class="chengyuan shaodian">成员<span>99</span></a>
									<p class="fenshuzhi jianshao">
										<span>人气</span>99999</p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01">
									<img src="images/icon03.gif" width="21" height="21" border="0" alt="1" class="quanzipaixu" />
									<a href="#" class="quanziimg">
										<img src="images/quanzi_img01.gif" width="32" height="32" border="0" alt="圈子" /></a>
									<a href="#" class="quanzi01">圈子名称</a>
									<a href="#" class="chengyuan shaodian">成员<span>99</span></a>
									<p class="fenshuzhi jianshao">
										<span>人气</span>99999</p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01">
									<img src="images/icon04.gif" width="21" height="21" border="0" alt="1" class="quanzipaixu" />
									<a href="#" class="quanziimg">
										<img src="images/quanzi_img01.gif" width="32" height="32" border="0" alt="圈子" /></a>
									<a href="#" class="quanzi01">圈子名称</a>
									<a href="#" class="chengyuan shaodian">成员<span>99</span></a>
									<p class="fenshuzhi jianshao">
										<span>人气</span>99999</p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01">
									<img src="images/icon05.gif" width="21" height="21" border="0" alt="1" class="quanzipaixu" />
									<a href="#" class="quanziimg">
										<img src="images/quanzi_img01.gif" width="32" height="32" border="0" alt="圈子" /></a>
									<a href="#" class="quanzi01">圈子名称</a>
									<a href="#" class="chengyuan shaodian">成员<span>99</span></a>
									<p class="fenshuzhi jianshao">
										<span>人气</span>99999</p>
									<div class="clear">
									</div>
								</div>
							</div>
						</div>
						<div class="duanblock3">
						</div>
					</div>
					<div class="youtongbang">
						<div class="duanblock1">
							<div class="kong">
								<a class="title" href="javascript:void(0)">班级主页</a>
								<div class="tab bjzhuye" id="dv_schooltype">
									<ul id="tables" class="nav mytab">
										<li>
											<a id="1" class="choose" href="javascript:void(0)" onclick="showTabforYT(1,2,this)"><span>幼儿园</span></a></li>
										<li>
											<a id="2" href="javascript:void(0)" onclick="showTabforYT(2,2,this)"><span>小学</span></a></li>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div id="xuexiaotab1" style="display: block;" class="duanblock2 mytab">
							<div class="caiyi">
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon01.gif">
									<a class="moubanji" href="javascript:void(0)">第四幼儿园2009届2班</a>
									<a class="chengyuan" href="javascript:void(0)">成员588</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon02.gif">
									<a class="moubanji" href="javascript:void(0)">第四幼儿园2009届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员500</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon03.gif">
									<a class="moubanji" href="javascript:void(0)">鹤庆幼儿园2009届2班</a>
									<a class="chengyuan" href="javascript:void(0)">成员394</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon04.gif">
									<a class="moubanji" href="javascript:void(0)">鹤庆幼儿园2009届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员336</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon05.gif">
									<a class="moubanji" href="javascript:void(0)">满天星幼儿园2009届2班</a>
									<a class="chengyuan" href="javascript:void(0)">成员221</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
							</div>
						</div>
						<div id="xuexiaotab2" style="display: none;" class="duanblock2 mytab">
							<div class="caiyi">
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon01.gif">
									<a class="moubanji" href="javascript:void(0)">鹤庆幼儿园1996届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员56</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon02.gif">
									<a class="moubanji" href="javascript:void(0)">月浦新村第三小学1996届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员54</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon03.gif">
									<a class="moubanji" href="javascript:void(0)">颛桥镇中心幼儿园1996届11班</a>
									<a class="chengyuan" href="javascript:void(0)">成员49</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon04.gif">
									<a class="moubanji" href="javascript:void(0)">东新幼儿园1996届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员47</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
								<div class="caiyi01 banjizhuye">
									<img width="21" height="21" border="0" class="paixu" alt="1" src="/images/icon05.gif">
									<a class="moubanji" href="javascript:void(0)">望族苑幼稚园1996届1班</a>
									<a class="chengyuan" href="javascript:void(0)">成员45</a>
									<p class="renqi">
										人气<span>0</span></p>
									<div class="clear">
									</div>
								</div>
							</div>
						</div>
						<div class="duanblock3">
						</div>
					</div>
				</div>--%>
			</div>
			<div class="clear">
			</div>
			<div class="hzlogo" style="display: none;">
				<div class="zhengfu">
					<p>
						政府合作机构</p>
					<ul>
						<li>
							<a href="#">
								<img src="images/zflogo01.gif" width="56" height="56" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/zflogo02.gif" width="56" height="56" border="0" alt="" /></a></li>
					</ul>
					<div class="clear">
					</div>
				</div>
				<div class="hezuo">
					<p>
						品牌战略合作伙伴</p>
					<ul>
						<li>
							<a href="#">
								<img src="images/hzlogo01.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo02.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo03.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo04.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo05.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo06.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo07.gif" width="64" height="54" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo08.gif" width="64" height="52" border="0" alt="" /></a></li>
						<li>
							<a href="#">
								<img src="images/hzlogo09.gif" width="89" height="52" border="0" alt="" /></a></li>
					</ul>
					<div class="clear">
					</div>
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
