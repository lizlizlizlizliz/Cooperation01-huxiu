$(document).ready(function () {

    //获取JS传递的语言参数
    var utils = new Utils();
    var args = utils.getScriptArgs();


    //隐藏Loading/注册失败 DIV
    $(".loading").hide();
    $(".login-error").hide();
    registError = $("<label class='error repeated'></label>");

    //加载国际化语言包资源
    utils.loadProperties(args.lang);

    //输入框激活焦点、移除焦点
    var inputCorrect;
    var focusNow;
    var blurNow;
    jQuery.focusblur = function (focusid) {
        var focusblurid = $(focusid);
        var defval = focusblurid.val();
        focusblurid.focus(function () {
            var thisval = $(this).val();
            if (thisval == defval) {
                $(this).val("");
            }
            focusNow = $(".row input").index(this);
            $(".icon-tips-div:eq(" + focusNow + ")")
				.css({
				    "display": "none"
				});
        });
        focusblurid.blur(function () {
            var thisval = $(this).val();
            if (thisval == "") {
                $(this).val(defval);
                return false;
            }
            blurNow = $(".row input").index(this);
            //judgeString 函数用来检测非法字符和空格
            if (judgeString(thisval)) {
                //thisval 获取用户名 ，用 ajax 进行检测是否注册过，如果注册过，显示红色叉号，否则显示绿色对号
                if (focusid == "#username") {   //只有当选中 username 才进行AJAX
                    $.ajax({
                        type: 'post',
                        url: "regist_username.ashx",
                        async: true,
                        //dataType: "json", 
                        data: {
                            'userName': thisval
                        },
                        success: function (data) {
                            //将字符串转化为 Json 对象
                            var dataObj = eval("(" + data + ")");
                            //alert(dataObj.code);
                            if (dataObj.code == 0) {
                                //用户名被注册过
                                //alert('no');
                                inputCorrect = false;
                                //显示红色叉号
                                $(".icon-tips-div:eq(" + blurNow + ")")
                    .css({
                        "display": "block"
                    });
                                $(".icon-tips-img:eq(" + blurNow + ")").css({
                                    "marginTop": "-80px"
                                });
                            }
                            else {
                                // alert('yes');
                                inputCorrect = true;
                                //显示绿色对号
                                $(".icon-tips-div:eq(" + blurNow + ")")
                    .css({
                        "display": "block"
                    });

                                $(".icon-tips-img:eq(" + blurNow + ")").css({
                                    "marginTop": "0px"
                                });
                            }
                        },
                        error: function () {
                            // inputCorrect = false;
                        }
                    });
                }


            }
            else
                alert("输入不合法！");
        });

    };
    /*下面是调用方法，用来检测非法字符和空格*/
    $.focusblur("#username");
    $.focusblur("#protectProblem");
    $.focusblur("#protectAnswer");


    //获取表单验证对象[填写验证规则]，插件
    var validate = $("#signupForm").validate({
        rules: {
            username: {
                required: true,
                maxlength: 8
            },
            password: {
                required: true,
                minlength: 4,
                maxlength: 16
            },
            passwordAgain: {
                required: true,
                minlength: 4,
                maxlength: 16,
                equalTo: "#password"
            },
            sex: {
                required: true
            },
            protectProblem: {
                required: true,
                minlength: 5,
                maxlength: 18
            },
            protectAnswer: {
                required: true,
                minlength: 5,
                maxlength: 18
            },
            captcha: {
                required: true,
                digits: true,
                maxlength: 2
            }
        },
        messages: {
            username: {
                required: $.i18n.prop("请输入用户名"),
                maxlength: jQuery.format($.i18n.prop("用户名太长"))
            },
            password: {
                required: $.i18n.prop("请输入密码"),
                minlength: jQuery.format($.i18n.prop("长度太短")),
                maxlength: jQuery.format($.i18n.prop("长度太长"))
            },
            passwordAgain: {
                required: $.i18n.prop("请再次输入密码"),
                minlength: jQuery.format($.i18n.prop("长度太短")),
                maxlength: jQuery.format($.i18n.prop("长度太短")),
                equalTo: jQuery.format($.i18n.prop("两次密码不匹配"))
            },
            sex: {
                required: $.i18n.prop("请选择性别")
            },
            protectProblem: {
                required: $.i18n.prop("请输入密保问题少于20字"),
                minlength: jQuery.format($.i18n.prop("密保问题字数太少请修改")),
                maxlength: jQuery.format($.i18n.prop("密保问题字数太多请修改")),
            },
            protectAnswer: {
                required: $.i18n.prop("请输入密保答案少于20字"),
                minlength: jQuery.format($.i18n.prop("密保答案字数太少请修改")),
                maxlength: jQuery.format($.i18n.prop("密保答案字数太多请修改")),
            },
            captcha: {
                required: $.i18n.prop("请输入验证码2"),
                maxlength: jQuery.format($.i18n.prop("检查验证码的合法性")),
                digits: jQuery.format($.i18n.prop("检查验证码的合法性")),
            }
        }
    });


    //输入框激活焦点、溢出焦点的渐变特效
    if ($("#username").val()) {
        $("#username").prev().fadeOut();
    };
    $("#username").focus(function () {
        $(this).prev().fadeOut();
        $("#username").next("label.repeated").hide();

    });
    $("#username").blur(function () {
        if (!$("#username").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#password").val()) {
        $("#password").prev().fadeOut();
    };
    $("#password").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#password").blur(function () {
        if (!$("#password").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#passwordAgain").val()) {
        $("#passwordAgain").prev().fadeOut();
    };
    $("#passwordAgain").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#passwordAgain").blur(function () {
        if (!$("#passwordAgain").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#protectProblem").val()) {
        $("#protectProblem").prev().fadeOut();
    };
    $("#protectProblem").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#protectProblem").blur(function () {
        if (!$("#protectProblem").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#protectAnswer").val()) {
        $("#protectAnswer").prev().fadeOut();
    };
    $("#protectAnswer").focus(function () {
        $(this).prev().fadeOut();
    });
    $("#protectAnswer").blur(function () {
        if (!$("#protectAnswer").val()) {
            $(this).prev().fadeIn();
        };
    });
    if ($("#captcha").val()) {
        $("#captcha").prev().fadeOut();
    };
    $("#captcha").focus(function () {
        $(this).prev().fadeOut();
        $("#captcha").next("label.repeated").hide();

    });
    $("#captcha").blur(function () {
        if (!$("#captcha").val()) {
            $(this).prev().fadeIn();
        };
    });


    //ajax提交注册信息
    $("#submit").bind("click", function () {
        regist(validate);

    });

    $("body").each(function () {
        $(this).keydown(function () {
            if (event.keyCode == 13) {          //回车也可以提交
                regist(validate);
            }
        });
    });

});




function regist(validate) {
    //校验username, password，校验如果失败的话不提交
    if (validate.form()) {
        var md5 = new MD5();

        var val_sex = $('#sexdiv input[name="sex"]:checked ').val();            //获取男女单选框值
        //alert(val_sex);
        if (val_sex != null)
            $.ajax({
                url: "regist.ashx",
                type: "post",
                async: true,
                data: {
                    userName: $("#username").val(),
                    password: md5.MD5($("#password").val()),
                    sex: val_sex,
                    protectProblem: $("#protectProblem").val(),
                    protectAnswer: $("#protectAnswer").val(),
                    captcha: $("#captcha").val()            //女 男
                },
                //dataType: "json",
                beforeSend: function () {
                   
                    //提高用户体验度
                    $('.loading').show();
                },
                success: function (data) {

                    $('.loading').hide();
                    //转化为 Json 对象
                    var dataJson = eval("(" + data + ")");

                    //alert(dataJson.code);
                    

                    if (dataJson.hasOwnProperty("code")) {
                        if (dataJson.code == 200) {
                            //注册成功
                            alert("success");
                            history.back();
                            //window.location.href = '/PassageList.aspx';
                            
                        } else if (dataJson.code == 0) {
                            //验证码有错误
                            $("#captcha").addClass("error");
                            $("#captcha").after(registError);
                            $("#captcha").next("label.repeated").text($.i18n.prop("验证码错误，请刷新重试！"));
                            reflash();
                            // registError.show();
                        } else if (dataJson.code == 1) {
                            //用户名已经被注册
                            $("#username").addClass("error");
                            $("#username").after(registError);
                            $("#username").next("label.repeated").text($.i18n.prop("用户名已被注册，请更换！"));
                            // registError.show();
                        } else {
                            //系统错误
                            $(".login-error").html($.i18n.prop("系统未知错误，请刷新！"));
                        }

                    }

                }
            });

        else {
            alert("页面溜号了。。。。");
            window.location.reload();
        }
    }

}


var Utils = function () { };

Utils.prototype.loadProperties = function (lang) {
    jQuery.i18n.properties({// 加载资浏览器语言对应的资源文件
        name: 'ApplicationResources',
        language: lang,
        path: 'resources/i18n/',
        mode: 'map',
        callback: function () {// 加载成功后设置显示内容
        }
    });
};

Utils.prototype.getScriptArgs = function () {//获取多个参数
    var scripts = document.getElementsByTagName("script"),
    //因为当前dom加载时后面的script标签还未加载，所以最后一个就是当前的script
    script = scripts[scripts.length - 1],
    src = script.src,
    reg = /(?:\?|&)(.*?)=(.*?)(?=&|$)/g,
    temp, res = {};
    while ((temp = reg.exec(src)) != null) res[temp[1]] = decodeURIComponent(temp[2]);
    return res;
};

function judgeString(str) {
    var backupStr = str;

    backupStr = $.trim(backupStr);
    var pat = new RegExp("[^a-zA-Z0-9\_\u4e00-\u9fa5]", "i");       //判断是否有非法字符
    if (backupStr && !(pat.test(backupStr)))
        return true;
    else
        return false;


}
