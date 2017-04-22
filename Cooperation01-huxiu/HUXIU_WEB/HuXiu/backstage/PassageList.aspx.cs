using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PassageList : System.Web.UI.Page //同名1
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Session["AdminID"] != null)
            {

                using (var db = new huxiuEntities())
                {
                    var datascore = from it in db.PassageInformation where it.IsDel == false orderby it.PublishDate descending select it;

                    var ds = datascore.ToList();

                    Session["ds"] = ds;

                    DataBindToRepeater(1, ds);
                }

                using (var db = new huxiuEntities())
                {
                    var datascore = from it in db.PassageCategory select it;

                    this.DropDownList.DataSource = datascore.ToList();

                    this.DropDownList.DataValueField = "PCategoryId";

                    this.DropDownList.DataTextField = "CategoryName";

                    this.DropDownList.DataBind();

                    ListItem item = new ListItem();

                    item.Text = "全部";

                    item.Value = "0";

                    this.DropDownList.Items.Insert(0, item);

                }
            }
            else
            Response.Write("<script>alert('账户过期请重新登录！');window.parent.location.href='login.aspx';</script>");


        }
    }

    protected void Rpt_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int activeId = Convert.ToInt32(e.CommandArgument);
        int adminId = Convert.ToInt32(Session["AdminID"].ToString());
        DelHelper delc = new DelHelper(1, activeId, adminId);
        if (e.CommandName == "delete")
        {
            if (delc.delItem())
                Response.Write("<script>alert('删除成功，并且保存在最近删除中！');window.location.href='PassageList.aspx';</script>");
            else
                Response.Write("<script>alert('删除失败，请重试！');window.location.href='PassageList.aspx';</script>");

        }


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string content = txtSearch.Text;

        int category = 0;

        if(Session["category"] != null)
        {
            category = Convert.ToInt32(Session["category"].ToString());

        }

        using (var db = new huxiuEntities())
        {
            var datascore = from it in db.PassageInformation where it.IsDel == false orderby it.PublishDate descending select it; 

            if(RbtnPassage.Checked == true)
            {
                if (content.Length == 0)
                {
                    if (category == 0)
                    {
                        if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }
                }

                if (content.Length != 0)
                {
                    if (category == 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.PassageCategory == category && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageTitle.IndexOf(content) >= 0 && it.PassageCategory == category && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }
                }
            }

            else if(RbtnAuthor.Checked == true)
            {
                if (content.Length == 0)
                {
                    if (category == 0)
                    {
                        if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.PassageCategory == category && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }
                }

                if (content.Length != 0)
                {
                    if (category == 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }

                    else if (category != 0)
                    {
                        if (RbtnTime.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.PassageCategory == category && it.IsDel == false orderby it.PublishDate descending select it;
                        }

                        else if (RbtnViews.Checked == true)
                        {
                            datascore = from it in db.PassageInformation where it.AuthorName.IndexOf(content) >= 0 && it.PassageCategory == category && it.IsDel == false orderby it.PageViews descending select it;
                        }
                    }
                }
            }
            var ds = datascore.ToList();

            if (ds.Count == 0)
                Response.Write("<script>alert('很抱歉，没有找到相关内容！')</script>");

            Session["ds"] = ds;

            DataBindToRepeater(1, ds);

            lbNow.Text = "1";
        }
    }

    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList.SelectedIndex = DropDownList.Items.IndexOf(DropDownList.Items.FindByValue("0"));

        string category = DropDownList.SelectedValue;
        
        Session["category"] = category;
    }


    protected void RbtnTime_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnTime.Checked == true)
        {
            RbtnViews.Checked = false;
        }          
    }

    protected void RbtnViews_CheckedChanged(object sender, EventArgs e)
    {
        if (RbtnViews.Checked == true)
        {
            RbtnTime.Checked = false;
        }           
    }

    void DataBindToRepeater(int currentPage, List<PassageInformation> datascore)
    {
        for (int i = 0; i < datascore.Count; i++)
            datascore[i].PassageBody = UeditorHelper.NoHTML(datascore[i].PassageBody);//把内容的html标签全部去除

        PagedDataSource pds = new PagedDataSource();

        pds.AllowPaging = true;

        pds.PageSize = 5;

        pds.DataSource = datascore;

        lbTotal.Text = pds.PageCount.ToString();

        pds.CurrentPageIndex = currentPage - 1;

        Rpt.DataSource = pds;

        Rpt.DataBind();
    }

    protected void btnUp_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) - 1 < 1)
            lbNow.Text = "1";

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) - 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnDrow_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        if (Convert.ToInt32(lbNow.Text) + 1 > Convert.ToInt32(lbTotal.Text))
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        else
            lbNow.Text = Convert.ToString(Convert.ToInt32(lbNow.Text) + 1);

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        lbNow.Text = "1";

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }

    protected void btnJump_Click(object sender, EventArgs e)
    {
        List<PassageInformation> ds = (List<PassageInformation>)Session["ds"];

        int i = 0;

        if (int.TryParse(txtJump.Text, out i))
        {
            if (Convert.ToInt32(txtJump.Text) < 1)
                lbNow.Text = "1";

            else if (Convert.ToInt32(txtJump.Text) > Convert.ToInt32(lbTotal.Text))
                lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

            else
                lbNow.Text = Convert.ToString(Convert.ToInt32(txtJump.Text));
        }

        else
            lbNow.Text = "1";
            //lbNow.Text = Convert.ToString(Convert.ToInt32(lbTotal.Text));

        DataBindToRepeater(Convert.ToInt32(lbNow.Text), ds);
    }



    protected void RbtnPassage_CheckedChanged(object sender, EventArgs e)
    {
        if(RbtnPassage.Checked == true)
        {
            RbtnAuthor.Checked = false;
        }
    }

    protected void RbtnAuthor_CheckedChanged(object sender, EventArgs e)
    {
        if(RbtnAuthor.Checked == true)
        {
            RbtnPassage.Checked = false;
        }
    }
}