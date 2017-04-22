<%@ WebHandler Language="C#" Class="getActHead" %>

using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

public class getActHead : IHttpHandler {
         public class NewsInfo
    {
        public string URL { set; get; }
        public int ID { set; get; }
      
    }

    public void ProcessRequest (HttpContext context) {
        try
        {
            using (var db = new huxiuEntities())
            {
                var qurey = from it in db.Activity
                            where it.IsHeadline == true
                            select new NewsInfo { URL = it.ActivityImage, ID = it.ActivityId};
                List<NewsInfo> actHead = qurey.ToList();
                //序列化 List 并且返回
                DataContractJsonSerializer json = new DataContractJsonSerializer(actHead.GetType());
                string resStr = "";
                //序列化
                using (MemoryStream ms = new MemoryStream())
                {
                    json.WriteObject(ms, actHead);
                    resStr = Encoding.UTF8.GetString(ms.ToArray());
                }
                context.Response.Clear();
                context.Response.Write(resStr);
            }
        }
        catch
        {

            //失败返回特定字符
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}