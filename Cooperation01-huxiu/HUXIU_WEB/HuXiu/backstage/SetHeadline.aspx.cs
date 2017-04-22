using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class headline : System.Web.UI.Page
{
    public class MyDataInfo
    {
        public int Id { get; set; }
        public int HId { get; set; }
        public string Htitle { get; set; }
        public string Himg { get; set; }
        public string Hdeadline { get; set; }
        public bool HisDisplay { get; set; }
      
    }

    HeadlineHelper hp = new HeadlineHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else
        {

        
        divAddRecord.Visible = false;
        divEditRecord.Visible = false;
        lblCanAdd.Text = "剩余空位:" + (hp.getThreshold() - hp.getDisplayCount()).ToString();
        lblqueue.Text = "排队中：" + hp.getQueueSize().ToString();
        try
        {
            if (!IsPostBack)
            {
                BindData();
                hp.autoUpdate();
            }
        }
        catch(Exception ex)
       {
            //载入失败去404页
            Response.Write(ex);
        }
        }
    }
    

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        divAddRecord.Visible = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(txtId.Text.Trim());
        string setShowTime = "";
        try
        {
            using (var db = new huxiuEntities())
            {
                Passage ps = db.Passage.SingleOrDefault(a => a.PassageId == ID);
                if (ps == null)
                {
                    Response.Write("<script>alert('请检查 ID 的正确性！')</script>");
                    return;
                }

                if (formatTime(txtShowTime.Text.Trim(), ref setShowTime))
                {
                    if (hp.addItem(ID, setShowTime))
                    {
                        Response.Write("<script>alert('添加成功！')</script>");
                        BindData();

                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败，请检查数据的正确性！(不能重复添加,不能添加删除的条目)')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('请检查日期的正确性！以 “/ . -” 分割')</script>");
                    return;
                }
            }
        }
        catch
        {
            Response.Write("<script>alert('数据库打开异常！')</script>");

        }

    }
 

    protected void RptDisplaying_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lb_no = (Label)e.Item.FindControl("No");          //寻找label控件
            lb_no.Text = (1 + e.Item.ItemIndex).ToString();         //显示序号
            Label lb_headLeftTime = (Label)e.Item.FindControl("headLeftTime");
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string temptest = drv.Row["Hdeadline"].ToString();
            lb_headLeftTime.Text = calcLeftTime(temptest);

        }
    }

    protected void RptDisplaying_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
         if (e.CommandName == "jumpEidt")
        {
            string[] argv = e.CommandArgument.ToString().Split(',');

            divEditRecord.Visible = true;
            txtEditID.Text = argv[0];
            txtEditTime.Text = argv[1];
        }
        else if (e.CommandName == "deleteHead")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (hp.delItem(ID))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                BindData();
            }
            else
                Response.Write("<script>alert('删除失败，请重试！（注意头条数目不能少于四条）')</script>");
        }
    }

    protected void btnSubmitEdit_Click(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(txtEditID.Text.Trim());
        string setTime = "";
        if (formatTime(txtEditTime.Text.Trim(), ref setTime))
        {

            if (hp.edit(ID, setTime))
            {
                Response.Write("<script>alert('修改成功！')</script>");
                BindData();
            }
            else
                Response.Write("<script>alert('修改失败，请检查数据！')</script>");

        }
        else
            Response.Write("<script>alert('修改失败，请检查输入日期！')</script>");



    }

    protected void rptQueue_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lb_no = (Label)e.Item.FindControl("No");          //寻找label控件
            lb_no.Text = (1 + e.Item.ItemIndex).ToString();         //显示序号
            Label lb_headLeftTime = (Label)e.Item.FindControl("waitLeftTime");
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string temptest = drv.Row["Hdeadline"].ToString();
            lb_headLeftTime.Text = calcLeftTime(temptest);

        }
    }

    protected void rptQueue_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName== "goHead")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (hp.goHead(ID))
            {
                Response.Write("<script>alert('成功上头条！')</script>");
                BindData();
            }
            else
                Response.Write("<script>alert('上头条失败，请重试！（头条最多4条）')</script>");
        }else if(e.CommandName== "deleteHead")
        {
            int ID = Convert.ToInt32(e.CommandArgument);
            if (hp.delItem(ID))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                BindData();
            }
            else
                Response.Write("<script>alert('删除失败，请重试！（注意头条数目不能少于四条）')</script>");
        }

    }
    private string calcLeftTime(string dataTime)
    {
        DateTime reTime = Convert.ToDateTime(dataTime);
        TimeSpan ans = reTime - DateTime.Now;
        int daycnt =Convert.ToInt32( Math.Ceiling(ans.TotalDays));      //对 TimeSpan 的结果进行上取整
        if (daycnt>=0)
        return "剩余 " + daycnt + " 天";                  
        else
            return "超过" + daycnt + " 天";
    }
    private bool formatTime(string str, ref string res)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(str);
            res = dt.ToString("yyyy - MM - dd");
            return true;
        }
        catch
        {
            return false;
        }
    }

    private DataTable transToDataTable(IQueryable<MyDataInfo> ans)
    {

        string[] column = new string[] { "Id", "HId", "Htitle", "Himg", "Hdeadline", "HisDisplay"};
        DataTable dt = new DataTable();
        //为新标建立列明
        for (int i = 0; i < column.Length-1; i++)
        {
            DataColumn dc = new DataColumn(column[i], Type.GetType("System.String"));   //第一个参数 列名，第二个参数 列的类型
            dt.Columns.Add(dc);                                                     ///把列添加到新建表中
        }
        DataColumn dc1 = new DataColumn(column[column.Length-1], Type.GetType("System.Boolean"));
        dt.Columns.Add(dc1);
        //向 DT 中添加数据
        foreach (var item in ans)
        {
            DataRow dr = dt.NewRow();
            dr["Id"] = item.Id.ToString();
            dr["HId"] = item.HId.ToString();
            dr["Htitle"] = item.Htitle.ToString();
            dr["Himg"] = item.Himg.ToString();
            dr["Hdeadline"] = item.Hdeadline.ToString();
            dr["HisDisplay"] = item.HisDisplay;
            dt.Rows.Add(dr);
        }
        return dt;
    }

    /// <summary>
    /// 绑定数据
    /// </summary>
    /// <returns></returns>
    private bool BindData()
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                var displayHead = from it in db.Headline
                                  where it.HisDisplay == true
                                  select new MyDataInfo { Id = it.Id, HId = it.HId, Htitle = it.Htitle, Himg = it.Himg, Hdeadline = it.Hdeadline, HisDisplay = it.HisDisplay };
                var queueHead = from it in db.Headline
                                where it.HisDisplay == false
                                select new MyDataInfo { Id = it.Id, HId = it.HId, Htitle = it.Htitle, Himg = it.Himg, Hdeadline = it.Hdeadline, HisDisplay = it.HisDisplay };
                DataTable dt_head = transToDataTable(displayHead);
                DataTable dt_queue = transToDataTable(queueHead);

                RptDisplaying.DataSource = dt_head;
                rptQueue.DataSource = dt_queue;

                RptDisplaying.DataBind();
                rptQueue.DataBind();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}