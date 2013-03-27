using System;
using System.Collections.Generic;
using System.Text;

namespace WenSharkGenNHibernate.Utils
{
public class Util
{
public static string GetEncondeMD5 (string password)
{
        System.Security.Cryptography.MD5 md5;
        md5 = new System.Security.Cryptography.MD5CryptoServiceProvider ();
        Byte[] encodedBytes = md5.ComputeHash (ASCIIEncoding.Default.GetBytes (password));
        return System.Text.RegularExpressions.Regex.Replace (BitConverter.ToString (encodedBytes).ToLower (), @"-", "");
}
}
}
