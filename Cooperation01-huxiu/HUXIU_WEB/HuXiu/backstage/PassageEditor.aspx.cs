using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassageEditor : System.Web.UI.Page
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

                    List<PassageCategory> pcategory = (from it in db.PassageCategory select it).ToList();

                    for (int i = 0; i < pcategory.Count; i++)
                    {
                        string idc = pcategory[i].PCategoryId.ToString();

                        string categoryc = pcategory[i].CategoryName.ToString();

                        category.Items.Add(new ListItem(categoryc, idc));//循环动态绑定分类
                    }

                    List<Author> authorlist = (from it in db.Author select it).ToList();

                    for (int i = 0; i < authorlist.Count; i++)
                    {
                        string idc = authorlist[i].AuthorId.ToString();

                        string categoryc = authorlist[i].AuthorName.ToString();

                        author.Items.Add(new ListItem(categoryc, idc));//循环动态绑定作者
                    }

                    Passage passagelist = (from it in db.Passage where it.PassageId == id select it).FirstOrDefault();//把资讯显示出来

                    if (passagelist != null)
                    {
                        title.Text = passagelist.PassageTitle;//标题

                        editor.InnerHtml = passagelist.PassageBody;//内容

                        author.SelectedValue = passagelist.AuthorId.ToString();//作者

                        category.SelectedValue = passagelist.PassageCategory.ToString();//分类

                        dates.Text = passagelist.PublishDate.ToString();//发布时间

                        image.ImageUrl = passagelist.PassageImage;//封面图
                    }
                    else
                        Response.Write("<script>alert('地址栏有误');location='PassageList.aspx'</script>");
                }
            }
            else
                Response.Write("<script>alert('地址栏有误');location='PassageList.aspx'</script>");
        }

        
    }

    protected void btnEditor_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32( Request.QueryString["id"]);
        //标题 内容  不能为空
        if (title.Text.Trim().Length > 0 &&  editor.InnerHtml.Trim().Length > 0 )
        {
            using (var db = new huxiuEntities())
            {
                Passage person = (from it in db.Passage where it.PassageId == id select it).FirstOrDefault();
                person.PassageTitle = title.Text;//标题
                person.PassageBody = UeditorHelper.change(editor.InnerHtml);//内容
                if (Request.Form["lb"] != "")
                    person.PassageImage = "/File/" + Request.Form["lb"];
                person.PassageCategory = Convert.ToInt32(category.SelectedValue);//资讯分类
                person.PublishDate = Convert.ToDateTime(dates.Text).ToString("yyyy-MM-dd HH:mm:ss");//时间
                person.AuthorId = Convert.ToInt32(author.SelectedValue);//作者

                if (db.SaveChanges() == 1)
                {
                    Response.Write("<script>alert('编辑成功');location='PassageEditor.aspx?id="+id+"'</script>");
                }
                else
                    Response.Write("<script>alert('编辑失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空')</script>");
    }

    protected void btnEditors_Click(object sender, EventArgs e)
    {
        title.Enabled = true;
        author.Enabled = true;
        category.Enabled = true;
        uploader.Style.Add("display", "block");//把后台div显示出来
        btnEditor.Visible = true;
        ChangeFlag.Value = "1";
        btnEditors.Visible = false;
    }
}