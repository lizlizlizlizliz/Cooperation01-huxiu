using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivityContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Regex r = new Regex("^[1-9]d*|0$");


            if (Request.QueryString["id"] != null && r.IsMatch(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                using (var db = new huxiuEntities())
                {
                    Activity person = (from it in db.Activity where it.ActivityId == id select it).FirstOrDefault();

                    if (person != null)
                    {

                        title.Text = person.ActivityTitle;//标题

                        what.Text = person.ActivityWhat;//内容

                        img.ImageUrl = person.ActivityImage;//封面

                        when.Text = person.ActivityWhen.ToString();//时间

                        where.Text = person.ActivityWhere;//地点

                        tips.Text = person.ActivityTips;//备注

                        List<Activity> people = (from it in db.Activity where it.ActivityId != id select it).ToList();//相关活动

                        title1.Text = people[0].ActivityTitle;

                        image1.ImageUrl = people[0].ActivityImage;

                        image1.PostBackUrl = "/ActivityContent.aspx?id=" + people[0].ActivityId;

                        title2.Text = people[1].ActivityTitle;

                        image2.ImageUrl = people[1].ActivityImage;

                        image2.PostBackUrl = "/ActivityContent.aspx?id=" + people[1].ActivityId;

                        title3.Text = people[2].ActivityTitle;

                        image3.ImageUrl = people[2].ActivityImage;

                        image3.PostBackUrl = "/ActivityContent.aspx?id=" + people[2].ActivityId;

                    }
                    else
                        Response.Write("<script>alert('地址栏有误');location='/ActivityList.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('地址栏有误');location='/ActivityList.aspx'</script>");

        }
    
}