using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{

 

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        List<myData> a = new List<myData>(4);
        myData b = new myData();
        b.jumpUrl = "#";
        b.imgUrl = "/images/background01.png";
        a.Add(b);
        b.imgUrl = "/images/background02.png";
        a.Add(b);
        b.imgUrl = "/images/background03.png";
        a.Add(b);
        b.imgUrl = "/images/background04.png";
        a.Add(b);
        rptTurnImg.DataSource = a;
        rptTurnImg.DataBind();
        */
        if (!IsPostBack)
        {
            bindTurnImg();
            bindHotPassage();
            bindNews();
            //bindPassCate();
        }

    }/// <summary>
    /// 绑定主页图片切换
    /// </summary>
    /// <returns></returns>
    bool bindTurnImg()
    {
        //只能显示四条，一位前台只能绑定四条记录
        try
        {
        using (var db=new huxiuEntities())
        {
                var qurey = from it in db.Headline
                            where it.HisDisplay == true
                            select it;

                PagedDataSource pds = new PagedDataSource();
                pds.AllowPaging = true;
                pds.PageSize = 4;
                pds.DataSource = qurey.ToList();
                pds.CurrentPageIndex = 0;
                rptTurnImg.DataSource = pds;
                rptTurnImg.DataBind();
        }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 热文绑定
    /// </summary>
    /// <returns></returns>
 bool bindHotPassage()
    {

        try
        {
            using (var db=new huxiuEntities())
            {
                var qurey = from it in db.Passage
                            orderby it.PageViews descending
                            select it;
                PagedDataSource pds = new PagedDataSource();
                pds.AllowPaging = true;
                pds.PageSize = 4;
                pds.DataSource = qurey.ToList();
                pds.CurrentPageIndex = 0;
                rptHotPassage.DataSource = pds;
                rptHotPassage.DataBind();
                        
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 绑定短趣
    /// </summary>
    /// <returns></returns>
    bool bindNews()
    {
        try
        {
            using (var db=new huxiuEntities())
            {
                var qurey = from it in db.News
                            orderby it.NewsDate descending
                            select it;
                PagedDataSource pds = new PagedDataSource();
                pds.AllowPaging = true;
                pds.PageSize = 4;
                pds.DataSource = qurey.ToList();
                pds.CurrentPageIndex = 0;
                rptNews.DataSource = pds;
                rptNews.DataBind();
            }
            return true;
        }
        catch
        {
            return false;
        }

    }


    /// <summary>
    /// 查询资讯下面的子标签
    /// </summary>
    /// <returns></returns>
    //private bool bindPassCate()
    //{
    //    //try
    //    //{
    //    //    using (var db=new huxiuEntities())
    //    //    {
    //    //        var qurey = from it in db.PassageCategory
    //    //                    select it;
    //    //        rptPassCate.DataSource = qurey.ToList();
    //    //        rptPassCate.DataBind();
    //    //    }
    //    //    return true;
    //    //}
    //    //catch 
    //    //{
    //    //    return false;
            
    //    //}

    //}

}