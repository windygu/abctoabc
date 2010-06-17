<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="YouTong.WebSite.Childs.Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>个人主页|优童|越秀越优秀|中国儿童优秀展示平台</title>
	<meta name="keywords" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<meta name="description" content="www.no1child.com, 优童，越秀越优秀，中国儿童优秀展示平台" />
	<link href="../css/content.css" type="text/css" rel="stylesheet" />
	<link href="../css/default.css" type="text/css" rel="stylesheet" />
	<script src="../js/jquery-1.4.1.min.js" type="text/javascript"></script>
	<script src="/Datas/AreaJson.aspx" type="text/javascript"></script>
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
				当前位置：<a href="/">首页</a>&gt;&gt;<a href="/childs/">优童秀</a>
			</div>
			<div class="zuopinbianji">
			    
				<div class="longblock01">
					<a class="title" href="#">搜索列表</a>
					<div style="float:right; margin:10px 30px 0px 0px;">
					    <select id="City" name="City" class="xuanze">
						<option value='0'>请选择城市</option>
			            </select>
			            <select id="Region" name="Region" class="xuanze">
			            <option value='0'>请选择地区</option>
			            </select>
			            <select id="Level" class="xuanze" name="Level">
				            <option value="0">学校类型</option>
				            <option value="1">幼儿园</option>
				            <option value="2">小学</option>
			            </select>
			            <select id="SchoolID" name="SchoolID" class="xuanze">
			            <option value='0'>请选择学校</option>
			            </select>
					    <input type="button" value="搜索" class="button001" style="margin:4px 0 0 5px;height:22px;" onclick="SearchChild();" />
					</div>
					<div class="clear">
					</div>
				</div>
				<div class="longblock02">
					<asp:Repeater ID="rp_Search" runat="server">
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
											<a target="_blank" href="ChildDefault.aspx?userid=<%# Eval("ParentID") %>" class="zuopinbg">
												<img width="100" height="75" border="0" src="<%# DataCache.GetHeadPicture(Eval("HeadPicture")) %>" alt=""></a>
										</div>
										<div class="zpxinxi">
											<a target="_blank" href='ChildDefault.aspx?userid=<%# Eval("ParentID") %>' class="zpmclan">
												<%# Eval("Name") %></a>
											<p class="zpzz">年龄：<span><%#Eval("AGE") %></span>岁</p>
											<p class="zpzz">
													学校： <span><%#DataCache.GetSchoolNameByUserID(new Guid(Eval("ParentID").ToString()))%></span>
											</p>
											<p class="zpzz">
													最新寄语<span><%#GetCommentCounts(Eval("ID"), YouTong.WebSite.Codes.EntityName.ChildCommentEntity)%></span>条</p>
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
	<asp:Literal ID="ltr_JS" runat="server"></asp:Literal>
	</form>
</body>
</html>
<script type="text/javascript">
		var roots = getRootAreas();
		var len = roots.length;
		$("#City").empty();
		$("<option value='0'>请选择城市</option>").appendTo("#City");
		    for (var i = 0; i < len; i++) {
			    $("<option value='" + roots[i].ID + "'>" + roots[i].Name + "</option>").appendTo("#City");
			    if(roots[i].ID == city)
			        cityIndex = i + 1;
		    }
		    document.getElementById("Level").selectedIndex = level;
		    $("#City").change(
			    function() {
			        var citySelect = document.getElementById("City");
				    var rootId = citySelect.options[citySelect.selectedIndex].value;
				    var childs = getChildAreas(rootId);

				    $("#Region").empty();

				    $("<option value='0'>请选择地区</option>").appendTo("#Region");
				    for (var j = 0; j < childs.length; j++) {
					    $("<option value='" + childs[j].ID + "'>" + childs[j].Name + "</option>").appendTo("#Region");
					    if(childs[j].ID == region)
					        document.getElementById("Region").selectedIndex = j + 1; 
				    }

				    $("#Region").change();
			    }
		    );

		    $("#Region").change(function() {
		        $("#Level").change() }
		    );

		    $("#Level").change(
			    function() {
			        var regionSelect = document.getElementById("Region");
				    var id = regionSelect.options[regionSelect.selectedIndex].value;
				    var levelSelect = document.getElementById("Level");
				    var _level = levelSelect.options[levelSelect.selectedIndex].value;
				    
				    $("#SchoolID").empty();
				    $("<option value='0'>请选择学校</option>").appendTo("#SchoolID");
				    $.getJSON("/_Handlers/GetSchools.ashx", { region: id, level: _level },
					    function(data) {
						    for (var z = 0; z < data.length; z++) {
							    $("<option value='" + data[z].ID + "'>" + data[z].Name + "</option>").appendTo("#SchoolID");
							    if(data[z].ID == school)
							        document.getElementById("SchoolID").selectedIndex = z + 1;
						    }
					    }
				     );
			    }
		    );
            
            document.getElementById("City").selectedIndex = cityIndex;

		$("#City").change();
		function SearchChild(){
		    var citySelect = document.getElementById("City");
			var city = citySelect.options[citySelect.selectedIndex].value;
		    var regionSelect = document.getElementById("Region");
			var region = regionSelect.options[regionSelect.selectedIndex].value;
			var levelSelect = document.getElementById("Level");
			var level = levelSelect.options[levelSelect.selectedIndex].value;
			var schoolSelect = document.getElementById("SchoolID");
			var school = schoolSelect.options[schoolSelect.selectedIndex].value;
			location.href = "/childs/Search.aspx?City=" + city + "&Region=" + region + "&Level=" + level + "&SchoolID=" + school;
		}
</script>