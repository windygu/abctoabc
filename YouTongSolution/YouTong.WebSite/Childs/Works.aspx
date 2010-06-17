<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Works.aspx.cs" Inherits="YouTong.WebSite.Childs.Works" %>

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
	<script type="text/javascript">
		var CMenu = "show";

		function switchTab(type,cat) {
			location = "Works.aspx?userid=<%=UserID%>&type=" + type+"&cat="+cat;
		}
		//删除相册
        function DeltetWorks(userid,id){
            if(confirm("是否删除作品")){
                jQuery.ajax({
                    url : "/_Handlers/Media_Works.ashx?userid=" + userid + "&id=" + id,
                    async : false,
                    success : function(){
                        window.location.reload();
                    },
                    fail : function(){
                        alert("删除作品出错!");
                    }
                });
            }
        }
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
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">优童作品列表</a>
					<div class="nianfen">
						<h2>
							<%= this.Category==null ? "": this.Category.Name %></h2>
						<%if (!IsAnonymous && User.ID == UserID)
       {%><h3><a href="/Member/Works-Upload.aspx" target="_blank">上传照片/视频</a></h3><%} %>
					</div>
					<div class="tab tab00">
						<ul class="nav">
							<li><a class='<%=(WorksType==1?"choose":"")%>' href="javascript:switchTab(1,'<%=CategoryID %>')"><span>照片</span></a></li>
							<li><a class='<%=(WorksType==2?"choose":"")%>' href="javascript:switchTab(2,'<%=CategoryID %>')"><span>视频</span></a></li>
						</ul>
					</div>
					<div class="clear">
					</div>
				</div>
				<div class="longblock02">
					<asp:Repeater ID="RepeaterWorks" runat="server">
						<HeaderTemplate>
							<div class="longblock02">
								<div class="haveline">
						</HeaderTemplate>
						<ItemTemplate>
							<% i++; %>
							<% if (i != 1 && i % 3 == 1) %>
							<% { %><div class="clear">
							</div>
							</div>
							<div class="longblock02">
								<div class="haveline">
									<% } %>
									<div class="zuopin">
										<div class="listleft">
											<a href="Works-Detail.aspx?id=<%# Eval("ID") %>" class="zuopinbg">
												<img width="100" height="75" border="0" src="<%# Eval("ThumbnailUrl") %>" alt=""></a>
										</div>
										<div class="zpxinxi">
											<a href='Works-Detail.aspx?id=<%# Eval("ID") %>' class="zpmclan">
												<%# Eval("Title") %></a>
												<%if (!IsAnonymous && User.ID == UserID){%>
											<a href="/Member/Works-Update.aspx?id=<%#Eval("ID") %>&type=<%=WorksType %>&cat=<%=CategoryID %>" target="_blank" style="display:inline;">[编辑]</a>
											<a href="javascript:void(0);" onclick="DeltetWorks('<%=UserID %>','<%# Eval("ID") %>');" style="display:inline;">[删除]</a><%} %>
										</div>
										<div class="clear">
										</div>
									</div>
						</ItemTemplate>
						<FooterTemplate>
							<div class="clear">
							</div>
							</div>
						</FooterTemplate>
					</asp:Repeater>
					<div class="fenye">
                        <asp:Literal ID="lt_Page" runat="server"></asp:Literal>
					</div>
					<div class="clear">
					</div>
				</div>
				<div class="longblock03">
				</div>
			</div>
		</div>
		<ut:WebFooter ID="WebFooter" runat="server" />
	</div>
	</form>
</body>
</html>
