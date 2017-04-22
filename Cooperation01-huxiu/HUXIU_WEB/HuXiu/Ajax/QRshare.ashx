<%@ WebHandler Language="C#" Class="QRshare" %>

using System;
using System.Web;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public class QRshare : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string str = context.Request.QueryString["str"].ToString();
        MemoryStream ms = GenerateQRByQrCodeNet(str);
        context.Response.ClearContent();                    //清空流
        context.Response.ContentType = "image/Png";         //设置保存图像的格式
        context.Response.BinaryWrite(ms.ToArray());         //执行保存图像的操作
    }
        //生成二维码
    private MemoryStream GenerateQRByQrCodeNet(string content)
    {
        QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);            
        QrCode qrCode = new QrCode();
        qrEncoder.TryEncode(content, out qrCode);

        GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

        using (MemoryStream ms = new MemoryStream())
        {
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);         //输出字节流以 png 格式
            return ms;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}