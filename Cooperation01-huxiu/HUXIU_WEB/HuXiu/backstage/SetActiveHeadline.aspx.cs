using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetActiveHeadline : System.Web.UI.Page
{
   public class MyStruct
    {
       public string Tile { get; set; }
       public int ID { get; set; }
        public string imgUrl { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
            Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");

        else if (!IsPostBack)
        {
            if (!bindActHeadline())
                //Response.Write("WA");
                Response.Write("<script>alert('页面过期，点击刷新！');location.href='SetActiveHeadline.aspx'</script>");
        }
    }
    protected bool bindActHeadline()
    {
        try
        {
            using (var db = new huxiuEntities())
            {
                var query = from it in db.Activity
                            where it.IsHeadline == true
                            select it;
                rptActHead.DataSource = query.ToList();
                rptActHead.DataBind();
            
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void rptActHead_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName== "editHead")      //显示修改控件
        {
            Label tmplal = (Label)e.Item.FindControl("labID");
            TextBox tmptxt = (TextBox)e.Item.FindControl("txtID");
            Button tmpbtn = (Button)e.Item.FindControl("btnSub");
            tmpbtn.Visible = tmptxt.Visible = tmplal.Visible = true;
        }
        else if(e.CommandName== "SubChange")    
        {
            TextBox tmptxt = (TextBox)e.Item.FindControl("txtID");      //获取修改的 ID 值
            int oldID=Convert.ToInt32(e.CommandArgument);
            int newID = Convert.ToInt32(tmptxt.Text);
            try
            {
                using(var db=new huxiuEntities())
                {
                    Activity act = db.Activity.SingleOrDefault(a => a.ActivityId == newID && a.IsHeadline == false && a.IsDel==false);
                    Activity actOld = db.Activity.SingleOrDefault(a => a.ActivityId == oldID);

                    if (act == null)                    //是否已经作为头条
                    {
                        Response.Write("<script>alert('请检查 ID 正确性！（不能重复添加和添加已经删除的条目） ');location.href='SetActiveHeadline.aspx';</script>");
                        return;
                    }
                    act.IsHeadline = true;
                    actOld.IsHeadline = false;
                    db.SaveChanges();
                }
                Response.Write("<script>alert('修改成功！');location.href='SetActiveHeadline.aspx';</script>");

            }
            catch
            {
                Response.Write("<script>alert('修改失败，请重试！');location.href='SetActiveHeadline.aspx';</script>");

            }

        }

    }

    
}