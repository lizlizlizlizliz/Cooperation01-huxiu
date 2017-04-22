<%@ WebHandler Language="C#" Class="SearchHandler" %>

using System;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Globalization;

public class SearchHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        string pageSize = context.Request["pageSize"];

        string pageIndex = context.Request["pageNumber"];

        string searchContent = context.Request["searchwords"];

        if (string.IsNullOrEmpty(pageSize) || string.IsNullOrEmpty(pageIndex) || string.IsNullOrEmpty(searchContent))
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
                var ds = (from it in db.PassageInformation where it.PassageTitle.IndexOf(searchContent) >= 0 && it.IsDel == false orderby it.PublishDate descending select it).Take(size * index).Skip(size * (index - 1));

                Console.Write(ds);

                if (index > 0)
                {
                    List<PassageInformation> passage = ds.ToList();

                    foreach (var item in passage)
                    {
                        DateTime dt;

                        DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();

                        dtFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";

                        dt = Convert.ToDateTime(item.PublishDate, dtFormat);

                        item.PublishDate = DateStringFromNow(dt);

                        item.PassageBody = UeditorHelper.NoHTML(item.PassageBody);
                    }
                    string json = JsonConvert.SerializeObject(passage);

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

     public string DateStringFromNow(DateTime dt)
    {
        TimeSpan span = DateTime.Now - dt;

        if (span.TotalDays > 60)
        {
            return dt.ToShortDateString();
        }
        else
        {
            if (span.TotalDays > 30)
            {
                return
                "1个月前";
            }
            else
            {
                if (span.TotalDays > 14)
                {
                    return
                    "2周前";
                }
                else
                {
                    if (span.TotalDays > 7)
                    {
                        return
                        "1周前";
                    }
                    else
                    {
                        if (span.TotalDays > 1)
                        {
                            return
                            string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                        }
                        else
                        {
                            if (span.TotalHours > 1)
                            {
                                return
                                string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                            }
                            else
                            {
                                if (span.TotalMinutes > 1)
                                {
                                    return
                                    string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                }
                                else
                                {
                                    if (span.TotalSeconds >= 1)
                                    {
                                        return
                                        string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                    }
                                    else
                                    {
                                        return
                                        "1秒前";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}