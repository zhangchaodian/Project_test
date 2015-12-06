
//密码修改js匿名函数
(function () {
        $("#update_pwd").click(function () {
            var oldpwd = $("OldPwd_input").val();
            var newpwdd = $("#NewPwdd_input").val();
            var newpwd = $("#NewPwd_input").val();
            if (newpwd == '' || oldpwd == '' || newpwdd == '') {
                alert("输入项不能留空!");
            }
            else {
                if (newpwdd != newpwd) {
                    alert("两次密码输入不一致!");
                }
                else {
                    $.ajax({
                        url: "/UserManager/UpdateUserPwd",
                        type: "POST",
                        data: $("#pwdform").serialize(),
                        datatype: "json",
                        success: function (data) {
                            if (data == 'a') {
                                alert("修改密码成功!");
                            }
                            else if (data == 'b') {
                                alert("原密码输入错误!");
                            }
                            else if (data == 'c') {
                                alert("密码修改失败!");
                            }
                        }
                    });
                }
            }

        });

    })();


    (function () {
        $("#UpdateUserInfo_button").click(function () {
            var nickname = $("#nickname").val();
            var position = $("#position").val();
            var phone = $("#phone").val();
            var email = $("#email").val();
            function match_str(reg, str){
                if (reg.test(str)) {
                    return true;
                }
                else {
                    return false;
                }
            }
            var phone_match = match_str(/^1[358][0-9]{8}[0-9]$/, phone);
            var email_match = match_str(/^([a-zA-Z0-9]+)@[a-zA-Z0-9]+\.([a-zA-Z0-9]+)$/,email);
            if(nickname == '' || position == '' || phone == '' || email=='')
            {
                alert("输入项不能留空!");

            }
            else{
                if(!phone_match)
                {
                    alert("手机号码格式为13、15、18开头的11位纯数字");
                }
                else{
                    if(!email_match)
                    {
                        alert("邮箱格式不对!");
                    }
                    else
                    {
                        $.ajax({
                            url: "/UserManager/UpdateUserInfo",
                            type: "POST",
                            data: $("#UserInfoForm").serialize(),
                            datatype: "json",
                            success: function (data) {
                                if (data) {
                                    alert("信息修改成功!");
                                }
                                else {
                                    alert("信息修改失败!");
                                }
                            }
                        });
                    }
                }
            }
        });
    })();