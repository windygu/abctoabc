<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentDefault.aspx.cs" Inherits="YouTong.WebSite.Childs.ParentDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="container">
        <ut:WebHeader ID="WebHeader" runat="server" />
        <div class="content">
        	<div class="main">
                <div class="leftblock">
				    <div id="gengkuan">
                       <dl><img src="/images/block100.gif"></dl>
                       <div id="danganziliaoku">
                          <div class="pesonal">
						  	<div class="yidenglv">
								<a class="rentxin" href="#"><img width="84" height="90" border="0" src="<%= DataCache.GetHeadPicture(User.HeadPicture) %>"></a>
							</div>
							
						  	<div class="gerendangan xinxiyuan">
								<div class="xingming">
									<h3><%=User.Name %></h3> <a href="<%=User.BlogUrl %>" class="zpshouye">[TA的博客]</a>
									<div class="clear"></div>
								</div>
								<p>城市：<span><%=User.City %></span></p>
								<p>他的优童：<span><a href="#" class="ytmingzi"><%=Child.Name %></a> <a class="genduoytxx" href="#">更多优童>></a></span></p>
								<p>活跃度：<span class="hongse">131</span></p>
								<p>积分：<span class="hongse">1311</span></p>
								<p>等级：<span class="hongse">13</span></p>
							</div>
							<div class="clear"></div>
						  </div> 
						  <div class="guanxi">
						  	<h4>TA的状态：</h4>
							<p>全家度假归来，带孩子去了香港迪斯尼玩 ...全家度假归来，带孩子去了香港迪斯尼玩 ...全家度假归来，带孩子去了香港迪斯尼玩 ...全家度假归来，带孩子去了香港迪斯尼玩 ...</p>
						  </div>
                       </div>
                       <dl><img src="/images/block102.gif"></dl>
                    </div>	
					
					<%--<div class="caiyixiu">
                        <div class="block1">
                           <a class="title" href="#">关注的优童</a>
						   <a href="#" class="genduoyx">关注的全部优童11个&gt;&gt;</a>
                           <div class="clear"></div>
                        </div>
                        <div class="block2">
							<div class="kongzhinr">
								<div class="zuopin">
									<div class="listleft">
										<a class="zuopinbg" title=" " href="#"><img width="100" height="75" border="0" alt="" src="./images/ertong02.gif"></a>
										<a href="#" class="guanzhuanniu"><img width="95" height="32" border="0" alt="我要关注" src="./images/guanzhubtn.gif"></a>
									</div>
									
									<div class="zpxinxi">
										<a class="zpmclan" title=" " href="#">某某某</a>
										<p class="zpzz">学校： <span>徐汇区宛平幼儿园<br>（某某分校）</span></p>
										<p class="zpzz">最新寄语<span>4</span>条</p>
										<p class="zpzz">人气：<span>131</span></p>
										<p class="zpzz">关注：<span>131</span></p>
										<p class="zpzz">作品：<span>111</span></p>
									</div>
									<div class="clear"></div>
								</div>
								
								<div class="zuopin">
									<div class="listleft">
										<a class="zuopinbg" title=" " href="#"><img width="100" height="75" border="0" alt="" src="./images/ertong02.gif"></a>
										<a href="#" class="guanzhuanniu"><img width="95" height="32" border="0" alt="我要关注" src="./images/guanzhubtn.gif"></a>
									</div>
									
									<div class="zpxinxi">
										<a class="zpmclan" title=" " href="#">某某某</a>
										<p class="zpzz">学校： <span>徐汇区宛平幼儿园<br>（某某分校）</span></p>
										<p class="zpzz">最新寄语<span>4</span>条</p>
										<p class="zpzz">人气：<span>131</span></p>
										<p class="zpzz">关注：<span>131</span></p>
										<p class="zpzz">作品：<span>111</span></p>
									</div>
									<div class="clear"></div>
								</div>
								
								<div class="clear"></div>
							</div>
                        	
                        </div>
                        <div class="block3">
                        </div>
                    </div>--%>
					
					<div class="caiyixiu">
                        <div class="block1">
						   <a href="#" class="title">TA的博客</a>
						   <a href="#" class="genduoyx">全部11篇日记&gt;&gt;</a>
						   <div class="clear"></div>
                        </div>
                        <div class="block2">
                            <asp:Repeater ID="rp_Blogs" runat="server">
                                <ItemTemplate><div class="dpneirong newplgao">
								<div class="plneirong changdugao">
									<div class="textboke"><p><span><em>标题名字</em></span><span class="people">[2010-02-25 22:55:11]</span> </p>
										<p class="jieshaowenzi">春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。春之声幼儿园创办于1989年，现为浦东新区一级一类幼儿园。幼儿园比邻曼趣公园，环境绿化优美。</p>
										<a href="#" class="chakanquanbu">[查看原文]</a></div>
									<div class="clear"></div>
								 </div>
							</div><div class="block3">
                        </div></ItemTemplate>
                            </asp:Repeater>
						</div>                        
                      </div>
					  
					<div class="caiyixiu">
                        <div class="block1">
                           <a class="title" href="#">TA的亲子影像</a>
                           <div class="tab noright">
                                <ul class="nav">
                                	<li><a class="choose" href="#"><span>相册</span></a></li>
                                    <li><a href="#"><span>视频</span></a></li>
                                </ul>
                           </div>
						   <a href="#" class="genduoyx">全部21个影像&gt;&gt;</a>
                           <div class="clear"></div>
                        </div>
                        <div class="block2">
                        	<div class="julipaixu00">
								<div class="xiangce_mk">
									<a  href="#" class="tuxiangkuang"></a>
									<div class="xcxinxi00">
										<a href="#" class="lansewenzi">相册名字七个字</a>
										<h3><span>5个照片</span><span>10个视频</span></h3>
										<p>更新于：<em>2010年5月1日</em></p>
										<p>更新于：<em>2010年5月1日</em></p>
									</div>
									<div class="clear"></div>	
								</div>
								
								<div class="xiangce_mk">
									<a  href="#" class="tuxiangkuang"></a>
									<div class="xcxinxi00">
										<a href="#" class="lansewenzi">相册名字七个字</a>
										<h3><span>5个照片</span><span>10个视频</span></h3>
										<p>更新于：<em>2010年5月1日</em></p>
										<p>更新于：<em>2010年5月1日</em></p>
									</div>
									<div class="clear"></div>	
								</div>
								<div class="clear"></div>
							</div>		
                        </div>
                        <div class="block3">
                        </div>
                    </div>
					
				</div>
				
                <div class="rightblock">
					<%--<div class="jiatingchengyuan">
                   		 <div class="zhuanjiablock1">
                             	<div class="kong">
                                    <a href="#" class="title">优童家庭成员</a>
                                    <a href="#" class="more">>>更多</a>
                                </div>
                          </div>
                             
                         <div class="zhuanjiablock2">
								<div class="zuopin chengyuanji">
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
									<div class="clear"></div>
									<div class="xuxian"></div>
									<div class="jiarujiating">
										<a href="#" class="savebtn" title="加入家庭"><span>加入家庭</span></a>
									</div>
									<div class="clear"></div>
								</div>
						  </div>
                             
                         <div class="zhuanjiablock3">
                         </div>
                    </div>--%>
					
					<%--<div class="youjuli">
                   		 <div class="zhuanjiablock1">
                             	<div class="kong">
                                    <a href="#" class="title">参加的优童活动</a>
                                   <a class="genduoyx" href="#">全部111个优童活动>></a>
                                </div>
                          </div>
                             
                         <div class="zhuanjiablock2">
								<table class="table300" cellpadding="0" cellspacing="0" width="100%" border="0">
									<tbody>
										<tr>
											<td class="zhaungtai01">[已结束]</td>
											<td>迪士尼亲自游<span>时间：2009-12-25</span></td>
											<td>1人参加</td>
										</tr>
										<tr>
											<td class="zhaungtai02">[进行中]</td>
											<td>迪士尼亲自游<span>时间：2010-04-25</span></td>
											<td>1人参加</td>
										</tr>
										<tr class="last">
											<td class="zhaungtai01">[已结束]</td>
											<td>迪士尼亲自游<span>时间：2009-12-25</span></td>
											<td>1人参加</td>
										</tr>
									</tbody>
								</table>
						  </div>
                             
                         <div class="zhuanjiablock3">
                         </div>
                    </div>--%>
					
					<%--<div class="youjuli">
                   		 <div class="zhuanjiablock1">
                             	<div class="kong">
                                    <a href="#" class="title">加入圈子</a>
                                   <a class="genduoyx" href="#">全部11个圈子>></a>
                                </div>
                          </div>
                             
                         <div class="zhuanjiablock2">
						 	<div class="quanzipingdao">
								<div class="wodequanzi">
									<a href="#" class="quanziimg"><img width="32" height="32" border="0" src="./images/quanzi_img01.gif" alt="圈子"></a>
									<a href="#">春之声幼儿园</a>
									<p>2005届 4班</p>
								</div>	
								<div class="wodequanzi">
									<a href="#" class="quanziimg"><img width="32" height="32" border="0" src="./images/quanzi_img01.gif" alt="圈子"></a>
									<a href="#">春之声幼儿园</a>
									<p>2005届 4班</p>
								</div>	
								<div class="wodequanzi">
									<a href="#" class="quanziimg"><img width="32" height="32" border="0" src="./images/quanzi_img01.gif" alt="圈子"></a>
									<a href="#">春之声幼儿园</a>
									<p>2005届 4班</p>
								</div>	
								<div class="wodequanzi">
									<a href="#" class="quanziimg"><img width="32" height="32" border="0" src="./images/quanzi_img01.gif" alt="圈子"></a>
									<a href="#">春之声幼儿园</a>
									<p>2005届 4班</p>
								</div>	
								<div class="clear"></div>
							</div>
						 </div>
                             
                         <div class="zhuanjiablock3">
                         </div>
                    </div>--%>
					
				</div>
				<div class="clear"></div>
             </div>
        </div>
        <ut:WebFooter ID="WebFooter" runat="server" />
    </div>
    </form>
</body>
</html>
