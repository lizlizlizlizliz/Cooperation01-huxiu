using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassageContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Regex r = new Regex("^[1-9]d*|0$");


        if (Request.QueryString["id"] != null && r.IsMatch(Request.QueryString["id"]))
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new huxiuEntities())
            {
                Passage_Author person = (from it in db.Passage_Author where it.PassageId == id select it).FirstOrDefault();

                Passage newperson = (from it in db.Passage where it.PassageId == id select it).FirstOrDefault();

                if (newperson != null)
                {
                    newperson.PageViews = newperson.PageViews + 1;

                    db.SaveChanges();
                
                    person.PageViews=person.PageViews+1;

                    title.Text = person.PassageTitle;//标题

                    content.Text = person.PassageBody;//内容

                    image.ImageUrl = person.PassageImage;//封面

                    time.Text = person.PublishDate.ToString();//时间

                    authorimage.ImageUrl = person.AuthorImage;//作者头像

                    authorname.Text = person.AuthorName;//作者名

                    authorsummary.Text = person.AuthorSummary;//作者简介

                    views.Text = "阅读量" + person.PageViews;//阅读量

                    List<Passage_Author> people = (from it in db.Passage_Author where it.PassageId != id select it).ToList();//相关活动

                    title1.Text = people[0].PassageTitle;

                    image1.ImageUrl = people[0].PassageImage;

                    image1.PostBackUrl = "/PassageContent.aspx?id=" + people[0].PassageId;

                    title2.Text = people[1].PassageTitle;

                    image2.ImageUrl = people[1].PassageImage;

                    image2.PostBackUrl = "/PassageContent.aspx?id=" + people[1].PassageId;

                    title3.Text = people[2].PassageTitle;

                    image3.ImageUrl = people[2].PassageImage;

                    image3.PostBackUrl = "/PassageContent.aspx?id=" + people[2].PassageId;

                    

                }
                else
                    Response.Write("<script>alert('地址栏有误');location='PassageList.aspx'</script>");
            }

           
        }
        else
            Response.Write("<script>alert('地址栏有误');location='PassageList.aspx'</script>");
    }
}