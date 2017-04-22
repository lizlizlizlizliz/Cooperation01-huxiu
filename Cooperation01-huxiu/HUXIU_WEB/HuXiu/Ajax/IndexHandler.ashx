<%@ WebHandler Language="C#" Class="IndexHandler" %>

using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.Objects;
using System.Web.UI.WebControls;

public class IndexHandler : IHttpHandler {

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
                if (index > 0)
                {
                    //var select =( from it in db.Activity orderby it.ActivityWhen select it).Take(size * index).Skip(size * (index - 1));
                    List < Passage_Author > select= (from it in db.Passage_Author orderby it.PublishDate descending where it.IsDel==false select it).Take(size * index).Skip(size * (index - 1)).ToList();

                    DateHelper dt = new DateHelper();
                    foreach(var item in select)
                    {
                        item.PublishDate = dt.DateStringFromNow(Convert.ToDateTime(item.PublishDate));
                    }
                    string json = JsonConvert.SerializeObject(select);
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