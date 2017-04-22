using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreatImage(Vstring());

    }/// <summary>
    /// Vstring 用来产生生成验证码所需字符串并且把验证码正确结果存入 seesion["Vnum"] 中
    /// </summary>
    /// <returns></returns>
    private string Vstring()      //产生验证码图片的字符串
    {
        try
        {
            string[] UpperNum = new string[] { "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
            string[] Sign = new string[] { "加", "+" };
            string[] Number = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19" };
            Random ran = new Random();
            int Add1 = ran.Next(9);
            int Add2 = ran.Next(19 * Add1) % 20;
            if ((Add1 * Add2) % 2 == 0)
            {
                Session["Vnum"] = Add1 + 1 + Add2;
                string result = "";
                result = UpperNum[Add1] + "  " + Sign[(Add1 + Add2) % 2] + "  " + Number[Add2] + "  = ?";
                return result;
            }
            else
            {
                Session["Vnum"] = Add1 + Add2;
                string result = "";
                result = UpperNum[Add1] + "  " + Sign[(Add1 + Add2) % 2] + "  " + Number[Add2] + "  = ?";
                return result;
            }
        }
        catch (Exception ex)
        {
            Session["Vnum"] = 2;                      //异常处理
            return "1  +  1 = ？";
        }

    }



    private void CreatImage(string validateNum)     //生成bitmap图像
    {
        System.Drawing.Bitmap img = new System.Drawing.Bitmap(validateNum.Length * 12 + 10, 22);
        Graphics g = Graphics.FromImage(img);      //生成图片格式
        try
        {
            //生成随机生成器
            Random rand = new Random();
            //清空图片背景色
            g.Clear(Color.White);
            //画出图片噪音线
            for (int i = 0; i < 25; i++)
            {
                //确定背景噪音线位置
                int x1 = rand.Next(img.Width);
                int x2 = rand.Next(img.Width);
                int y1 = rand.Next(img.Height);
                int y2 = rand.Next(img.Height);
                g.DrawLine(new Pen(Color.Coral), x1, y1, x2, y2);    //绘制噪音线
            }
            //设置背景字体样式,刷子样式
            Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, img.Width, img.Height), Color.FromArgb(8,14,26), Color.DarkRed, 1.2f, true);
            g.DrawString(validateNum, font, brush, 2, 2);

            //画图片的前噪音点

            for (int i = 0; i < 100; i++)
            {
                //确定噪音点位置
                int x = rand.Next(img.Width);
                int y = rand.Next(img.Height);
                img.SetPixel(x, y, Color.FromArgb(rand.Next()));    //绘制噪音点

            }
            //画出边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, img.Width - 1, img.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //将图像保存到指定流
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Gif";         //设置保存图像的格式
            Response.BinaryWrite(ms.ToArray());         //执行保存图像的操作
        }


        finally                 //无论程序执行如何都将执行
        {
            g.Dispose();      //关闭g对象
            img.Dispose();
        }

    }

}