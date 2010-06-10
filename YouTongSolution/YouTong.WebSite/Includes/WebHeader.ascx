<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebHeader.ascx.cs" Inherits="YouTong.WebSite.Includes.WebHeader" %>
<div class="header">
	<div class="head">
		<div class="logo">
			<a href="http://www.no1child.com" title="优童网 越秀越优秀，中国儿童优秀展示平台">
				<img src="/images/logo.gif" border="0" alt="优童网 越秀越优秀，中国儿童优秀展示平台" /></a>
		</div>
		<div class="text">
			<% if (this.IsAnonymous) %>
			<% { %><p>
				<a href="/Member/Login.aspx">[请登录]</a></p>
			<% } %>
			<% else %>
			<% { %><p>
				优童网欢迎您：<b><%= this.User.UserName %></b></p>
			<a href="/grow/grow.aspx">[用户管理中心]</a><a href="/Member/SignOut.aspx">[退出]</a>
			<% } %></div>
		<div class="clear">
		</div>
	</div>
	<div class="menu">
		<ul class="navgation">
			<li id="default">
				<a href="/" title="首页" class="choose"><span>首页</span></span></a></li>
			<li id="child">
				<a href="/Grow/Grow.aspx" title="我的优童"><span>我的优童</span></a></li><%--<a href="/Member/MyChild.aspx" title="我的优童"><span>我的优童</span></a></li>--%>
			<li id="show">
				<a href="/childs/" title="优童秀"><span>优童秀</span></a></li>
			<%--<li id="video"><a href="/Videos/" title="优童影像"><span>优童影像</span></a></li>--%>
			<%--			<li id="exp">
				<a href="#" title="优童经"><span>优童经</span></a></li>
			<li id="print">
				<a href="#" title="优童印品"><span>优童印品</span></a></li>
			<li id="shop">
				<a href="#" title="优童小铺"><span>优童小铺</span></a></li>--%>
			<li id="Li1">
				<a href="../Jianshezhong.aspx" title="优童圈"><span>优童圈</span></a></li>
		    <li id="Li2">
				<a href="http://www2.no1child.com/bbs/index.aspx" title="优童经"><span>优童经</span></a></li>
			<li id="Li3">
				<a href="../Jianshezhong.aspx" title="优童in品"><span>优童in品</span></a></li>
			<li id="Li4">
				<a href="../Jianshezhong.aspx" title="优童小铺"><span>优童小铺</span></a></li>				
				
		</ul>
		<div class="seach">
			<input type="text" class="input01" name="search_text" id="discover_text" value="从你感兴趣的东西开始" title="从你感兴趣的东西开始">
			<select class="select01">
				<option selected="" value="">请选择</option>
				<option selected="" value="">作品名称</option>
				<option selected="" value="">作者</option>
				<option selected="" value="">学校</option>
			</select>
			<%--<input type="submit" class="button01" value="搜索">--%>
		</div>
	</div>
</div>
<script type="text/javascript">

	$(".navgation li a").removeClass("choose");
	if (CMenu) {
		$("#" + CMenu + " a").addClass("choose");
	}

</script>
