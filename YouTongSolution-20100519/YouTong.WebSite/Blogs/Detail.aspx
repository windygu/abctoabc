<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="YouTong.WebSite.Blogs.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>
		<%= Blog.Title %>|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
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
				当前位置：<a href="/">首页</a><a href="#">博客</a>
			</div>
			<div class="main">
				<div class="leftblock">
					<div class="zuopinzhanshi">
						<div class="block1">
							<a href="#" class="title">博文阅读</a>
							<div class="zhanshiwenzi">
								<div class="chakanbtn">
									<a href="#" title="加入收藏">
										<img src="../images/jiarusc_btn.gif" width="63" height="19" border="0" alt="加入收藏" /></a>
								</div>
							</div>
							<div class="clear">
							</div>
						</div>
						<div class="block2 datuzhanshi">
							<div class="metaxiangxi">
								<h3>
									<%= Blog.Title %></h3>
								<h4>
									<%= Blog.AddTime.ToString("yyyy-MM-dd") %><a href="#">浏览（4）</a>
									<a href="#">收藏（3）</a></h4>
								<%= Blog.Body %>
							</div>
						</div>
						<div class="block3">
						</div>
					</div>
					<div class="caiyixiu">
						<div class="block1">
							<a href="#" class="title">作品评论</a>
							<div class="clear">
							</div>
						</div>
						<div class="block2">
							<div class="dpneirong newpl">
								<div class="plneirong changdu">
									<img width="60" height="60" border="none" src="" class="toux0">
									<div class="textkp zhanshitext">
										<p>
											<span class="people">[2010-02-25 22:55:11]</span><span><em>某某某</em>说：</span>
										</p>
										<p class="jieshaowenzi">
											春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
									</div>
									<div class="clear">
									</div>
								</div>
							</div>
							<div class="dpneirong newpl">
								<div class="plneirong changdu">
									<img width="60" height="60" border="none" src="" class="toux0">
									<div class="textkp zhanshitext">
										<p>
											<span class="people">[2010-02-25 22:55:11]</span><span><em>某某某</em>说：</span>
										</p>
										<p class="jieshaowenzi">
											春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
									</div>
									<div class="clear">
									</div>
								</div>
							</div>
							<div class="dpneirong newpl">
								<div class="plneirong changdu">
									<img width="60" height="60" border="none" src="" class="toux0">
									<div class="textkp zhanshitext">
										<p>
											<span class="people">[2010-02-25 22:55:11]</span><span><em>某某某</em>说：</span>
										</p>
										<p class="jieshaowenzi">
											春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
									</div>
									<div class="clear">
									</div>
								</div>
							</div>
							<div class="dpneirong newpl">
								<div class="plneirong changdu">
									<img width="60" height="60" border="none" src="" class="toux0">
									<div class="textkp zhanshitext">
										<p>
											<span class="people">[2010-02-25 22:55:11]</span><span><em>某某某</em>说：</span>
										</p>
										<p class="jieshaowenzi">
											春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
									</div>
									<div class="clear">
									</div>
								</div>
							</div>
							<div class="dpneirong newpl">
								<div class="plneirong changdu">
									<img width="60" height="60" border="none" src="" class="toux0">
									<div class="textkp zhanshitext">
										<p>
											<span class="people">[2010-02-25 22:55:11]</span><span><em>某某某</em>说：</span>
										</p>
										<p class="jieshaowenzi">
											春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
									</div>
									<div class="clear">
									</div>
								</div>
							</div>
							<div class="fenye">
								<a href="#" title="[1]" class="choose">[1]</a><a href="#" title="[2]">[2]</a><a href="#" title="[3]">[3]</a><a href="#" title="[4]">[4]</a><a href="#" title="[5]">[5]</a><a href="#" title="[6]">[6]</a><a href="#" title="[7]">[7]</a><a href="#" title="[8]">[8]</a><a href="#" title="[9]">[9]</a>
							</div>
							<div class="clear">
							</div>
							<div class="fabiao_pinglun">
								<h3>
									<a name="one">我要评论</a></h3>
								<textarea class="newscomment" name="new_comment" id="" rows="4" cols="70"></textarea>
								<div class="tijiaobtn">
									<a href="#">
										<img src="../images/tijiao_btn.gif" width="61" height="21" alt="提交" border="0" /></a>
								</div>
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
					<div class="redianxinxi">
						<div class="duanblock1">
							<div class="kong">
								<a class="title" href="#">热点信息</a>
								<a href="#" class="more">&gt;&gt;更多</a>
							</div>
						</div>
						<div class="duanblock2">
							<ul class="zuixin">
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
								<li>
									<a href="#">优童最新动态优童最新动态优童优童最新动态</a></li>
							</ul>
						</div>
						<div class="duanblock3">
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
