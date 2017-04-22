using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsFile_NewsEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Regex r = new Regex("^[1-9]d*|0$");
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null && r.IsMatch(Request.QueryString["id"]))//要把是否为空放前面
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                using (var db = new huxiuEntities())//把内容显示出来
                {
                    News person = (from it in db.News where it.NewsId == id select it).FirstOrDefault();
                    if (person != null)
                    {
                        title.Text = person.NewsTitle;//标题

                        content.Text = person.NewsBody;//内容

                        dates.Text = person.NewsDate.ToString();//发布时间

                        link.Text = person.NewsLink;//链接
                    }
                    else
                        Response.Write("<script>alert('地址栏有误');location='NewsList.aspx'</script>");
                }

            }
            else
            Response.Write("<script>alert('地址栏有误');location='NewsList.aspx'</script>");
        }
        
    }
    
    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        if (title.Text.Trim().Length > 0 && content.Text.Trim().Length > 0 && link.Text.Trim().Length > 0)
        {
            //string Pattern = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&amp;%\$#\=~_\-@]*)*$";
            string Pattern = @"(http|https)://[^\s]*";
            Regex r = new Regex(Pattern);
            if (r.IsMatch(link.Text.Trim()))
            {
                using (var db = new huxiuEntities())//修改短趣
                {
                    News person = (from it in db.News where it.NewsId == id select it).FirstOrDefault();

                    if (person.NewsTitle == title.Text.Trim() && person.NewsBody == content.Text && person.NewsLink == link.Text.Trim())
                        Response.Write("<script>alert('未修改');location='NewsEditor.aspx?id=" + id + "'</script>");
                    else
                    {
                        person.NewsTitle = title.Text.Trim();//标题
                        person.NewsBody = content.Text;//内容
                                                       //  person.NewsDate = Convert.ToDateTime(dates.Text);//发布时间不做修改
                        person.NewsLink = link.Text.Trim();//超链接
                                                           //  person.IsDel = false;//是否删除

                        if (db.SaveChanges() == 1)
                        Response.Write("<script>alert('编辑成功');location='NewsEditor.aspx?id=" + id + "'</script>");
                        else
                         Response.Write("<script>alert('编辑失败请重试')</script>");
                    }
                }
            }
            else
                Response.Write("<script>alert('格式错误')</script>");
        }

        else
            Response.Write("<script>alert('不能为空')</script>");
    }

    protected void lbtnEditor_Click(object sender, EventArgs e)
    {
        title.Enabled = true;
        content.Enabled = true;
        link.Enabled = true;
        lbtnEditor.Visible = false;
        btnEditor.Visible = true;
    }

}