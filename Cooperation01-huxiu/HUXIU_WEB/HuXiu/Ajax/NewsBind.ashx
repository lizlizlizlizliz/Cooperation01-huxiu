<%@ WebHandler Language="C#" Class="NewsBind" %>

using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

public class NewsBind : IHttpHandler
{

    public class NewsInfo
    {
        public string title { set; get; }
        public string time { set; get; }
        public string content { set; get; }
        public string href { set; get; }
    }
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                var qurey = from it in db.News
                            orderby it.NewsDate descending
                            select new NewsInfo { title = it.NewsTitle, time = it.NewsDate, content = it.NewsBody, href = it.NewsLink };
                //select it;
                List<NewsInfo> newslist = qurey.ToList();
                List<NewsInfo> ans = new List<NewsInfo>();     //保存结果并且转化为 JSON 
                ans.Clear();
                for (int i = 0; i < 4; i++)             //前台数量为4
                {
                    newslist[i].time = calcDays(newslist[i].time);
                    ans.Add(newslist[i]);
                }
                //序列化 List 并且返回
                DataContractJsonSerializer json = new DataContractJsonSerializer(ans.GetType());
                string resStr = "";
                //序列化
                using (MemoryStream ms = new MemoryStream())
                {
                    json.WriteObject(ms, ans);
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



    /// <summary>
    /// 计算时间插值，小于一天显示小时否则显示天数
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private string calcDays(string str)
    {
        DateTime reTime = Convert.ToDateTime(str);
        TimeSpan ans = DateTime.Now - reTime;
        int hoursCnt = Convert.ToInt32(Math.Floor(ans.TotalHours));      //对 TimeSpan 的结果进行下取整
        if (hoursCnt > 24)
            return hoursCnt / 24 + "天前";
        else
            return hoursCnt + "小时前";

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}