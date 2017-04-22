using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PCategoryAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (name.Text.Trim().Length > 0)
        {
            string cname = name.Text.Trim();
            using(var db=new huxiuEntities())
            {
                PassageCategory people = (from it in db.PassageCategory where it.CategoryName == cname select it).FirstOrDefault();

                if (people == null)
                {
                    PassageCategory person = new PassageCategory
                    {
                        CategoryName = name.Text.Trim()
                    };
                    db.PassageCategory.Add(person);
                    if (db.SaveChanges() == 1)
                    {
                        Response.Write("<script>alert('添加成功');location='PassageList.aspx'</script>");
                    }
                    else
                        Response.Write("<script>alert('添加失败请重试')</script>");
                }
                else
                    Response.Write("<script>alert('已存在该分类！')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空！')</script>");
    }
      
}