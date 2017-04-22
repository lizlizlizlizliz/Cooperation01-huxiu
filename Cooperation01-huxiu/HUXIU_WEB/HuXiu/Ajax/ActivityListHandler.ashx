<%@ WebHandler Language="C#" Class="ActivityListHandler" %>

using System;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;



public class ActivityListHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string pageSize = context.Request["pageSize"];
        string pageIndex = context.Request["pageNumber"];
        if (string.IsNullOrEmpty(pageSize) || string.IsNullOrEmpty(pageIndex))
        {
            context.Response.Write("");
        }
        else
        {
            //请结合实际自行取分页数据，可调用分页存储过程  
            int index = Convert.ToInt32(pageIndex);
            int size = Convert.ToInt32(pageSize);

            using (var db = new huxiuEntities())
            {
                var select =( from it in db.Activity orderby it.ActivityWhen descending where it.IsDel==false select it).Take(size * index).Skip(size * (index - 1));
                if (index > 0)
                {

                    List<Activity> person = select.ToList();
                    foreach (var item in person)
                    {
                        item.ActivityWhat = UeditorHelper.NoHTML(item.ActivityWhat);
                        item.ActivityWhen = DateTime.Compare(Convert.ToDateTime(item.ActivityWhen), DateTime.Now) > 0 ? "进行中" : "已结束";
                    }
                    string json = JsonConvert.SerializeObject(person);
                        context.Response.Write(json);

                }
            }

            //Take是从序列的开头返回指定数量的连续元素，也就是说()里面放的数是多少就返回多少条数据
            //Skip是跳过序列中指定的元素，返回剩余的，也就是说()里面放的数是多少，它就跳过多少

        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}