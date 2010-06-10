function CopyUrl() {
	if (clipboardData.setData("Text", document.title + "   " + document.URL)) {
		alert("您已成功复制该地址，请发送给好友或用Ctrl+V粘帖");
	}
}

function regCatMove() {
	$('.yousanjiao').click(function() {
		var p = $(this).parent();
		var d = $(p).find(".move").css('left');
		var distance = getValue(d);
		var newdistance = distance - 82;
		if (newdistance >= Number(-($(p).find('.nav li').length - 4) * 82)) {
			$(p).find('.move').animate({ 'left': newdistance + "px" }, "200");
		}
	});

	$('.zuosanjiao').click(function() {
		var p = $(this).parent();
		var d = $(p).find('.move').css('left');
		var distance = getValue(d);
		var newdistance = distance + 82;
		if (newdistance <= 0) {
			$(p).find('.move').animate({ 'left': newdistance + "px" }, "200");
		}
	});

	$('.nav').each(function() {
		$(this).find('li').eq(0).children('a').addClass('choose');
	});
}

function getValue(target) {
	var val = target.substring(0, target.length - 2);
	return Number(val);
}
//得到作品
function GetWords(a, userid, Cat){
    $('.nav li').find('a').each(function() {
        if ($(this).hasClass('choose')) {
            $(this).removeClass('choose');
        }
    });
    $(a).addClass('choose');
    jQuery.ajax({
			url: "/_Handlers/GetWorks.ashx?userid=" + userid + "&Cat=" + Cat,
			async: true,
			success : function(data){
			    var json = eval(data);
			    var html = [];
			    html.push('<div class="fenline">');
			    for(var i=0; i<json.length; i++){
			        html.push('<div class="zuopin">');
			        html.push('<div class="listleft"><a class="zuopinbg" title=" " href="Works-Detail.aspx?ID='+json[i][0]+'"><img width="100" height="75" border="0" alt="" src="'+json[i][1]+'"></a></div>');
			        html.push('<div class="zpxinxi"><a class="zpmclan" title=" " href="#">'+json[i][2]+'</a><p class="renqisc0"><span>人气：<em>131</em></span></p><p class="renqisc0"><span>评分：<em>3</em></span></p><p class="renqisc0"><span>收藏：<em>13</em></span></p></div></div>');
			    }
			    html.push('</div>');
			    $('.waibu').html(html.join(''));		    
			    
			},
			fail : function(){
			}
		});
}
//得到作品
function GetWords(a, Cat){
    $('.nav li').find('a').each(function() {
        if ($(this).hasClass('choose')) {
            $(this).removeClass('choose');
        }
    });
    $(a).addClass('choose');
    jQuery.ajax({
			url: "/_Handlers/GetWorks.ashx?Cat=" + Cat,
			async: true,
			success : function(data){
			    var json = eval(data);
			    var html = [];
			    html.push('<div class="fenline">');
			    for(var i=0; i<json.length; i++){
			        html.push('<div class="zuopin">');
					html.push('<div class="listleft">');
					html.push('<a href="/childs/works-detail.aspx?id='+json[i][0]+'" class="zuopinbg">');
					html.push('<img src="'+json[i][1]+'" width="100" height="75" border="0" alt="" /></a></div>');
					html.push('<div class="zpxinxi">');
					html.push('<a href="/childs/works-detail.aspx?id='+json[i][0]+'" class="zpmclan">'+json[i][2]+'</a>');
					html.push('<p class="zpzz">作者： <span>'+ json[i][3] + '</span></p>');
					html.push('<p class="zpzz">学校： <span>' + json[i][4] + '</span></p>');
					html.push('<div class="clear"></div></div><div class="clear"></div>');
					html.push('<p class="renqisc"><span>人气：<em>131</em></span><span> 评分：<em>4.2分</em></span></p>');
					if(json[i][5] == "")
					    html.push('<a href="" class="dcpl">&nbsp;</a></div>');
					else
					    html.push('<a href="/childs/works-detail.aspx?id='+json[i][0]+'" class="dcpl">'+json[i][5]+'['+json[i][6]+'评论]</a></div>');
			    }
			    html.push('</div>');
			    $('#workContainer').html(html.join(''));		    
			    
			},
			fail : function(){
			}
		});
}
//删除相册
function DeltetCategory(userid,id){
    if(confirm("是否删除相册")){
        jQuery.ajax({
            url : "/_Handlers/Category.ashx?action=delete&userid=" + userid + "&Id=" + id,
            async : false,
            success : function(){
                window.location.reload();
            },
            fail : function(){
                alert("删除相册出错!");
            }
        });
    }
}
//更新相册
function UpdateCategory(userid, id, name){
    var name = document.getElementById("CatatoryName_Update").value;
    if(name == "")
        alert("请输入相册名");
    else{
        jQuery.ajax({
            url : "/_Handlers/Category.ashx?action=update&userid=" + userid + "&Id=" + id + "&value=" + encodeURI(name),
            async : false,
            success : function(){
                window.location.reload();
            },
            fail : function(){
                alert("更新相册出错!");
            }
        });
    }
}
//创建相册
function AddCategory(userid){
    var name = document.getElementById("CatatoryName").value;
    if(name == "")
        alert("请输入相册名");
    else{
        jQuery.ajax({
            url : "/_Handlers/Category.ashx?action=add&userid=" + userid + "&value=" + encodeURI(name),
            async : false,
            success : function(){
                window.location.reload();
            },
            fail : function(){
                alert("创建相册出错!");
            }
        });
    }
}
//删除相册中的照片或视频
function DeleteAnyFile(userid, id){
    if(confirm("是否删除文件")){
        jQuery.ajax({
            url : "/_Handlers/Category.ashx?action=deleteAnyFile&userid=" + userid + "&Id=" + id,
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
//删除博客
function DeltetBlog(userid,id){
    if(confirm("是否删除博客")){
        jQuery.ajax({
            url : "/_Handlers/Blog.ashx?action=deleteAnyFile&userid=" + userid + "&Id=" + id,
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