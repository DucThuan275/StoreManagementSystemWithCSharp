using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Buoi06_01.models
{
    internal class MaHoa
    {
        public static string ToSHA256(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(str);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string ToMD5(string str)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder chuoiMaHoa = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                chuoiMaHoa.Append(hash[i].ToString("X2"));
            }
            return chuoiMaHoa.ToString();
        }
    }
}
