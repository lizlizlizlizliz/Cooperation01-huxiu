using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivityEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Regex r = new Regex("^[1-9]d*|0$");
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else if (!IsPostBack)
        {
            if ( Request.QueryString["id"] != null&&r.IsMatch(Request.QueryString["id"]) )//要把是否为空放前面
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);//获取id

                using (var db = new huxiuEntities())
                {
                    Activity person = (from it in db.Activity where it.ActivityId == id select it).FirstOrDefault();

                    if (person != null)
                    {

                        title.Text = person.ActivityTitle;//标题

                        content.Text = person.ActivityWhat;//内容

                        image.ImageUrl = person.ActivityImage;//封面

                        when.Text = person.ActivityWhen.ToString();//时间

                        requestedDeliveryDateTextBox.Text = person.ActivityWhen.ToString();//时间

                        where.Text = person.ActivityWhere;//地点

                        tips.Text = person.ActivityTips;//备注
                    }
                    else
                        Response.Write("<script>alert('地址栏有误');location='ActivityList.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('地址栏有误');location='ActivityList.aspx'</script>");
        }
    }

    /// 日期选择图标被点击
    /// </summary>
    protected void ImageButton_Click(object sender, EventArgs eventArgs)
    {
        //控制日历的显示与隐藏
            calendar.Visible = !calendar.Visible;
    }

    /// <summary>
    /// 选择日期，通过AJAX触发
    /// </summary>
    protected void RequestedDeliveryDateCalendar_SelectionChanged(object sender, EventArgs eventArgs)
    {
        requestedDeliveryDateTextBox.Text = requestedDeliveryDateCalendar.SelectedDate.ToShortDateString();

        // 隐藏日历
        calendar.Visible = false;

        //设置日历下textbox的焦点，方便用户输入。移除或改变下行代码设置为您自己的控件
        
    }
    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        if (title.Text.Trim().Length > 0 && content.Text.Trim().Length > 0 && where.Text.Length > 0 && tips.Text.Length > 0)
        {
            using (var db = new huxiuEntities())
            {

                Activity person = (from it in db.Activity where it.ActivityId == id select it).FirstOrDefault();

                person.ActivityTitle = title.Text;

                person.ActivityWhat =content.Text.Trim();//富文本编辑器里的内容

                if (Request.Form["lb"] != "")
                    person.ActivityImage = "/File/" + Request.Form["lb"];

                if (requestedDeliveryDateTextBox.Text.Trim().Length > 0)
                    person.ActivityWhen = Convert.ToDateTime( requestedDeliveryDateTextBox.Text).ToString("yyyy-MM-dd");

                person.ActivityWhere = where.Text;

                person.ActivityTips = tips.Text;

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('编辑成功');location='ActivityEditor.aspx?id="+id+"'</script>");
                else
                    Response.Write("<script>alert('编辑失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }

    protected void lbtnEditor_Click(object sender, EventArgs e)
    {
        title.Enabled = true;
        lbtnEditor.Visible = false;
        content.Enabled = true;
        UpdatePanel1.Visible = true;
        when.Visible = false;//活动时间标签隐藏
        where.Enabled = true;
        tips.Enabled = true;
        btnEditor.Visible = true;
        uploader.Style.Add("display", "block");//把后台div显示出来

    }
}