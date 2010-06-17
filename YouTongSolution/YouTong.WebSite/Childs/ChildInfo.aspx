<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChildInfo.aspx.cs" Inherits="YouTong.WebSite.Childs.ChildInfo" %>

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
	<script src="../js/jquery.form-2.24.js" type="text/javascript"></script>
	<script src="../js/jquery.validate-1.5.2.min.js" type="text/javascript"></script>
	<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	<script src="../Datas/AreaJson.aspx" type="text/javascript"></script>
	<script type="text/javascript">
	    var Guest = false;
	<%if (IsAnonymous || User.ID != UserID){%>
	    Guest = true;	    
	<%} %>
		var CMenu = "child";
	</script>
</head>
<body>
<form id="form1" runat="server">
    <div id="container">
        <ut:WebHeader ID="WebHeader" runat="server" />
        <div class="content">
			<div class="erjinav">
				当前位置：<a href="/Grow/Grow.aspx">成长档案</a><a>&gt;&gt;</a> <a class="choose" href="#">优童个人信息</a>
			</div>
			<div class="zuopinbianji">
				<div class="longblock01">
					<a class="title" href="#">优童个人信息</a>
					<div class="clear"></div>
				</div>
				<div class="longblock02">
					<div class="gerenziliao">
						<div class="gerenbg01">
							<a class="title01" href="#">个人信息</a>
						</div>
						<div class="gerenbg02">
							<div class="mokuaihua">
								<div class="leftkuai">
									<table class="table100" cellspacing="0" cellpadding="0" width="100%" border="0">
										<tbody>
											<tr>
												<td width="10%" class="textright">姓名：</td>
												<td width="30%">
												<%if (IsAnonymous || User.ID != UserID)
              {%><%=this.child.Name %>
												<%}
              else
              { %>
												<asp:TextBox ID="Child_Name" CssClass="qunziinput" runat="server" MaxLength="5"></asp:TextBox>
												<%} %></td>
												<td width="12%" class="textright">性别：</td>
												<td width="48%">
												<%if (IsAnonymous || User.ID != UserID)
              {
                  if (this.child.Gender == 0)
                  {
                  %>男<%}
                  else
                  { %>女<%} %>
              <%}
              else
              { %>
                                                    <asp:RadioButtonList ID="Child_Gender" runat="server">
                                                        <asp:ListItem Value="1">男</asp:ListItem>
                                                        <asp:ListItem Value="2" Selected="True">女</asp:ListItem>
                                                    </asp:RadioButtonList><%} %>
											</tr>
											<tr>
												<td class="textright">昵称：</td>
												<td>
												<%if (IsAnonymous || User.ID != UserID)
              {%><%=this.child.NikcName %><%}
              else
              { %>
												<asp:TextBox ID="Child_NikcName" runat="server" CssClass="qunziinput"></asp:TextBox><%} %></td>
												<td class="textright">出生年月：</td>
												<td>
													<%if (IsAnonymous || User.ID != UserID)
               {%><%=this.child.Birthday.ToString("yyyy-MM-dd")%><%}
               else
               { %>
													<asp:TextBox ID="Child_Birthday" runat="server" CssClass="qunziinput" onclick="WdatePicker()"></asp:TextBox><%} %>
												</td>
											</tr>
											<tr>
												<td class="textright">目前就读学校：</td>
												<td  colspan="3">
												<%if (IsAnonymous || User.ID != UserID)
              {%><div id="ShowSchool"></div><%}
              else
              { %>
													<select runat="server" id="Child_City" name="Child_City" class="select1">
									</select>
									<select runat="server" id="Child_Region" name="Child_Region" class="select1">
									</select>
									<select runat="server" id="Child_Level" class="select1">
										<option value="0">学校类型</option>
										<option value="1">幼儿园</option>
										<option value="2">小学</option>
									</select>
									<select runat="server" id="Child_SchoolID" name="Child_SchoolID" class="select1">
									</select><%} %>
												</td>
											</tr>
											<tr>
								<td class="textright">
									入学年份：
								</td>
								<td>
								<%if (IsAnonymous || User.ID != UserID)
          {%><%=this.child.CurrentGrade%><%}
          else
          { %>
                                    <select runat="server" id="Child_CurrentGrade" name="Child_CurrentGrade" class="select1">
										<option value="1996">1996</option>
										<option value="1997">1997</option>
										<option value="1998">1998</option>
										<option value="1999">1999</option>
										<option value="2000">2000</option>
										<option value="2001">2001</option>
										<option value="2002">2002</option>
										<option value="2003">2003</option>
										<option value="2004">2004</option>
										<option value="2005">2005</option>
										<option value="2006">2006</option>
										<option value="2007">2007</option>
										<option value="2008">2008</option>
										<option value="2009">2009</option>
										<option value="2010">2010</option>
										<option value="2011">2011</option>
									</select><%} %>
								</td>
							</tr>
							<tr>
								<td class="textright">
									学校班级：
								</td>
								<td>
								<%if (IsAnonymous || User.ID != UserID)
          {%><%=this.child.CurrentClass%>班<%}
          else
          { %>
									<select runat="server" id="Child_CurrentClass" name="Child_CurrentClass" class="select1">
										<option value="1">一班</option>
										<option value="2">二班</option>
										<option value="3">三班</option>
										<option value="4">四班</option>
										<option value="5">五班</option>
										<option value="6">六班</option>
										<option value="7">七班</option>
										<option value="8">八班</option>
										<option value="9">九班</option>
										<option value="10">十班</option>
										<option value="11">其他</option>
									</select><%} %>
								</td>
							</tr>
											<tr>
												<td class="textright">才艺类别：</td>
												<td colspan="3">
													<div class="check100">
														<span><input name="Child_Talent" value="1" type="checkbox" class="checkbox" id="chk_0" /><label for="chk_0">美术绘画</label></span><span><input name="Child_Talent" value="2" type="checkbox" class="checkbox" id="chk_1" /><label for="chk_1">书法</label></span><span><input name="Child_Talent" value="3" type="checkbox" class="checkbox" id="chk_2" /><label for="chk_2">摄影摄像</label></span><span><input name="Child_Talent" value="4" type="checkbox" class="checkbox" id="chk_3" /><label for="chk_3">器乐演奏</label></span><span><input name="Child_Talent" value="5" type="checkbox" class="checkbox" id="chk_4" /><label for="chk_4">歌曲演唱</label></span><span><input name="Child_Talent" value="6" type="checkbox" class="checkbox" id="chk_5" /><label for="chk_5">舞蹈表演</label></span><span><input name="Child_Talent" value="7" type="checkbox" class="checkbox" id="chk_6" /><label for="chk_6">少儿英语</label></span><span><input name="Child_Talent" value="8" type="checkbox" class="checkbox" id="chk_7" /><label for="chk_7">戏剧小品</label></span><span><input name="Child_Talent" value="9" type="checkbox" class="checkbox" id="chk_8" /><label for="chk_8">手工制作</label></span><span><input name="Child_Talent" value="10" type="checkbox" class="checkbox" id="chk_9" /><label for="chk_9">体育运动</label></span><span><input name="Child_Talent" value="11" type="checkbox" class="checkbox" id="chk_10" /><label for="chk_10">科技创意</label></span><span><input name="Child_Talent" value="12" type="checkbox" class="checkbox" id="chk_11" /><label for="chk_11">朗诵表演</label></span><span><input name="Child_Talent" value="13" type="checkbox" class="checkbox" id="chk_12" /><label for="chk_12">奥数</label></span><span><input name="Child_Talent" value="14" type="checkbox" class="checkbox" id="chk_13" /><label for="chk_13">作文</label></span><span><input name="Child_Talent" value="15" type="checkbox" class="checkbox" id="chk_14" /><label for="chk_14">另类其他</label></span>
													</div>
												</td>
											</tr>
											
										</tbody>
									</table>
									<div class="gerentouxiang">
										<a class="rentx"><img width="84" height="90" border="0" align="" src="<%=DataCache.GetHeadPicture(this.child.HeadPicture) %>"></a>
										<%if (!IsAnonymous && User.ID == UserID)
            {%><a href="/Member/ChildInfo-Face.aspx" class="bianjibtn">[编辑]</a><%} %>
									</div>
									<div class="clear"></div>
								</div>
								<div class="rightkuai">
                                    <%if (!IsAnonymous && User.ID == UserID)
                                      {%>
                                    <asp:LinkButton ID="lb_SaveInfo" runat="server" CssClass="baocunbtn" 
                                        onclick="lb_SaveInfo_Click"><span>保存</span></asp:LinkButton><%} %>
									<div class="clear"></div>
								</div>
							</div>
							<div class="clear"></div>
						</div>
						<div class="gerenbg03">
						</div>
					</div>					
					<div class="gerenziliao">
						<div class="gerenbg01">
							<a class="title01" href="#">才艺履历</a>
						</div>
						<div class="gerenbg02">
						    <asp:Repeater ID="rp_Resume" runat="server">
						        <ItemTemplate>
						        <div class="mokuaihua yongyouline">
								<div class="leftkuai">
									<table class="table200" cellspacing="0" cellpadding="0" width="100%" border="0">
										<tbody>											
											<tr>
												<td class="textright" width="9%">时间：</td>
												<td width="91%">
													<span><%#Eval("StartDate")%>年</span><span>到</span>
													<span><%#Eval("EndDate") %>年</span>
												</td>
											</tr>
											<tr>
											    <td>标题：</td>
											    <td><%#Eval("Title") %></td>
											</tr>
											<tr>
											    <td>内容：</td>
											    <td><%#Eval("Body") %></td>
											</tr>
										</tbody>
									</table>
									<div class="clear"></div>
								</div>
								<div class="rightkuai">
								<%if (!IsAnonymous && User.ID == UserID)
          {%>
									<a href="javascript:void(0);" onclick="DeltetCategory('<%=UserID %>','<%=child.ID %>','<%#Eval("ID") %>');" class="shanchu_btn">[删除]</a><%} %>
								</div>
							</div>
							<div class="clear"></div>
						        </ItemTemplate>
						    </asp:Repeater>
						    <div id="Add_Resume" style="display:none;">
						        <div class="mokuaihua yongyouline">
								<div class="leftkuai">
									<table class="table200" cellspacing="0" cellpadding="0" width="100%" border="0">
										<tbody>											
											<tr>
												<td class="textright" width="9%">时间：</td>
												<td width="91%">
													<span><asp:TextBox ID="Resume_StartDate" runat="server" CssClass="qunziinput" onclick="WdatePicker()"></asp:TextBox>年</span><span>到</span>
													<span><asp:TextBox ID="Resume_EndDate" runat="server" CssClass="qunziinput" onclick="WdatePicker()"></asp:TextBox>年</span>
												</td>
											</tr>
											<tr>
											    <td class="textright" >标题：</td>
											    <td>
                                                    <asp:TextBox ID="Resume_Title" runat="server" MaxLength="128" Width="498px"></asp:TextBox></td>
											</tr>
											<tr>
											    <td class="textright" >内容：</td>
											    <td>
                                                    <asp:TextBox ID="Resume_Body" runat="server" Height="111px" TextMode="MultiLine" 
                                                        Width="502px"></asp:TextBox></td>
											</tr>
										</tbody>
									</table>
									<div class="clear"></div>
								</div>
								<div class="rightkuai">
                                    <asp:LinkButton ID="lb_Add" runat="server" CssClass="baocunbtn" 
                                        onclick="lb_Add_Click"><span>保存</span></asp:LinkButton>
									<a href="javascript:Delete_Resume();" class="shanchu_btn">[删除]</a>
								</div>
							</div>
							<div class="clear"></div>
						    </div>
						    <%if (!IsAnonymous && User.ID == UserID)
            {%>
						    <input type="button" class="button002" value="继续添加" onclick="Add_Resume();"/><%} %>
						</div>
						<div class="gerenbg03">
						</div>
					</div>
				</div>
				<div class="longblock03">
				</div>
			</div>
        </div>
        <ut:WebFooter ID="WebFooter" runat="server" />
    </div>
    <asp:Literal ID="ltr_JS" runat="server"></asp:Literal>
    </form>
</body>
</html>
<script type="text/javascript">
    var talentCB = document.getElementsByName("Child_Talent");
    if(talents != ""){
        var talentArray = talents.split(',');
        for(var ti=0;ti<talentCB.length;ti++){
            for(var tj=0;tj<talentArray.length;tj++){
                if(talentCB[ti].value == talentArray[tj]){
                    talentCB[ti].checked=true;
                    break;
                }
            }
        }
    }
	jQuery.validator.addMethod(
			"zhWord",
			function(username, element) {
				username = username.replace(/\s+/g, "");
				return this.optional(element) || username.match(/^[\u4E00-\u9FA5]+\w*$/);
			},
			"只能使用中文");

	$(function() {
		$("#form1").validate({
			rules: {
				Child_Name: { required: true, zhWord: true },
				Child_Birthday: { required: true }
			},
			messages: {
				Child_Name: { required: "必填(*)" },
				Child_Birthday: { required: "必填(*)" }
			}
		});

		var roots = getRootAreas();
		var len = roots.length;
		if(Guest){		    
		    for (var i = 0; i < len; i++) {
		        if(roots[i].ID == city)
		        {
		            city = roots[i].Name;
		            var childs = getChildAreas(roots[i].ID);
		            for (var j = 0; j < childs.length; j++) {
		                if(childs[j].ID == region){
		                    region = childs[j].Name;
		                    break;
		                }
		            }
		            break;
		        }
		    }
		    $("#ShowSchool").html(city + region + school);
		}
		else{
		    var cityIndex=0;
		    var regionIndex=0;
		    var schoolIndex=0;
		    $("<option value='0'>请选择城市</option>").appendTo("#Child_City");
		    for (var i = 0; i < len; i++) {
			    $("<option value='" + roots[i].ID + "'>" + roots[i].Name + "</option>").appendTo("#Child_City");
			    if(roots[i].ID == city)
			        cityIndex = i + 1;
		    }
		    document.getElementById("Child_Level").selectedIndex = level;
		    $("#Child_City").change(
			    function() {
			        var citySelect = document.getElementById("Child_City");
				    var rootId = citySelect.options[citySelect.selectedIndex].value;
				    var childs = getChildAreas(rootId);

				    $("#Child_Region").empty();

				    $("<option value='0'>请选择地区</option>").appendTo("#Child_Region");
				    for (var j = 0; j < childs.length; j++) {
					    $("<option value='" + childs[j].ID + "'>" + childs[j].Name + "</option>").appendTo("#Child_Region");
					    if(childs[j].ID == region)
					        document.getElementById("Child_Region").selectedIndex = j + 1; 
				    }

				    $("#Child_Region").change();
			    }
		    );

		    $("#Child_Region").change(function() {
		        $("#Child_Level").change() }
		    );

		    $("#Child_Level").change(
			    function() {
			        var regionSelect = document.getElementById("Child_Region");
				    var id = regionSelect.options[regionSelect.selectedIndex].value;
				    var levelSelect = document.getElementById("Child_Level");
				    var _level = levelSelect.options[levelSelect.selectedIndex].value;
				    
				    $("#Child_SchoolID").empty();

				    $.getJSON("/_Handlers/GetSchools.ashx", { region: id, level: _level },
					    function(data) {
						    for (var z = 0; z < data.length; z++) {
							    $("<option value='" + data[z].ID + "'>" + data[z].Name + "</option>").appendTo("#Child_SchoolID");
							    if(data[z].Name == school)
							        document.getElementById("Child_SchoolID").selectedIndex = z;
						    }
					    }
				     );
			    }
		    );
            
            document.getElementById("Child_City").selectedIndex = cityIndex;
            
            
		    $("#Child_City").change();
		    //$("#Child_Region").change();
		    //$("#Child_Level").change();
		    
		               
		}
	});
	function Add_Resume(){
	    document.getElementById("Add_Resume").style.display="";
	}
	function Delete_Resume(){
	    document.getElementById("Add_Resume").style.display="none";
	}
	//删除相册
    function DeltetCategory(userid, childid,id){
        if(confirm("是否删除履历")){
            jQuery.ajax({
                url : "/_Handlers/Info.ashx?action=delete&userid=" + userid + "&childid=" + childid + "&Id=" + id,
                async : false,
                success : function(){
                    window.location.reload();
                },
                fail : function(){
                    window.location.reload();
                }
            });
        }
    }
</script>