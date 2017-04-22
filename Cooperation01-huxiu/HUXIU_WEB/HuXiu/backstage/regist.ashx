<%@ WebHandler Language="C#" Class="regist" %>

using System;
using System.Web;
using System.Linq;
using System.Web.SessionState;


public class regist : IHttpHandler,IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //获取所有 POST 回来的值
        string userName = context.Request.Form["userName"].ToString().Trim();
        string userPwd_md5 = context.Request.Form["password"].ToString().Trim(); ;
        string sex = context.Request.Form["sex"].ToString().Trim();
        string protectProblem = context.Request.Form["protectProblem"].ToString().Trim();
        string protectAnswer = context.Request.Form["protectAnswer"].ToString().Trim();
        string captcha = context.Request.Form["captcha"].ToString().Trim();
        string result = "{'code':";
        string trueVali = context.Session["Vnum"].ToString();
        bool anyBlank=false;
        if (userName == "" || userPwd_md5 == "" || sex == "" || protectProblem == "" || protectAnswer == "" || captcha == "")
                anyBlank = true;



        //验证验证码,错误返回 errorCode=0
        if (captcha ==trueVali && !anyBlank)
        {
            //判断用户名是否存在，存在返回 errorCode=1;
            if (checkUsername(userName))
            {
                //存入密码，aJax 传回来的密码已经进行了 md5 加密，继续加盐放在数据库
                try
                {
                    using (var db = new huxiuEntities())
                    {
                        // new 一个 admin 对象，进行添加数的操作
                        Admin adminTable = new Admin();
                        adminTable.AdminName = userName;
                        adminTable.AdminPassword = Security.SHA1_Hash(userPwd_md5);
                        adminTable.AdminSex = (sex == "男") ? true : false;
                        adminTable.AdminProblem = protectProblem;
                        adminTable.AdminAnswer = protectAnswer;
                        adminTable.AdminImage = "./images/icon-eg.jpeg";
                        //将数据添加到 admin 表中
                        db.Admin.Add(adminTable);
                        //保存更改
                        db.SaveChanges();
                    }
                    result += "200";
                    
                }
                catch
                {
                    //未知错误返回 errorCode=404
                    result += "500";
                }

            }
            else
                result += "1";
        }
        else
            result += "0";

        result += "}";
            //强制删除本次验证码提交，防止爆破
            context.Session["Vnum"]="laji";
        context.Response.Write(result);

    }
    /// <summary>
    /// 检测用户名是否被注册过
    /// </summary>
    /// <param name="name"></param>         待检测用户名
    /// <returns></returns>                 没被注册返回：true     已经被注册返回：flase
    public bool checkUsername(string name)
    {
        using (var db = new huxiuEntities())
        {
            //创建 linq 查询结果集（dataset）
            var newQuery = from it in db.Admin
                           where it.AdminName == name
                           select it;

            if (newQuery.ToList().Count == 0)
                return true;
            else
                return false;
        }
    }



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}