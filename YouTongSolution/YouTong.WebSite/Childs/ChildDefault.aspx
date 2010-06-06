<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChildDefault.aspx.cs" Inherits="YouTong.WebSite.Childs.ChildDefault" %>

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
	<script src="../js/common.js" type="text/javascript"></script>
	<script type="text/javascript">
		var CMenu = "child";
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
        	<div class="main">
                <div class="leftmeta">
				     <div id="rukou">
                       <dl><img src="/images/top_055.gif"></dl>
                       <div id="jiakuan">
                          <div class="pesonal">
						  	<div class="yidenglv">
								<a href="#" class="rentx"><img src="<%= DataCache.GetHeadPicture(Child.HeadPicture) %>" width="59" height="59" border="0" align="" /></a>
								<a href="#"><img src="/images/guanzhubtn.gif" width="95" height="32" border="0" alt="我要关注" /></a>
							</div>
							
						  	<div class="gerendangan">
									<div class="xingming">
										<h3>
											<%= Child.Name %></h3>
										<div class="clear">
										</div>
									</div>
									<p>
										年龄：<span><%= Child.Age %>岁</span></p>
									<p>
										学校：<span><%= DataCache.GetSchoolNameByUserID(Child.ParentID.Value) %></span></p>
									<p>
										人气：<span class="hongse">131</span></p>
									<p>
										关注：<span class="hongse">131</span></p>
									<p>
										寄语：<span class="hongse">5</span></p>
								</div>
							<div class="clear"></div>
						  </div> 
						  <%--<div class="guanxi">
						  	<h3>您和TA的关系是：</h3>
							<div><p>我是<a href="#"> 李晓莉 </a>的</p>
							<select class="select02" onchange="#">
								<option value="" selected="">叔叔</option>
								<option value="" selected="">阿姨</option>
								<option value="" selected="">老娘舅</option>
								<option value="" selected="">老师</option>
							</select>
							<input type="submit" value="" class="queding">
							</div>
						  </div>--%>
                       </div>
                       <dl><img src="/images/di_27.gif"></dl>
                    </div>	
					
					 <%--<div class="douxiucang">
                   		 <div class="zhuanjiablock1">
                             	<div class="kong">
                                    <a href="#" class="title">最近访客</a>
                                    <a href="#" class="more">>>更多</a>
                                </div>
                          </div>
                             
                         <div class="zhuanjiablock2">
						 	<div class="zuopin">
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a href="#" title=" " class="fangkebg"><img src="./images/zuozhe_renwu.gif" width="59" height="59" border="0" alt="" /></a>
										<a href="#" title=" " class="fangkewenzi" ><img src="./images/icon.gif" width="15" height="18" border="0" />欧阳慕容</a>
									</div>
								</div>
								<div class="clear"></div>
						 </div>
                             
                         <div class="zhuanjiablock3">
                         </div>
                    </div>--%>
					
					<%--<div class="douxiucang">
                   		 <div class="zhuanjiablock1">
                             	<div class="kong">
                                    <a class="title" href="#">优童家庭成员</a>
                                    <a class="more" href="#">&gt;&gt;更多</a>
                                </div>
                          </div>
                             
                         <div class="zhuanjiablock2">
								<div class="zuopin chengyuanji">
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="listleft fangke">
										<a class="fangkebg" title=" " href="#"><img width="59" height="59" border="0" alt="" src="./images/zuozhe_renwu.gif"></a>
										<a class="fangkewenzi" title=" " href="#"><img width="15" height="18" border="0" src="./images/icon.gif">欧阳慕容</a>
									</div>
									<div class="clear"></div>
									<div class="xuxian"></div>
									<div class="jiarujiating">
										<a title="加入家庭" class="savebtn" href="#"><span>加入家庭</span></a>
									</div>
									<div class="clear"></div>
								</div>
						  </div>
                             
                         <div class="zhuanjiablock3">
                         </div>
                    </div>--%>
					 
                	 
                </div>
                <div class="rightmeta">
					<div class="zuopinlibiao">
                        <div class="block1">
                           <a class="title" href="#">作品列表</a>
                           <div class="tab">
                           		<a class="zuosanjiao" href="#"></a>
                                <div style="width: 328px; overflow: hidden; float: left; height: 27px; padding: 0px; margin: 0px; position: relative;">
									<div class="move" style="width: 800%; float: left; position: relative; left: 0px">
										<ul class="nav">
											<% foreach (var channel in WorksCategories) %>
											<% { %>
											<li>
												<a href="javascript:void(0);" onclick="GetWords(this, '<%=UserID%>','<%=channel.ID%>');"><span>
													<%= channel.Name %></span></a></li>
											<% } %>
										</ul>
									</div>
								</div>
                                <a class="yousanjiao" href="#"></a>
                           </div>
                           <div class="clear"></div>
                        </div>
                        <div class="block2">
                        	<div class="waibu">
                        	    <asp:Repeater ID="rp_works" runat="server">
                        	        <HeaderTemplate>
                        	        <div class="fenline">    
                                    </HeaderTemplate>
                        	        <ItemTemplate>
                        	        
                                        <div class="zuopin">
                        	            <div class="listleft">
											<a class="zuopinbg" title=" " href="Works-Detail.aspx?ID=<%# Eval("ID") %>">
													<img width="100" height="75" border="0" alt="" src="<%# Eval("ThumbnailUrl") %>"></a>
										</div>
                                        <div class="zpxinxi">
                                            <a class="zpmclan" title=" " href="#">
													<%# Eval("Title") %></a>
												<p class="renqisc0">
													<span>人气：<em>131</em></span></p>
												<p class="renqisc0">
													<span>评分：<em>3</em></span></p>
												<p class="renqisc0">
													<span>收藏：<em>13</em></span></p>
										</div>
										</div>
									</ItemTemplate>
                        	        <FooterTemplate></div></FooterTemplate>
                        	    </asp:Repeater>                            	
                               </div>
							   <div class="clear">
							</div>
							<div class="more">
								<a href="Works.aspx?userid=<%=UserID %>">更多>></a></div>
                        </div>
                        <div class="block3">
                        </div>
                      </div>
					
					<div class="caiyixiu">
                        <div class="block1">
						   <a href="#" class="title">寄语</a>
						   <div class="clear"></div>
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
								<h3><a name="one">我要评论</a></h3>
								<textarea class="newscomment" name="new_Title" id="" rows="4" cols="70"></textarea>
								<div class="tijiaobtn">
									<a href="#"><asp:ImageButton ID="imgComment" runat="server" 
                                        src="/images/tijiao_btn.gif" width="61" height="21" alt="提交" border="0" 
                                        onclick="imgComment_Click" /></a>
								</div>
								<div class="clear"></div>
							</div>
							<div class="kongzhiheight"></div>
							
						</div>
                        <div class="block3">
                        </div>
                      </div>
				  </div>
				<div class="clear"></div>
             </div>
        </div>
        <ut:WebFooter ID="WebFooter" runat="server" />
    </div>
    </form>
</body>
</html>
