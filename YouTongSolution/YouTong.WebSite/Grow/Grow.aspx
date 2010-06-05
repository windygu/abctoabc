<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grow.aspx.cs" Inherits="YouTong.WebSite.Childs.Grow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="styles/reset-fonts.css" type="text/css" rel="stylesheet"/>
    <link href="styles/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript" src="scripts/jquery.js"></script>
    <script type="text/javascript">
        $(function(){
	        $(".functionarea>div").mouseover(function(){
		        $(this).find(".displayornot").show();
	        }).mouseout(function(){
		        $(this).find(".displayornot").hide();
	        });	              	
        })
    </script>
	<script type="text/javascript">
		var CMenu = "child";
	</script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="container" class="container">
    <div class="navigation">
        <div class="navcontent">
        	<ul class="">
            	<li class="first"><a href="/" title="首页"><span>首页</span></a></li>
				<li><a class="choose" title="我的优童"><span>我的优童</span></a></li>
                <li><a href="/childs/" title="优童秀"><span>优童秀</span></a></li>
                <li><a href="/Jianshezhong.aspx" title="优童圈"><span>优童圈</span></a></li>
                <li><a href="http://www2.no1child.com/bbs/index.aspx" title="优童经"><span>优童经</span></a></li>
                <li><a href="/Jianshezhong.aspx" title="优童in品"><span>优童in品</span></a></li>
                <li><a href="/Jianshezhong.aspx" title="优童小铺"><span>优童小铺</span></a></li>
			</ul>
        </div>
    </div>
        <div class="functionarea">
        <div class="profile">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="/Member/index.aspx">
                	<table><tr><td>个人信息、履历</td></tr></table>
                </a>
            </div>
        </div>
        <div class="album">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="/childs/FamilyMedia-Catagory.aspx?userid=<%=UserID %>">
                	<table><tr><td>亲子影像</td></tr></table>
                </a>
			</div>
        </div>
        <%--<div class="circle">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="./fetchCircle.aspx">
                	<table><tr><td>我的圈子</td></tr></table>
                </a>
                <div class="popupcontent" style="width: 566px; height: 343px; display: none;background: transparent url(./images/popwindow.gif) no-repeat 0 0;">
                    <div class="closebutton" style="float: right;margin: 4px 4px;"><a href="#"><img src="./images/popwindow_close.gif" /></a></div>
                    ccc
                </div>
			</div>
        </div>--%>
        <div class="blog">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="/Member/Blog-Write.aspx">
                	<table><tr><td>撰写博客</td></tr></table>
                </a>
			</div>
        </div>
        <div class="works">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="/childs/FamilyMedia.aspx?userid=<%=UserID %>">
                	<table><tr><td>作品集</td></tr></table>
                </a>
			</div>
        </div>
        <%--<div class="calendar">
        	<div class="displayornot">
                <div class="transparent"></div>
                <a class="transparentcontent" href="./fetchCalendar.aspx">
                	<table><tr><td>日历</td></tr></table>
                </a>
                <div class="popupcontent" style="width: 566px; height: 343px; display: none;background: transparent url(./images/popwindow.gif) no-repeat 0 0;">
                    <div class="closebutton" style="float: right;margin: 4px 4px;"><a href="#"><img src="./images/popwindow_close.gif" /></a></div>
                    ffff
                </div>
			</div>
        </div>--%>
    </div>
    </div>
    </form>
</body>
</html>
