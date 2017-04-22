using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivityFile_ActivityAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");


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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (title.Text.Trim().Length > 0 && Request.Form["lb"].Length>0 &&  requestedDeliveryDateTextBox.Text.Trim().Length>0 && content.Text.Trim().Length > 0 && where.Text.Trim().Length > 0 && tips.Text.Trim().Length > 0)
        {
            using (var db = new huxiuEntities())
            {
                Activity person = new Activity
                {
                    ActivityTitle = title.Text,

                    ActivityWhat =content.Text.Trim(),

                    ActivityImage = "/File/" + Request.Form["lb"],//活动封面

                    ActivityWhen = Convert.ToDateTime(requestedDeliveryDateTextBox.Text).ToString("yyyy-MM-dd"),

                    ActivityWhere = where.Text,

                    ActivityTips = tips.Text
                };

                db.Activity.Add(person);

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('添加成功');location='ActivityList.aspx'</script>");
                else
                    Response.Write("<script>alert('添加失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空')</script>");

    }
}