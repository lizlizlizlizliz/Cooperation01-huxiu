using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Security 的摘要说明
/// 参数：等待加密字符
/// return：长度为40的字符串
/// </summary>
public class Security
{
    public Security()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //SHA1
    static public string SHA1_Hash(string str_sha1_in)
    {
        string redefineStr = str_sha1_in + "LYFYYFSTYQYCLFLLSQLYJ";               //加盐
        SHA1 sha1 = new SHA1CryptoServiceProvider();                            //实例化 SHA1 对象
        byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);      //密文进行 UTF-8 编码
        byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);                //输出二进制结果
        string str_sha1_out = BitConverter.ToString(bytes_sha1_out);            //转换为字符串
        str_sha1_out = str_sha1_out.Replace("-", "");                           //替换所有“-”
        return str_sha1_out;
    }
    static public string MD5_hash(string str_md5_in)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] bytes_md5_in = UTF8Encoding.Default.GetBytes(str_md5_in);      //密文进行 UTF-8 编码
        byte[] bytes_md5_out = md5.ComputeHash(bytes_md5_in);                //输出二进制结果
        string str_md5_out = BitConverter.ToString(bytes_md5_out);            //转换为字符串
        str_md5_out = str_md5_out.Replace("-", "").ToLower();                           //替换所有“-”
        return str_md5_out;

    }

}