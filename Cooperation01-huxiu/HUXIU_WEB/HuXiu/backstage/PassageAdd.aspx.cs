using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassageAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
                        Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else if (!IsPostBack)
        {
            using(var db=new huxiuEntities())
            {
                List<PassageCategory> pcategory =(from it in db.PassageCategory select it).ToList();

                for(int i = 0; i < pcategory.Count; i++)
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

            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //标题 内容 封面 作者 分类 不能为空
        if (title.Text.Trim().Length > 0 && editor.InnerHtml.Trim().Length > 0 && Request.Form["lb"].Trim().Length > 0 && author.SelectedValue.Length > 0 && category.SelectedValue.Length > 0)
        {
            using (var db = new huxiuEntities())
            {
                Passage passage = new Passage
                {
                    PassageTitle = title.Text,
                    PassageBody = UeditorHelper.change(editor.InnerHtml),
                    PassageImage = "/File/" + Request.Form["lb"],
                    PassageCategory = Convert.ToInt32(category.SelectedValue),
                    PublishDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    AuthorId = Convert.ToInt32(author.SelectedValue),
                    PageViews = 0,
                    IsDel = false
                };
                db.Passage.Add(passage);
                
                if (db.SaveChanges() == 1)
                {
                    Response.Write("<script>alert('添加成功');location='PassageList.aspx'</script>");
                }
                else
                    Response.Write("<script>alert('添加失败请重试')</script>");
            }
        }
        else
            Response.Write("<script>alert('不能为空！')</script>");        
    }
}