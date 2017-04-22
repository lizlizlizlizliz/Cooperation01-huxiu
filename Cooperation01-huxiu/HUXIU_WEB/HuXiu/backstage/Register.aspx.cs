using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testRegist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止恶意注册，必须管理员注册管理员
        if (Session["AdminID"] == null)
            Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

    }
}