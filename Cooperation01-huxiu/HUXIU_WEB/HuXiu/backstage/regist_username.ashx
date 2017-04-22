<%@ WebHandler Language="C#" Class="regist_username" %>

using System;
using System.Web;
using System.Linq;

public class regist_username : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        string userName = context.Request.Form["userName"].ToString();
        string returnStr="{'code':1}";              //没有被注册，返回 code=1   注册过，返回 code=0
        if (!checkUsername(userName))
            returnStr = "{'code':0}";
        context.Response.Write(returnStr);
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
            var newQuery = from it in db.Admin
                           where it.AdminName == name
                           select it;
          
            if (newQuery.ToList().Count == 0)
                return true;
            else
                return false;
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}