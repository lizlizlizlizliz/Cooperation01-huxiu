using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tempJump : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int adId = Convert.ToInt32(Session["AdminID"].ToString().Trim());
        string url = "AdminInfo.aspx?id=" + adId;
        Response.Write("<script>location.href='"+url+"'</script>");
    }
}