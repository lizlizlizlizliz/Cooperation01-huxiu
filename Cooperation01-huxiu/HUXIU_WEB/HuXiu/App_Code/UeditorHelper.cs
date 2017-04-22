using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// UeditorHelper 的摘要说明
/// </summary>
public class UeditorHelper
{
    public UeditorHelper()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
  	/*
    static public string change(string x)//对富文本编辑器中获取的内容 html标签进行处理，避免它存到数据库的时候被转义
    {
        x = x.Replace("&lt;", "<");//对一些特殊字符进行替换
        x = x.Replace("&gt;", ">");
        x = x.Replace("&quot;", "\"");

        return x;
    }
	
	*/
	static public string change(string x)//对富文本编辑器中获取的内容 html标签进行处理，避免它存到数据库的时候被转义
    {
        x = x.Replace("&lt;", "<");//对一些特殊字符进行替换
        x = x.Replace("&gt;", ">");
        x = x.Replace("&quot;", "\"");
      //  x = x.Replace("&#39;", """ );
        x = x.Replace("&nbsp;", " ");
      //  x = x.Replace("&ldquo;", """);
      //  x = x.Replace("&rdquo;", """);
        x = x.Replace("&amp;", "&");
        
        return x;
    }
    public static string NoHTML(string Htmlstring)//把文本中的html标签全部去掉
    {
        //删除脚本   
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //删除HTML   
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }

    static public int GetRandomSeed()//防止图片命名格式化时，随机数出现重复，导致已上传的图片被下一个图片覆盖掉
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);
    }
}