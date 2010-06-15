<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="YouTong.WebSite.Blogs.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>优童首页|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/register.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../_Resources/ckeditor/ckeditor_basic.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
		//删除相册
        function DeltetBlogs(userid,id){
            if(confirm("是否删除博客")){
                jQuery.ajax({
                    url : "/_Handlers/Blog.ashx?action=delete&userid=" + userid + "&Id=" + id,
                    async : false,
                    success : function(){
                        window.location.reload();
                    },
                    fail : function(){
                        alert("删除博客出错!");
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
			<div class="register">
				<div class="information_right" style="padding:0px 0px 0px 20px;width:100%;">
					<div class="xxtitle">
						当前位置：<a href="/">优童首页</a>&gt;&gt;
						<a href="/Grow/Grow.aspx">管理中心</a>&gt;&gt;
						<a href="Blog-List.aspx" class="choose">博客列表</a>
					</div>
					<div class="gerenxin" style="width:100%;background:#549DBF none repeat-y scroll 0 0;">
						<ul>
							<li>
								<a href="#" class="choose"><span class="choose">我的博文</span></a></li>
								<%if (!IsAnonymous && User.ID == UserID)
          {%>
							<li>
								<a href="Blog-Write.aspx" target="_blank" class="choose"><span class="choose">发表博文</span></a></li><%} %>
						</ul>
					</div>
					<table cellpadding="0" cellspacing="0" width="100%" border="0" class="zhanneixin" style="width:100%;">
						<thead>
						<%if (!IsAnonymous && User.ID == UserID)
        {%>
							<td>
								&nbsp&nbsp操作
							</td><%} %>
							<td>
								标题
							</td>
							<td>
								时间
							</td>
						</thead>
						<tr style="height: 5px;">
							<td colspan="4" style="padding: 1px 0;">
							</td>
						</tr>
						<asp:Repeater ID="rp_Blogs" runat="server">
							<ItemTemplate>
								<tr class="color">
								<%if (!IsAnonymous && User.ID == UserID)
          {%>
									<td>
										&nbsp&nbsp<a href="Blog-Update.aspx?id=<%# Eval("ID") %>" target="_blank">[修改]</a>
										&nbsp&nbsp<a href="javascript:void(0);" onclick="DeltetBlogs('<%=UserID %>','<%# Eval("ID") %>');">[删除]</a>
									</td><%} %>
									<td>
										<a target="_blank" href="Detail.aspx?id=<%# Eval("ID") %>"><%# Eval("Title") %></a>
									</td>
									<td>
										<%# Eval("AddTime") %>
									</td>
								</tr>
							</ItemTemplate>
						</asp:Repeater>
					</table>
					<div class="fenye">
                        <asp:Literal ID="lt_Page" runat="server"></asp:Literal>
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
