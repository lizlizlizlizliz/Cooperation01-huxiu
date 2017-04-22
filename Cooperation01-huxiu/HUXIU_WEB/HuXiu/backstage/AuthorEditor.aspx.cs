using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorFile_AuthorEditor : System.Web.UI.Page
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

                using (var db = new huxiuEntities())
                {
                    Author person = (from it in db.Author where it.AuthorId == id select it).FirstOrDefault();

                    if (person != null)
                    {
                        name.Text = person.AuthorName;

                        image.ImageUrl = person.AuthorImage;

                        sex.SelectedValue = person.AuthorSex.ToString();

                        summary.Text = person.AuthorSummary;
                    }
                    else
                        Response.Write("<script>alert('地址栏有误');location='AuthorList.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('地址栏有误');location='AuthorList.aspx'</script>");
        }
    }

    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        if (name.Text.Trim().Length > 0 && summary.Text.Trim().Length > 0)
        {
            using (var db = new huxiuEntities())
            {
                Author person = (from it in db.Author where it.AuthorId == id select it).FirstOrDefault();

                person.AuthorName = name.Text;

                person.AuthorSex = sex.SelectedValue == "1" ? true : false;

                person.AuthorSummary = summary.Text;

                if (Request.Form["lb"] != "")
                    person.AuthorImage = "/File/" + Request.Form["lb"];

                if (db.SaveChanges() == 1)
                    Response.Write("<script>alert('编辑成功');location='AuthorEditor.aspx?id=" + id + "'</script>");
                else
                    Response.Write("<script>alert('编辑失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }

    protected void btnEditors_Click(object sender, EventArgs e)
    {
        name.Enabled = true;
        sex.Enabled = true;
        btnEditor.Visible = true;
        btnEditors.Visible = false;
        summary.Enabled = true;
        uploader.Style.Add("display", "block");//把后台div显示出来
    }
}