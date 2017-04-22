using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
            Response.Redirect("./huxiu-backstage.html");

    }

    protected void lbtLogin_Click(object sender, EventArgs e)
    {
        string username = txtUserName.Text.Trim();
        string pwd = txtpwd.Text.Trim();
        string captcha = txtCaptcha.Text.Trim();
        string trueVali = Session["Vnum"].ToString();
        System.Text.RegularExpressions.Regex numberReg = new System.Text.RegularExpressions.Regex("^[0-9]+$");
        if (username == "" || pwd == "" || captcha == "")
        {
            Response.Write("<script>alert('输入不能有空值！');</script>");
        }
        else
        {
            pwd = Security.SHA1_Hash(Security.MD5_hash(pwd));
            if (numberReg.IsMatch(captcha))
            {
                if (captcha == trueVali)
                {
                    try
                    {
                        using (var db = new huxiuEntities())
                        {
                            Admin ad = db.Admin.SingleOrDefault(a => a.AdminName == username && a.AdminPassword == pwd);
                            if (ad == null)
                                Response.Write("<script>alert('用户名或密码错误，请重新输入！');location.href='login.aspx';</script>");
                            else
                            {
                                Session["AdminID"] = ad.AdminId;
                                Response.Write("<script>alert('登录成功！');location.href='huxiu-backstage.html';</script>");

                            }
                        }
                    }
                    catch
                    {
                        Response.Write("<script>alert('网络阻塞，刷新重试！');location.href='login.aspx';</script>");

                    }
                }
                else
                {
                    Response.Write("<script>alert('验证码不正确，请重新输入！');location.href='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('验证码输入不合法！');location.href='login.aspx';</script>");
            }
        }

    }
}