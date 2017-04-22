using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recovery : System.Web.UI.Page
{

    /// <summary>
    /// MYDataInfo 是作为 linq 结果集的返回对象的数据类型
    /// </summary>
    public class MyDataInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string AdminName { get; set; }
        public int AdminId { get; set; }
        public int PassageCate { get; set; }
        public string Link { get; set; }
        public int DelCate { get; set; }
    }

    //初次查询即结果,用静态变量才能保存上一次在大类下的查询结果，否则刷新页面后就清空了，会出错
    static protected DataTable _DT = new DataTable();
    //分页 DataTable
    static protected DataTable pds_dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else if (!IsPostBack)
        {
            //大分类显示“请选择”
            ListItem lt = new ListItem();
            lt.Text = "-->请选择类别<--";
            lt.Selected = true;
            DplistCategory.Items.Add(lt);


            //默认显示资讯的
            _DT = RptRecoverListBind("资讯");
            pds_dt = _DT.Copy();
            JumpPage(pds_dt, 1);

            //删除过期记录
            DelHelper del = new DelHelper();
                del.dellongtimelog();

            
        }
        //Response.Write("<script>location.href='Recovery.aspx'</script>");
      

    }

    protected void DplistCategory_TextChanged(object sender, EventArgs e)
    {
        if (DplistCategory.SelectedValue != "-- > 请选择类别 < --")
        {


            if (DplistCategory.SelectedValue == "资讯")
            {
                //绑定数据
                _DT = RptRecoverListBind("资讯");
                pds_dt = _DT.Copy();
                JumpPage(pds_dt, 1);
                //显示资讯下面的详细标签
                using (var db = new huxiuEntities())
                {
                    var DptDataSource = from it in db.DeleteLog
                                        where it.Category==1
                                        join disId in db.Passage                          
                                        on it.LogId equals disId.PassageId
                                        join itOk in db.PassageCategory
                                        on disId.PassageCategory equals itOk.PCategoryId
                                        select itOk.CategoryName;
                    HashSet<string> hs = new HashSet<string>(DptDataSource);//去出重复字符串

                    DplistPassageLable.DataSource = hs.ToList();
                    DplistPassageLable.DataBind();
                }
                DplistPassageLable.Visible = true;
                ListItem lt = new ListItem();
                lt.Text = "-->请选择类别<--";
                lt.Selected = true;
                DplistPassageLable.Items.Add(lt);
             
            }
            else
            {

                //绑定数据
                _DT = RptRecoverListBind(DplistCategory.SelectedValue);
                pds_dt = _DT.Copy();
                JumpPage(pds_dt, 1);
                DplistPassageLable.Visible = false;

            }
        }
        else  //请选默认显示 资讯 类
        {
            //绑定数据
            pds_dt = RptRecoverListBind("资讯");
            JumpPage(pds_dt, 1);
            DplistPassageLable.Visible = false;

        }

    }



    protected void DplistPassageLable_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DplistPassageLable.SelectedValue!= "-- > 请选择类别 < --")
        {

            pds_dt = SelectPassageLable(DplistPassageLable.SelectedValue);
            JumpPage(pds_dt, 1);
        }
        else
        {
            //绑定数据
            DplistCategory.Text = "资讯";
            pds_dt = RptRecoverListBind("资讯");
            JumpPage(pds_dt, 1);
            DplistPassageLable.Visible = false;
        }    
    }





    /// <summary>
    /// 生成第一个大分类下的所有删除的项目
    /// </summary>
    /// <param name="Categroy"></param>
    /// <returns>返回一个 DataTable 进行分页操作</returns>
    protected DataTable RptRecoverListBind(string Categroy)
    {   //1为资讯，2为活动，3为短趣


        using (var db = new huxiuEntities())
        {
            //结果：   资讯标题（id 绑定到跳转链接） 资讯下面的小分类  删除时间  管理员姓名（绑定id到跳转管理员界面）
            if (Categroy == "资讯")
            {
                var ans = from it in db.DeleteLog                            //在删除记录表中查找大类
                          where it.Category == 1
                          orderby it.DelTime descending                      //降序排序
                          join disId in db.Passage                           //联合查询，显示资讯 Id Title
                          on it.LogId equals disId.PassageId
                          join adminInfo in db.Admin                         //联合查询，显示管理员的名字和 Id
                          on it.DelAdminId equals adminInfo.AdminId
                          select new MyDataInfo { Id = disId.PassageId, Title = disId.PassageTitle, PassageCate = disId.PassageCategory, Time = it.DelTime, AdminName = adminInfo.AdminName, AdminId = it.DelAdminId, Link = "#",DelCate=1 };
            
                return transToDataTable(ans);
            }
            //结果：   活动标题（id 绑定到跳转链接）  删除时间  管理员姓名（绑定id到跳转管理员界面）
            if (Categroy == "活动")
            {
                var ans = from it in db.DeleteLog                            //在删除记录中查找大类
                          where it.Category == 2
                          orderby it.DelTime descending                      //降序排列
                          join disId in db.Activity
                          on it.LogId equals disId.ActivityId                //联合查询，显示活动 id Title
                          join adminInfo in db.Admin
                          on it.DelAdminId equals adminInfo.AdminId          //联合查询，显示管理员的名字和 Id
                          select new MyDataInfo { Id = disId.ActivityId, Title = disId.ActivityTitle, Time = it.DelTime, AdminName = adminInfo.AdminName, AdminId = it.DelAdminId, PassageCate = -1, Link = "#", DelCate =2 };

                return transToDataTable(ans);
            }
            //结果：   短趣标题（ 绑定 link 到跳转链接）  删除时间  管理员姓名（绑定id到跳转管理员界面）
            else
            {
                var ans = from it in db.DeleteLog                            //在删除记录中查找大类
                          where it.Category == 3
                          orderby it.DelTime descending                      //降序排列
                          join disId in db.News
                          on it.LogId equals disId.NewsId                    //联合查询，显示短趣 id Title
                          join adminInfo in db.Admin
                          on it.DelAdminId equals adminInfo.AdminId          //联合查询，显示管理员的名字和 Id
                          select new MyDataInfo { Id = disId.NewsId, Title = disId.NewsTitle, Link = disId.NewsLink, Time = it.DelTime, AdminName = adminInfo.AdminName, AdminId = it.DelAdminId, PassageCate = -1, DelCate =3 };

                return transToDataTable(ans);
            }
        }
    }


    /// <summary>
    /// 转换 Linq 结果集到 DataTable
    /// </summary>
    /// <param name="ans"></param>
    /// <returns>返回转换后的 Dt</returns>
    protected DataTable transToDataTable(IQueryable<MyDataInfo> ans)
    {

        string[] column = new string[] { "Id", "Title", "Time", "AdminName", "AdminId", "PassageCate", "Link", "DelCate" };
        DataTable dt = new DataTable();
        //为新标建立列明
        for (int i = 0; i < column.Length; i++)
        {
            DataColumn dc = new DataColumn(column[i], Type.GetType("System.String"));   //第一个参数 列名，第二个参数 列的类型
            dt.Columns.Add(dc);                                                     ///把列添加到新建表中
        }
        //向 DT 中添加数据
        foreach (var item in ans)
        {
            DataRow dr = dt.NewRow();
            dr["Id"] = item.Id.ToString();
            dr["Title"] = item.Title.ToString();
            dr["Time"] = item.Time.ToString();
            dr["AdminName"] = item.AdminName.ToString();
            dr["AdminId"] = item.AdminId.ToString();
            dr["PassageCate"] = item.PassageCate.ToString();
            dr["Link"] = item.Link.ToString();
            dr["DelCate"] = item.DelCate;
            dt.Rows.Add(dr);
        }
        return dt;
    }

    /// <summary>
    /// 在大的资讯分类里面筛选出小的资讯分类
    /// </summary>
    /// <param name="PassageLable"></param>
    /// <returns>返回一个 DataTable 进行分页操作</returns>
    protected DataTable SelectPassageLable(string PassageLable)
    {
        int PassageLableId = 1;
        //遍历资讯分类表，得到分类名的id
        using (var db = new huxiuEntities())
        {
            var IdList = from it in db.PassageCategory
                         select it;
            foreach (var item in IdList)
            {
                if (item.CategoryName == PassageLable)
                    PassageLableId = item.PCategoryId;
            }

        }
        // 复制一个分类下建立好的 DataTable ,方便之后换了分类继续使用
        DataTable copy_dt = new DataTable();
        string filterStr = "PassageCate=" + PassageLableId.ToString();
        DataRow[] rows = _DT.Select(filterStr);     //筛选符合条件的数据
        copy_dt = _DT.Clone();                      //克隆 _DT 的结构 
        foreach (DataRow row in rows)
            copy_dt.ImportRow(row);                 //复制行数据到 copy_dt 中

        return copy_dt;

    }


    /// <summary>
    /// 进行分页操作
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="currentPage"></param>
    protected void JumpPage(DataTable dt, int currentPage)
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.DataSource = dt.DefaultView;
        lbTotal.Text = pds.PageCount.ToString();
        if(pds.DataSourceCount>pds.PageSize)
        divTool.Visible = true;
        lblCount.Text = "共有记录："+pds.DataSourceCount.ToString()+"条";
        pds.CurrentPageIndex = currentPage - 1;
        RptRecoverList.DataSource = pds;
        RptRecoverList.DataBind();
    }
    /// <summary>
    /// 为表格增加序号列
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptRecoverList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lb_no = (Label)e.Item.FindControl("No");          //寻找label控件
            lb_no.Text = (1 + e.Item.ItemIndex).ToString();         //显示序号
        }
    }

    protected void RptRecoverList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "jumpPage")
        {
            string[] argv = e.CommandArgument.ToString().Split(',');
            string id = argv[0];
            string link = argv[1];
            if (link == "#")
            {
                string postUrl = "";
                //说明用 id 来跳转详情页面
                if (DplistCategory.SelectedValue=="资讯")             //跳资讯
                postUrl = "./PassageEditor.aspx?id=" + id;
                else                                                //跳活动
                    postUrl = "./ActivityEditor.aspx?id=" + id;

                Response.Write("<script>window.open('" + postUrl + "','_blank')</script>");

            }
            else
            {
                //说明是短趣，用链接跳转
                //link 必须以 http://开头
                Response.Write("<script>window.open('" + link + "','_blank')</script>");


            }
        }
        else if (e.CommandName == "jumpAdmin")
        {
            //打开管理员信息的窗口---弹窗形式
            string ID = e.CommandArgument.ToString();
            string link = "./AdminInfo.aspx?id="+ID;
            Response.Write("<script language='javascript'>window.open('" + link + "', 'newwindow', 'height=600, width=300, top='+Math.round((window.screen.height-200)/2)+',left='+Math.round((window.screen.width-300)/2)+', toolbar=no,menubar = no, scrollbars = no, resizable = no, location = no, status = no')</script>");
        }
        else if (e.CommandName == "recover")
        {
            string[] argv = e.CommandArgument.ToString().Split(',');
            int id = Convert.ToInt32(argv[0]);
            int category = Convert.ToInt32(argv[1]);
            //调用 DelHelper 类
            DelHelper delOp = new DelHelper(category, id);
            delOp.recoverDel(); 
            //刷新表格
            _DT = RptRecoverListBind(DplistCategory.SelectedValue);
            pds_dt = _DT.Copy();
            JumpPage(pds_dt, 1);
            DplistCategory.SelectedValue = DplistCategory.Text;
        }
    }


    //分页按钮事件

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        JumpPage(pds_dt, 1);
        lbNow.Text = "1";


    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        if (lbNow.Text == "1")
        {
            JumpPage(pds_dt, 1);
            lbNow.Text = "1";
        }
        else
        {
            lbNow.Text = (Convert.ToInt32(lbNow.Text) - 1).ToString();
            JumpPage(pds_dt, Convert.ToInt32(lbNow.Text));

        }

    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        if (lbNow.Text == lbTotal.Text)
        {
            JumpPage(pds_dt, 1);
            lbNow.Text = "1";
        }
        else
        {
            lbNow.Text = (Convert.ToInt32(lbNow.Text) + 1).ToString();
            JumpPage(pds_dt, Convert.ToInt32(lbNow.Text));
        }

    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        JumpPage(pds_dt, Convert.ToInt32(lbTotal.Text));
        lbNow.Text = lbTotal.Text;

    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        if ((Convert.ToInt32(txtJump.Text.Trim()) < 1) || (Convert.ToInt32(txtJump.Text.Trim()) > Convert.ToInt32(lbTotal.Text.Trim())))
        {
            JumpPage(pds_dt, 1);
            lbNow.Text = "1";

        }
        else
        {
            JumpPage(pds_dt, Convert.ToInt32(txtJump.Text.Trim()));
            lbNow.Text = txtJump.Text.Trim();

        }

    }



}