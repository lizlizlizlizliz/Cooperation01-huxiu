<%@ WebHandler Language="C#" Class="UploadHandlers" %>

using System;
using System.Web;

public class UploadHandlers : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        if (context.Request["REQUEST_METHOD"] == "OPTIONS")
        {
            context.Response.End();
        }
        SaveFile();
    }
    private void SaveFile()
    {
        string basePath = "/File/";
        string name;
        basePath = System.Web.HttpContext.Current.Server.MapPath(basePath);
        HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
        if (!System.IO.Directory.Exists(basePath))
        {
            System.IO.Directory.CreateDirectory(basePath);
        }
        var suffix = files[0].ContentType.Split('/');
        //获取文件格式
        //var _suffix = suffix[1].Equals("jpeg", StringComparison.CurrentCultureIgnoreCase) ? "" : suffix[1];
        var _suffix=suffix[1];
        var _temp = System.Web.HttpContext.Current.Request["name"];
        //如果不修改文件名，则创建随机文件名
        if (!string.IsNullOrEmpty(_temp))
        {
            name = _temp;
        }
        else
        {
            Random rand = new Random(24 * (int)DateTime.Now.Ticks);
            name = rand.Next() + "." + _suffix;
        }
        //文件保存
        var full = basePath + name;
        files[0].SaveAs(full);
        var _result = "{\"jsonrpc\" : \"2.0\", \"result\" : null, \"id\" : \"" + name + "\"}";
        System.Web.HttpContext.Current.Response.Write(_result);


    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}