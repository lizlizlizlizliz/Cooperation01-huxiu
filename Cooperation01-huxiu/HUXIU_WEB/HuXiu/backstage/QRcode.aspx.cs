using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class QRcode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //GenerateQRByQrCodeNet();
        
    }


    private void GenerateQRByQrCodeNet()
    {
        QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
        QrCode qrCode = new QrCode();
        qrEncoder.TryEncode("Hello World. sdfsfsfwosj我发的顺风  ", out qrCode);

        GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);

        using (MemoryStream ms = new MemoryStream())
        {
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
           // Response.BinaryWrite(ms.ToArray());


            //img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();
            Response.ContentType = "image/Png";         //设置保存图像的格式
            Response.BinaryWrite(ms.ToArray());         //执行保存图像的操作

        }
    }
}