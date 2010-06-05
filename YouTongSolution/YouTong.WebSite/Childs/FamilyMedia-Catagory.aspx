<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyMedia-Catagory.aspx.cs" Inherits="YouTong.WebSite.Childs.FamilyMedia_Catagory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />	
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="/js/common.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
	</script>
</head>
<body>
    <div id="container">
    <ut:WebHeader ID="WebHeader" runat="server" />
    <div class="content">
			<div class="erjinav">
				当前位置：<a href="#">成长档案</a><a>&gt;&gt;</a> <a href="#">亲子影像</a><a>&gt;&gt;<a class="choose" href="#"><%=userB.Name%></a>
			</div>
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">亲子影像集</a>
					<%if (!IsAnonymous && User.ID == UserID){%>
					<input type="button" value="创建相册" style="margin: 20px 10px 0px;" onclick="AddCategory('<%=UserID %>');"><%} %>
					<div class="clear"></div>
				</div>
				<div class="longblock02">
					<div class="waibuzhengti">
						<div class="haveline00">
						<asp:Repeater ID="rp_Categorys" runat="server">
						    <ItemTemplate>
						    <div class="xiangce_mk">
								<a  href="FamilyMedia-List.aspx?userid=<%=UserID %>&id=<%#Eval("ID") %>" class="tuxiangkuang"><img src="/images/ertong03.gif" width="100" height="75" border="0" /></a>
								<div class="xcxinxi00">
									<a href="FamilyMedia.aspx?userid=<%=UserID %>&id=<%#Eval("ID") %>" class="lansewenzi"><%#Eval("Name") %></a>
									<%if (!IsAnonymous && User.ID == UserID)
            {%>										
										<span><a href="javascript:void(0);" onclick="UpdateCategory('<%=UserID %>','<%#Eval("ID") %>','<%#Eval("Name") %>');">[编辑]</a></span><span><a href="javascript:DeltetCategory('<%=UserID %>','<%#Eval("ID") %>');">[删除]</a></span>
										<%} %>
									<%--<h3><span>5个照片</span><span>10个视频</span></h3>--%>
									<p>创建于：<em><%#Convert.ToDateTime(Eval("AddTime")).ToString("yyyy/MM/dd")%></em></p>
								    <p>更新于：<em><%#Convert.ToDateTime(Eval("UpdateTime")).ToString("yyyy/MM/dd")%></em></p>
								</div>
								<div class="clear"></div>	
							</div>
						    </ItemTemplate>
						</asp:Repeater>														
							<div class="clear"></div>
						</div>
					</div>					
					<div class="clear"></div>
				</div>
				<div class="longblock03"></div>
				
			</div>
        </div>
    <ut:WebFooter ID="WebFooter" runat="server" />
    </div>
</body>
</html>
