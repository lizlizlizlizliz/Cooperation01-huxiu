using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Headline 的摘要说明
/// </summary>
public class HeadlineHelper
{
    public HeadlineHelper()
    {
        threshold = 6;
        queueSize = 0;                              //记录队列大小
        displayCount = 0;                           //记录显示条数
        using (var db = new huxiuEntities())
        {
            var queryList = from it in db.Headline
                            select it;

            foreach (var it in queryList)
            {
                if (it.HisDisplay)
                    displayCount++;
                else
                    queueSize++;
            }

        }
    }
    /// <summary>
    /// 添加一条头条
    /// </summary>
    /// <param name="hId"></param>
    /// <param name="showTime"></param>
    /// <returns></returns>
    public bool addItem(int hId, string showTime)
    {
        if (!isExpire(showTime))
        {
            try
            {
                using (var db = new huxiuEntities())
                {
                    //是否重复
                    Headline isRpt = db.Headline.SingleOrDefault(a => a.HId == hId);
                    if (isRpt != null)
                        return false;
                    //添加新头条
                    Passage pasInfo = db.Passage.SingleOrDefault(a => a.PassageId == hId && a.IsDel==false);
                    if (pasInfo == null)
                        return false;
                    Headline headSave = new Headline();
                    headSave.HId = hId;
                    headSave.Htitle = pasInfo.PassageTitle;
                    headSave.Himg = pasInfo.PassageImage;
                    headSave.Hdeadline = showTime;
                    headSave.HisDisplay = false;
                    db.Headline.Add(headSave);
                    db.SaveChanges();
                }
                queueSize++;
                return true;
            }
            catch
            {
                return false;
            }
        }
        else
            return false;
    }

    /// <summary>
    /// 删除头条
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool delItem(int id)
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                Headline delHead = db.Headline.SingleOrDefault(a => a.Id == id);
                if (!delHead.HisDisplay)            //如果删除队列中的项目，队列数量减一
                    queueSize--;
                else if (displayCount <= 4)         //最少头条保留4条
                    return false;
                db.Headline.Remove(delHead);
                db.SaveChanges();
            }
            displayCount--;
            return true;

        }
        catch
        {
            return false;

        }
    }

    /// <summary>
    /// 队列到头条
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool goHead(int id)
    {
        if (displayCount >= threshold)               //头条已经达到预期展示数量，不能增加
            return false;
        try
        {
            using (var db = new huxiuEntities())
            {
                Headline goHead = db.Headline.Single(a => a.Id  == id);
                goHead.HisDisplay = true;
                db.SaveChanges();
            }
            displayCount++;
            queueSize--;
            return true;

        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 编辑属于队列中的等待头条
    /// </summary>
    /// <param name="id"></param>
    /// <param name="showTime"></param>
    /// <returns></returns>
    public bool edit(int id, string showTime)
    {
        if (!isExpire(showTime))
        {

            try
            {
                using (var db = new huxiuEntities())
                {
                    Headline goHead = db.Headline.Single(a => a.Id == id);
                    goHead.Hdeadline = showTime;
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        else
            return false;
    }

    public bool setThreshold(int newThreshold)
    {
        if (newThreshold < threshold)               //设置小于当前显示阈值需要先删除正在显示的项目，数量低于新阈值
            return false;
        threshold = newThreshold;
        return true;
    }
    public int getThreshold()
    {
        return threshold;
    }

    public int getDisplayCount()
    {
        return displayCount;
    }

    public int getQueueSize()
    {
        return queueSize;
    }
    /// <summary>
    /// 自动更新头条：有过期的就从队列里面顶上去；如果队列为空就把过期的都延长1天；如果过期的数量超过队列数量，就补充能补充的，其他的过期条目删除。
    /// </summary>
    /// <returns></returns>
    public bool autoUpdate()
    {
        List<int> expireID = new List<int>();             //保存过期的 ID
        List<int> queueID = new List<int>();              //保存等待显示的头条 ID
        expireID.Clear();
        queueID.Clear();

        try
        {
            using (var db = new huxiuEntities())
            {
                var item = from it in db.Headline
                           select it;
                foreach (var it in item)
                {
                    if (!it.HisDisplay)                              //记录下来所有队列中的ID
                        queueID.Add(it.Id);
                    else if (isExpire(it.Hdeadline))                //记录过期的 ID
                        expireID.Add(it.Id);
                }
            }
            if (expireID.Count == 0)                                 //显示的头条没有过期的
                return true;
            else                                                     //有过期的
            {
                using (var db = new huxiuEntities())
                {
                    if (min(queueID.Count, expireID.Count) <= 0)         //如果队列为空，没有可以补充的给现有的所有头条赋予现在时间另外延长1天
                    {

                        for (int i = 0; i < expireID.Count; i++)
                        {
                            int t = expireID[i];
                            Headline addTime = db.Headline.SingleOrDefault(a => a.Id ==t);
                            addTime.Hdeadline = addOneDay();
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        //删除较小的，用队列值补充
                        int t = min(queueID.Count, expireID.Count);
                        for (int i = 0; i < t; i++)
                        {
                            int tt = expireID[0];
                            Headline delH = db.Headline.SingleOrDefault(a => a.Id == tt);
                            db.Headline.Remove(delH);
                            tt = queueID[0];
                            Headline doHead = db.Headline.SingleOrDefault(a => a.Id == tt);
                            doHead.HisDisplay = true;
                            //删除记录
                            expireID.RemoveAt(0);
                            queueID.RemoveAt(0);
                        }
                        int cnt = expireID.Count;
                        if (expireID.Count > 0)                                            //如果队列没了，但是头条还有过期的，就把过期的直接删除
                            for (int i = 0; i < cnt; i++)
                            {
                                int tt = expireID[0];
                                Headline delH = db.Headline.SingleOrDefault(a => a.Id == tt);
                                db.Headline.Remove(delH);
                                displayCount--;
                                expireID.RemoveAt(0);
                            }
                    }
                    db.SaveChanges();
                }
                return true;

            }
        }
        catch
        {
            
            return false;
        }
    }


    /// <summary>
    /// 判断给定日期和现在相比是否过期
    /// </summary>
    /// <param name="recordTime"></param>
    /// <returns></returns>
    private bool isExpire(string recordTime)
    {
        DateTime reTime = Convert.ToDateTime(recordTime);
        TimeSpan ans = reTime - DateTime.Now;
        if (ans.TotalDays < 0)
            return true;
        else
            return false;
    }
    private int min(int a, int b)
    {
        return a < b ? a : b;
    }
    private string addOneDay()
    {
        DateTime dt =DateTime.Now;
        return dt.AddDays(1).ToString("yyyy-MM-dd");
    }



    private int threshold;
    private int queueSize;
    private int displayCount;
}