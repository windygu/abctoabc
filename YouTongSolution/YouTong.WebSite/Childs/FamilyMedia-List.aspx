<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyMedia-List.aspx.cs" Inherits="YouTong.WebSite.Childs.FamilMedia_List" %>

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
		function switchTab(type) {
			location = "FamilyMedia-List.aspx?userid=<%=UserID%>&id=<%=ID %>&type=" + type;
		}
	</script>
</head>
<body>
    <div id="container">
		<ut:WebHeader ID="WebHeader" runat="server" />
		<div class="content">
			<div class="erjinav">
				当前位置：<a href="/Grow/Grow.aspx">成长档案</a><a>&gt;&gt;</a> <a href="/Childs/FamilyMedia-Catagory.aspx?userid=<%=userB.ID  %>">亲子影像</a><a>&gt;&gt;</a><a href="/Childs/ChildInfo.aspx?userid=<%=userB.ID %>"><%=userB.Name %></a><a>&gt;&gt;</a><a class="choose" href="#"><%=category.Name%></a>
			</div>
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">亲子影像列表</a>
					<div class="nianfen">
					<h2>《<%=category.Name%>》</h2>
					<%if (!IsAnonymous && User.ID == UserID)
       {%><h3><a href="/Member/FamilyMedia-Upload.aspx?id=<%=ID %>" target="_blank">上传照片/视频</a></h3><%} %>
					</div>
					<%--<div class="tab tab00">
						<ul class="nav">
							<li><a class='<%=(MediaType==1?"choose":"")%>' href="javascript:switchTab(1)"><span>照片</span></a></li>
							<li><a class='<%=(MediaType==2?"choose":"")%>' href="javascript:switchTab(2)"><span>视频</span></a></li>
						</ul>
					</div>--%>
					<div class="clear"></div>
				</div>
				<div class="longblock02">
					<div class="haveline">
					    <asp:Repeater ID="rp_AnyFiles" runat="server">
					        <ItemTemplate>
					        <div class="zuopin">
							<div class="listleft">
								<a href="FamilyMedia-Detail.aspx?id=<%#Eval("ID") %>" title=" " class="zuopinbg"><img width="100" height="75" border="0" src="<%#Eval("ThumbnailUrl") %>" alt=""></a>								
							</div>
							<div class="zpxinxi">
								<a href="FamilyMedia-Detail.aspx?id=<%#Eval("ID") %>" title=" " class="zpmclan"><%#Eval("Title")%></a>
								<%if (!IsAnonymous && User.ID == UserID)
          {%>
								<a href="/Member/FamilyMedia-Update.aspx?id=<%#Eval("ID") %>" style="display:inline;">[编辑]</a>
								<a href="javascript:void(0);" onclick="DeleteAnyFile('<%=UserID %>','<%#Eval("ID") %>');" style="display:inline;">[删除]</a><%} %>
								<p class="renqisc0"><span>人气：<em>131</em></span></p> 
								<p class="renqisc0"><span>收藏：<em>13</em></span></p>
								<p class="renqisc0"><span>评论：<em>3</em></span></p>
							</div>
							<div class="clear"></div>
						</div>
					        </ItemTemplate>
					    </asp:Repeater>
						
						<div class="clear"></div>
					 </div>					 
					 <div class="fenye">
						<asp:Literal ID="lt_Page" runat="server"></asp:Literal>
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
