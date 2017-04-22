using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DelHelper
/// 删除操作
/// 1 资讯  2 活动  3短趣
/// </summary>
/// 

public class DelHelper
{

    private int CategoryId;             //删除条目的大分类
    private int DelId;                  //删除条目大分类下面的 ID
    private int OperatorId;             //进行删除操作的管理员 ID
    private int LogDeadline = 7;        //删除记录保存的阈值天数

    public DelHelper(int CateId=-1, int delId=-1, int operatorId=-1)
    {
        CategoryId = CateId;
        DelId = delId;
        OperatorId = operatorId;
    }




    /// <summary>
    /// 设置当前删除类的记录保存时间
    /// </summary>
    /// <param name="dayCounts"></param>
    /// <returns>设置成功返回真，否则假</returns>
    public bool setLogDeadline(int dayCounts)
    {
        LogDeadline = dayCounts;
        if (LogDeadline == dayCounts)
            return true;
        else
            return false;
    }


    /// <summary>
    /// 获得当前删除类的记录保存时间
    /// </summary>
    /// <returns>返回当前记录保存时间</returns>
    public int getLogDeadline()
    {
        return LogDeadline;
    }


    /// <summary>
    /// 本函数实现标记资讯， 短趣，活动 删除列，并且把记录写在 DeleteLog 中
    /// </summary>
    /// <param name="CategoryId"></param>   参数解释：待删除 ID 的所在分类   1 资讯 ； 2 活动； 3 短趣
    /// <param name="DelId"></param>        参数解释:待删除 ID 
    /// <param name="OperatorId"></param>   参数解释:本次操作的管理员 ID
    /// <returns></returns>
    public bool delItem()
    {
        try
        {

            //记录准备删除的那条记录
            if (!recordDelFlag(true))
                return false;
            using (var db = new huxiuEntities())
            {
                //new 一个 delelog 对象，进行添加操作
                DeleteLog addDelLog = new DeleteLog();
                addDelLog.DelAdminId = OperatorId;
                addDelLog.DelTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                addDelLog.Category = CategoryId;
                addDelLog.LogId = DelId;
                //添加记录表中
                db.DeleteLog.Add(addDelLog);
                //保存更改
                db.SaveChanges();
                return true;
            }
        }
        catch
        {
            return false;

        }

    }


    /// <summary>
    /// 本函数用来删除超过阈值的记录，删除原始记录和记录删除行为的记录
    /// </summary>
    /// <returns>返回 bool </returns>
    public bool dellongtimelog()
    {
        //获取当前时间
        DateTime now = DateTime.Now;
        try
        {
            using (var db = new huxiuEntities())
            {
                //查询所有超过删除阈值的条目
                var delList = from it in db.DeleteLog
                             // where (Convert.ToDateTime(it.DelTime) - now).Days > LogDeadline
                              select it;
                //遍历结果集，进行删除 DeleteLog 和 相应分类下面的条目
                foreach (var item in delList)
                {
                    //转化字符串到时间
                    DateTime tt = Convert.ToDateTime(item.DelTime);
                    //用 TimeSpan 计算相差天数
                    int tsday = Convert.ToInt32( (now-tt).TotalDays);
                    //和阈值比较
                    if (tsday > LogDeadline)
                    {
                        delSourceData(item.Category, item.LogId);
                        DeleteLog delLogId = db.DeleteLog.SingleOrDefault(a => a.DelId == item.DelId);
                        db.DeleteLog.Remove(delLogId);

                    }
                }

                db.SaveChanges();

            }
            return true;
        }
        catch
        {
            return false;
        }
       
    }

    /// <summary>
    /// 本函数删除相应分类下面的某一条
    /// </summary>
    /// <param name="completeCate"> 相应分类</param>
    /// <param name="completeId"> 分类下面的id </param>
    /// <returns>返回 bool</returns>
    private bool delSourceData(int completeCate, int completeId)
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                switch (completeCate)
                {
                    case 1://查找资讯
                        Passage delPassage = db.Passage.SingleOrDefault(a => a.PassageId == completeId);
                        db.Passage.Remove(delPassage);
                        break;
                    case 2://查找活动
                        Activity delActivty = db.Activity.SingleOrDefault(a => a.ActivityId == completeId);
                        db.Activity.Remove(delActivty);
                        break;
                    case 3://查找短趣
                        News delnews = db.News.SingleOrDefault(a => a.NewsId == completeId);
                        db.News.Remove(delnews);
                        break;
                }
                db.SaveChanges();

            }
            return true;
        }
        catch
        {
            return false;
        }
    }


   
    /// <summary>
    /// 恢复删除
    /// </summary>
    /// <returns></returns>
    public bool recoverDel()
    {
        try
        {
            //把原来表里面的数据删除标志位 置 0
            if (!recordDelFlag(false))
                return false;
            //删除记录表中的数据
            using (var db = new huxiuEntities())
            {
                DeleteLog del = (from it in db.DeleteLog
                                 where it.Category == CategoryId && it.LogId == DelId
                                 select it).FirstOrDefault();
                db.DeleteLog.Remove(del);
                db.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }


    /// <summary>
    /// 记录原始数据项的删除标记
    /// </summary>
    /// <param name="yes_or_no"></param>
    /// <returns>返回bool类型</returns>
    private bool recordDelFlag(bool yes_or_no)
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                switch (CategoryId)
                {
                    case 1://查找资讯
                        Passage delPassage = db.Passage.SingleOrDefault(a => a.PassageId == DelId);
                        delPassage.IsDel = yes_or_no;
                        break;
                    case 2://查找活动
                        Activity delActivty = db.Activity.SingleOrDefault(a => a.ActivityId == DelId);
                        delActivty.IsDel = yes_or_no;
                        break;
                    case 3://查找短趣
                        News delnews = db.News.SingleOrDefault(a => a.NewsId == DelId);
                        delnews.IsDel = yes_or_no;
                        break;
                }
                db.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

}