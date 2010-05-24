    var tudou_username="eva@no1child.com";
    var tudou_password="youtongwang";
    var tudou_apikey="no1child-d1952968729865769d73587633fd6d85";

/*
            获取某具体视频的信息，传入id和回调函数
            
            callBack参数为Json
            
            得到Json
            {   "tags":"youtong",
            "pubDate":"2010-05-12",
            "ownerName":"_61967706",
            ....}
            详细请看： http://api.tudou.com/#fields
            
            举例如：function dealSinglePaly(item){
                alert(item.tags);
            }
            Tudou_GetSinglePlay(233451,dealSinglePaly)
           */ 
            function Tudou_GetSinglePlay(ItemId,callBack) {
                jQuery.getJSON(
                    "http://api.tudou.com/v2/i/info?ids=" + ItemId + "&format=json&apikey=" + tudou_apikey + "&fields=&jsoncallback=?",
                    function(msg) {
                        try {
                            var jsonObj = msg[1];
                            if (msg[1][0] == "undefined") { alert("实体undefined，土豆网接口出错，请联系土豆。"); }
                            callBack(msg[1][0]);
                        } catch (e) {
                            alert(e.message+",土豆网接口出错，请联系土豆。");
                        }
                    }
                );
            }
      
           
         
         
         /*
         上传视频。
         
         
         参数和使用说明：如下
            Tudou_VideoCreate({
                    callUploading:tudou_uploading,    //上传中调用
                    callProcessing:tudou_processing,  //上传完毕正在转码调用
                    callFail:tudou_fail,              //上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误
                    callTimeout:tudou_timeout,        //用户中途取消上传或用户的网络中途中断
                    callFinish:tudou_finish,          //上传完成，转码成功
                    iframeName:"fileUpiframe",        //一个隐藏iframe的Name，用于递交文件到土豆网
                    form:jQuery('#formOne')           //form表单引用，用于递交文件到土豆，包含了上传html控件。
                });
                
        参数对应的函数的参数就两种：
            1.msg ：信息
                  {“response”: “ok”, “message”: “ok”, “progress”: 79, “filesize”: 1024768, “status”: “init”}
                    返回的格式说明：
                    返回的是标准json格式，共5项
                    response是ok或error（小写字母），ok只此次查询成功，error是此次查询失败，失败原因在message中给出。
                    message是查询失败时的错误信息，已帮助开发者分析错误原因。可能的错误原因包括传入参数错误(errorParam)，服务暂时不可用(serviceUnavailable)，传入的id不存在(notFound)等
                    progress是上传进度的百分比，取值在0到100之间，0表示还未开始上传或刚开始上传，100表示上传完成。progress在uploading阶段存在。
                    filesize是当前视频文件的大致尺寸，可用来在上传过程中估算进度。filesize在uploading阶段存在。
                    status是整个流程的进度，可用的取值包括init(已经查询过接口1但还未开始上传), uploading(正在上传), processing(上传完成, 正在转码), finish(成功完成转码, 可以查询接口3了), fail(上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误), timeout(用户中途取消上传或用户的网络中途中断)
            2.Item：视频的土豆信息json
                具体值参考，  http://api.tudou.com/#fields
            
        参数对应的函数调用例子如下：
            //上传中
            function tudou_uploading(msg){
                jQuery("#qingkuang").html("正在上传...请勿关闭或者刷新浏览器" + msg.progress + "%;  文件大小：约" +parseInt(msg.filesize / 1024/1024 )+ "MB");
            }
            
            //上传完毕正在转码
            function tudou_processing(msg){
                jQuery("#qingkuang").html("上传完毕，正在转码....请勿关闭或者刷新浏览器" + msg.progress + "%;  文件大小：约" +parseInt(msg.filesize / 1024/1024 )+ "MB");
                           
            }
            
            //上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误
            function tudou_fail(msg){
                jQuery("#qingkuang").html("上传或转码失败, 一般是因为上传的视频格式比较罕见或格式错误。");
                           
            }
            
            //用户中途取消上传或用户的网络中途中断
             function tudou_timeout(msg){
                jQuery("#qingkuang").html("用户中途取消上传或用户的网络中途中断。");
                           
            }
            
            //上传完成，转码成功
            function tudou_finish(item){
                jQuery("#qingkuang").html("上传完成");
                AddInfo("播放的flash地址:"+item.outerPlayerUrl);   
                AddInfo("小图片:"+item.picUrl);                 
            }
              
           
         */
        
         function Tudou_VideoCreate(config){

             jQuery.ajax({
                 type: "GET",
                 url: "http://ulpc.tudou.com/mps2if/api-v1_1.do?action=item.newUpload&uploadType=api&user=" + tudou_username + "&password=" + tudou_password + "&jsoncallback=?",
                 dataType: "json",
                 timeout: function() {
                     alert("连接超时，无法连接土豆网！");
                 },
                 error: function(XMLHttpRequest, textStatus, errorThrown) {
                     alert("连接土豆网出错，无法连接。");
                 },
                 success: function(data) {

                     var uploadApi = data.uploadApi; //上传文件地址
                     var queryApi = data.queryApi + "&jsoncallback=?"; //查询状态地址
                     var attrsApi = data.attrsApi; //附件信息 比如标题。。
                     var itemId = data.itemId;
                     var dealUrl = attrsApi + "&title=" +
                        "youtong" + "&content=" +
                        "1" + "&channelId=" +
                        25 + "&uploadIp=&imake=0&tags=" +
                        "0" + "&jsoncallback=?";

                     var tudouInterval = setInterval(function() {
                         jQuery.getJSON(queryApi, function(msg) {
                             if (msg.progress > 0 && msg.progress < 100) {
                                 config.callUploading(msg);
                             } else if (msg.progress == 100) {
                                 if (msg.status == "processing") {
                                     config.callProcessing(msg);
                                 } else if (msg.status == "fail") {
                                     config.callFail(msg);
                                 } else if (msg.status == "timeout") {
                                     config.callTimeout(msg);
                                 } else if (msg.status == "finish") {
                                     Tudou_GetSinglePlay(itemId, config.callFinish);
                                     clearInterval(tudouInterval);
                                 }
                             }
                             else if(msg.progress == undefined && msg.status == "fail"){
                                config.callFail(msg);
                                clearInterval(tudouInterval);
                             }
                         });
                     }, 1000);

                     /*jQuery.ajax({ type: "GET",
                     url: dealUrl,
                     dataType: "json",
                     success: function(data) {
                            
                     AddInfo(data.response + data.message);
                     }
                     });*/
                     config.form.attr("action", uploadApi);
                     config.form.attr("target", config.iframeName);
                     config.form.submit();

                 }
             });
        }