using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Regex r = new Regex("^[1-9]d*|0$");

        string test = Request.QueryString["search"];

        if (Request.QueryString["search"] == null )

            Response.Write("<script>alert('地址栏有误');location='/index.aspx'</script>");

        //else if(r.IsMatch(Request.QueryString["search"]))

        //    Response.Write("<script>alert('地址栏有误');location='/index.aspx'</script>");
    }
}
