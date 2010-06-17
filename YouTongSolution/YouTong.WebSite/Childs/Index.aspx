<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="YouTong.WebSite.Childs.Index" %>

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
	<script src="../Datas/AreaJson.aspx" type="text/javascript"></script>
	<script src="../js/common.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "show";

		$(function() {
			regCatMove()
		});
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="maincy">
				<div class="leftcyx">
					<div class="tuijian">
						<div class="blockcy1">
							<a href="#" class="title">今日推荐作品</a>
							<%--							<div class="hotmain">
								<p>
									热门才艺：<a href="#">绘画</a><a href="#">少儿英语</a></p>
								<p>
									热门标签：<a href="#">世博会</a><a href="#">书法比赛</a><a href="#">舞林大会</a></p>
								<p>
									热门学校：<a href="#">大拇指幼儿园</a><a href="#">徐飞鸿幼儿园</a></p>
							</div>--%>
							<div class="clear">
							</div>
							<%--							<div class="tab nogaodu">
								<a href="#" class="zuosanjiao"></a>
								<ul class="nav">
									<% foreach (var channel in WorksCategories) %>
									<% { %>
									<li>
										<a href="#" class="choose"><span>
											<%= channel.Name %></span></a></li>
									<% } %>
								</ul>
								<a href="#" class="yousanjiao"></a>
							</div>--%>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy2">
							<div class="zuopinji">
								<ul>
									<% i = 0; %>
									<asp:Repeater ID="RepeaterTjWorks" runat="server">
										<ItemTemplate>
											<li>
												<a href="works-detail.aspx?id=<%# Eval("ID") %>" title=" " class="zuopinjibg">
													<img src="<%# Eval("ThumbnailUrl") %>" width="80" height="60" border="0" alt="" /></a>
												<a href="works-detail.aspx?id=<%# Eval("ID") %>" class="tuijianmc"><em>
													<%= ++i %>.</em><span><%# Eval("Title") %></span></a>
												<div class="xingji">
													<a>
														<img src="../images/huang_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/huang_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
												</div>
												<div class="clear">
												</div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>
					<div class="allzuopin">
						<div class="blockcy1">
							<a href="#" class="title">所有作品分类</a>
							<div class="jiansuo" style="padding:10px 0 0 0;">
								<select id="City" name="City" class="xuanze">
					            </select>
					            <select id="Region" name="Region" class="xuanze">
					            </select>
					            <select id="Level" class="xuanze" name="Level">
						            <option value="0">学校类型</option>
						            <option value="1">幼儿园</option>
						            <option value="2">小学</option>
					            </select>
					            <select id="SchoolID" name="SchoolID" class="xuanze">
					            </select>
					            <input type="button" value="搜索" class="button001" style="width:30px;height:22px;" onclick="SearchChild();" />
							</div>
							<div class="tab wujuli">
								<a style="cursor: pointer" id="left" class="zuosanjiao"></a>
								<div style="width: 328px; overflow: hidden; float: left; height: 27px; padding: 0px; margin: 0px; position: relative;">
									<div class="move" style="width: 800%; float: left; position: relative; left: 0px">
										<ul class="nav">
											<% foreach (var channel in WorksCategories) %>
											<% { %>
											<li>
												<a href="works.aspx?cat=<%= channel.ID %>"><span>
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
						<div class="blockcy2">
							<div class="zuopinji">
								<ul class="leibie">
									<asp:Repeater ID="RepeaterWorks" runat="server">
										<ItemTemplate>
											<li style="height: 150px">
												<a class="zuopinbg" href="works-detail.aspx?id=<%# Eval("ID") %>">
													<img width="100" height="75" border="0" alt="" src="<%# Eval("ThumbnailUrl") %>"></a>
												<a href="works-detail.aspx?id=<%# Eval("ID") %>" class="fenleizp">
													<div style="text-align: center">
														<%# Itfort.Utils.CutRight((String)Eval("Title"), 16) %>
														<br />
														<em>(131)浏览</em></div>
												</a>
												<div class="xingji">
													<a>
														<img src="../images/huang_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/huang_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
													<a>
														<img src="../images/gray_star.jpg" width="16" height="16" border="0" alt="" /></a>
												</div>
												<div class="clear">
												</div>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
								<div class="clear">
								</div>
								<div class="fenye">
									<a href="Works.aspx">更多</a>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>
					<%--<div class="allzuopin">
						<div class="blockcy1">
							<a class="title" href="#">最新点评</a>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy2">
							<div class="wenzixinxi">
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>--%>
					<div class="tuijianyt">
						<div class="blockcy1">
							<a href="#" class="title">今日推荐优童</a>
							<%--<div class="tab">
								<a href="#" class="zuosanjiao"></a>
								<ul class="nav">
									<li>
										<a href="#" class="choose"><span>美术绘画</span></a></li>
									<li>
										<a href="#"><span>器乐演奏</span></a></li>
									<li>
										<a href="#"><span>歌曲演唱</span></a></li>
									<li>
										<a href="#"><span>舞蹈表演</span></a></li>
									<li>
										<a href="#"><span>摄影摄像</span></a></li>
								</ul>
								<a href="#" class="yousanjiao"></a>
							</div>--%>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy2">
							<div class="zuopinji">
								<ul>
									<% i = 0; %>
									<asp:Repeater ID="RepeaterTjChild" runat="server">
										<ItemTemplate>
											<li>
												<a href="/childs/home.aspx?userid=<%# Eval("ParentID") %>" title=" " class="zuopinjibg">
													<img src="<%# DataCache.GetHeadPicture((String)Eval("HeadPicture")) %>" width="80" height="60" border="0" alt="" /></a>
												<a href="/childs/home.aspx?userid=<%# Eval("ParentID") %>" class="tuijianmc"><em>
													<%= ++i %>.</em><span><%# Eval("Name") %></span></a>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>
					<div class="allzuopin">
						<div class="blockcy1">
							<a href="#" class="title">所有亲子影像</a>
							<%--	<div class="jiansuo">
								快速检索
								<select class="xuanze" name="select">
									<option>所有兴趣</option>
									<option>所有兴趣</option>
									<option>所有兴趣</option>
								</select>
								<select class="xuanze" name="select">
									<option>所有年龄</option>
									<option>所有年龄</option>
									<option>所有年龄</option>
								</select>
								<select class="xuanze" name="select">
									<option>所有学校地区</option>
									<option>所有学校地区</option>
									<option>所有学校地区</option>
								</select>
								<input type="submit" value="搜索" class="button01">
							</div>--%>
							<div class="tab wujuli">
								<a style="cursor: pointer" id="A1" class="zuosanjiao"></a>
								<div style="width: 328px; overflow: hidden; float: left; height: 27px; padding: 0px; margin: 0px; position: relative;">
									<div class="move" style="width: 800%; float: left; position: relative; left: 0px">
										<ul class="nav">
											<% foreach (var channel in MediaCategories) %>
											<% { %>
											<li>
												<a href="familymedia.aspx?cat=<%= channel.ID %>"><span>
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
						<div class="blockcy2">
							<div class="zuopinji">
								<ul class="leibie">
									<asp:Repeater ID="RepeaterMedia" runat="server">
										<ItemTemplate>
											<li>
												<a class="zuopinbg" title=" " href="familymedia-detail.aspx?id=<%# Eval("ID") %>">
													<img width="100" height="75" border="0" alt="" src="<%# Eval("ThumbnailUrl") %>"></a>
												<a href="familymedia-detail.aspx?id=<%# Eval("ID") %>" class="fenleizp"><span>
													<%# Eval("Title") %></span> <em>(131)关注</em></a>
											</li>
										</ItemTemplate>
									</asp:Repeater>
								</ul>
								<div class="clear">
								</div>
								<div class="fenye">
									<a href="familymedia.aspx">更多</a>
									<%--<a href="#" title="[1]" class="choose">[1]</a><a href="#" title="[2]">[2]</a><a href="#" title="[3]">[3]</a><a href="#" title="[4]">[4]</a><a href="#" title="[5]">[5]</a><a href="#" title="[6]">[6]</a><a href="#" title="[7]">[7]</a><a href="#" title="[8]">[8]</a><a href="#" title="[9]">[9]</a>
								--%></div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>
					<%--<div class="allzuopin">
						<div class="blockcy1">
							<a href="#" class="title">最新寄语</a>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy2">
							<div class="wenzixinxi">
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
								<div class="buchongtext">
									<p>
										<span class="people">[2010-02-25 22:55:11]</span> <span>123楼</span><span><em>某某某</em>说：</span>
									</p>
									<p class="jieshaowenzi">
										春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
								</div>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="blockcy3">
						</div>
					</div>--%>
				</div>
				<div class="rightcyx">
					<div class="cydouxiuchang">
						<div class="pinkblock1">
							<div class="kong">
								<a class="title" href="#">斗秀场</a>
							</div>
						</div>
						<div class="pinkblock2">
							<div class="tuwen">
								<ol>
									<asp:Repeater ID="RepeaterDouXiu" runat="server">
										<ItemTemplate>
											<li>
												<a href="/news/news-detail.aspx?id=<%# Eval("ID") %>" class="choose">
													<%# Eval("Title") %></a></li>
										</ItemTemplate>
									</asp:Repeater>
								</ol>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="pinkblock3">
						</div>
					</div>
					
					
					
					
					<div class="cycaiyibang">
						<div class="pinkblock01">
							<div class="kong">
								<a class="title" href="#">作品榜</a>
								<div class="tab cyshow">
									<ul class="nav">
										<li>
											<a href="#" class="choose"><span>评分</span></a></li>
										<li>
											<a href="#"><span>人气</span></a></li>
										<li>
											<a href="#"><span>评论</span></a></li>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="pinkblock2">
							<div class="tuwen">
								<% i = 0; %>
								<asp:Repeater ID="RepeaterTopWorks" runat="server">
									<ItemTemplate>
										<div class="caiyi01 wutu">
											<img src="../images/icon<%= (++i).ToString("D2") %>.gif" width="21" height="21" border="0" alt="1" class="paixu" />
											<a href="works-detail.aspx?id=<%# Eval("ID") %>" class="mingc">
												<%# Eval("Title") %></a>
											<div class="xingji cyxj">
												<a>
													<img width="16" height="16" border="0" alt="" src="../images/huang_star.jpg"></a>
												<a>
													<img width="16" height="16" border="0" alt="" src="../images/huang_star.jpg"></a>
												<a>
													<img width="16" height="16" border="0" alt="" src="../images/gray_star.jpg"></a>
												<a>
													<img width="16" height="16" border="0" alt="" src="../images/gray_star.jpg"></a>
												<a>
													<img width="16" height="16" border="0" alt="" src="../images/gray_star.jpg"></a>
												<div class="clear">
												</div>
											</div>
											<div class="clear">
											</div>
										</div>
									</ItemTemplate>
								</asp:Repeater>
							</div>
						</div>
						<div class="pinkblock3">
						</div>
					</div>
					<div class="cyyoutongbang">
						<div class="pinkblock01">
							<div class="kong">
								<a class="title" href="#">优童榜</a>
								<div class="tab cyshow">
									<ul class="nav">
										<li>
											<a href="#" class="choose"><span>人气</span></a></li>
										<li>
											<a href="#"><span>活跃度</span></a></li>
									</ul>
								</div>
								<div class="clear">
								</div>
							</div>
						</div>
						<div class="pinkblock2">
							<div class="tuwen">
								<% i = 0; %>
								<asp:Repeater ID="RepeaterTopChild" runat="server">
									<ItemTemplate>
										<div class="caiyi01 wutu">
											<img src="../images/icon<%= (++i).ToString("D2") %>.gif" width="21" height="21" border="0" alt="1" class="paixu" />
											<a href="/childs/home.aspx?userid=<%# Eval("ParentID") %>" class="mingc">
												<%# Eval("Name") %></a>
											<p class="renqi">
												人气<span></span></p>
											<div class="clear">
											</div>
										</div>
									</ItemTemplate>
								</asp:Repeater>
							</div>
						</div>
						<div class="pinkblock3">
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
<script type="text/javascript">
		var roots = getRootAreas();
		var len = roots.length;
		$("<option value='0'>请选择城市</option>").appendTo("#City");
		for (var i = 0; i < len; i++) {
			$("<option value='" + roots[i].ID + "'>" + roots[i].Name + "</option>").appendTo("#City");
		}

		$("#City").change(
			function() {
				var rootId = $(this).val();
				var childs = getChildAreas(rootId);

				$("#Region").empty();

				$("<option value='0'>请选择地区</option>").appendTo("#Region");
				for (var i = 0; i < childs.length; i++) {
					$("<option value='" + childs[i].ID + "'>" + childs[i].Name + "</option>").appendTo("#Region");
				}

				$("#Region").change();
			}
		);

		$("#Region").change(function() { $("#Level").change() });

		$("#Level").change(
			function() {
				var id = $("#Region").val();
				var level = $(this).val();

				$("#SchoolID").empty();
				$("<option value='0'>请选择学校</option>").appendTo("#SchoolID");
				$.getJSON("/_Handlers/GetSchools.ashx", { region: id, level: level },
					function(data) {
						for (var i = 0; i < data.length; i++) {
							$("<option value='" + data[i].ID + "'>" + data[i].Name.replace("&nbsp","") + "</option>").appendTo("#SchoolID");
						}
					}
				 );
			}
		);

		$("#City").change();
		
		function SearchChild(){
		    var citySelect = document.getElementById("City");
			var city = citySelect.options[citySelect.selectedIndex].value;
		    var regionSelect = document.getElementById("Region");
			var region = regionSelect.options[regionSelect.selectedIndex].value;
			var levelSelect = document.getElementById("Level");
			var level = levelSelect.options[levelSelect.selectedIndex].value;
			var schoolSelect = document.getElementById("SchoolID");
			var school = schoolSelect.options[schoolSelect.selectedIndex].value;
			window.open("/childs/Search.aspx?City=" + city + "&Region=" + region + "&Level=" + level + "&SchoolID=" + school);
		}
</script>