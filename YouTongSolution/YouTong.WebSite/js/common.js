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