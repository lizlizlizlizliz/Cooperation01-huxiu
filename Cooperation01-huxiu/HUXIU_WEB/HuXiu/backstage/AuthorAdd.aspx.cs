using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorFile_AuthorAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(name.Text.Trim().Length>0 && Request.Form["lb"].Trim().Length>0 && summary.Text.Trim().Length > 0)
        {
            using (var db = new huxiuEntities())
            {
                Author person = new Author
                {
                    AuthorName = name.Text,
                    AuthorSex = sex.SelectedValue == "1" ? true : false,
                    AuthorImage = "/File/" + Request.Form["lb"],
                    AuthorSummary = summary.Text

                };
                db.Author.Add(person);
                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('添加作者成功');location='AuthorList.aspx'</script>");
                else
                    Response.Write("<script>alert('添加失败请重试')</script>");
            }
          
        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }
}