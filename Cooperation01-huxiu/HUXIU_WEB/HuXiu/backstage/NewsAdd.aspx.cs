using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewsFile_NewsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (title.Text.Trim().Length > 0 && content.Text.Trim().Length > 0 && link.Text.Trim().Length > 0)
        {
            //(http|https)://[^\s]*
            //string Pattern = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&amp;%\$#\=~_\-@]*)*$";
            string Pattern = @"(http|https)://[^\s]*";

            Regex r = new Regex(Pattern);
            if (r.IsMatch(link.Text.Trim()))
            {
                using (var db = new huxiuEntities())
                {
                    News person = new News
                    {
                        NewsTitle = title.Text.Trim(),
                        NewsBody = content.Text.Trim(),
                        NewsDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), //发表时间
                        NewsLink = link.Text.Trim(),
                        IsDel = false
                    };

                    db.News.Add(person);

                    if (db.SaveChanges() == 1)
                        Response.Write("<script>alert('添加成功');location='NewsList.aspx'</script>");
                    else
                        Response.Write("<script>alert('添加失败请重试')</script>");
                }
            }
            else
                Response.Write("<script>alert('请输入正确的网址')</script>");

        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }
     
}