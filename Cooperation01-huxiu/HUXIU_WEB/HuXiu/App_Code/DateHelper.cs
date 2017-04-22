using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DateHelper 的摘要说明
/// </summary>
public class DateHelper
{
    public DateHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public string DateStringFromNow(DateTime dt)
    {
       // dt = Convert.ToDateTime(dt.ToString("yyyy/MM/dd/HH:mm:ss"));
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