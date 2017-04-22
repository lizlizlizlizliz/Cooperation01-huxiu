using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var db = new huxiuEntities())
        {
            var datascore = from it in db.PassageCategory select it;

            Rpt.DataSource = datascore.ToList();

            Rpt.DataBind();
        }

        Regex r = new Regex("^[1-9]d*|0$");


        if (Request.QueryString["id"] != null && r.IsMatch(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new huxiuEntities())
            {
                PassageCategory category = (from it in db.PassageCategory where it.PCategoryId == id select it).FirstOrDefault();

                if (category != null)
                {
                    lifestyle.Text = category.CategoryName;
                }

                else
                    Response.Write("<script>alert('地址栏有误');location='/Index.aspx'</script>");
            }

            Session["ID"] = id;
        }
        else
            Response.Write("<script>alert('地址栏有误');location='/Index.aspx'</script>");
    }
}
