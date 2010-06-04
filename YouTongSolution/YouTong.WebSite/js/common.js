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
			    html.push('<div class="fenline"><div class="zuopin">');
			    for(var i=0; i<json.length; i++){
			        html.push('<div class="listleft"><a class="zuopinbg" title=" " href="Works-Detail.aspx?ID='+json[i][0]+'"><img width="100" height="75" border="0" alt="" src="'+json[i][1]+'"></a></div>');
			        html.push('<div class="zpxinxi"><a class="zpmclan" title=" " href="#">'+json[i][2]+'</a><p class="renqisc0"><span>人气：<em>131</em></span></p><p class="renqisc0"><span>评分：<em>3</em></span></p><p class="renqisc0"><span>收藏：<em>13</em></span></p></div>');
			    }
			    html.push('</div></div></div>');
			    $('.waibu').html(html.join(''));
			    
			    
			},
			fail : function(){
			}
		});
}