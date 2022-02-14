using System;
using System.Security.Cryptography;
using System.Text;

namespace RapidPay.Application.Crosscutting
{
    public static class SHA1Tool
    {
        public static string GetSHA1(string strPlain)
        {

            UnicodeEncoding UE = new UnicodeEncoding();

            byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);

            SHA1Managed SHhash = new SHA1Managed();

            string strHex = "";


            HashValue = SHhash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)

            {

                strHex += String.Format("{0:x2}", b);

            }

            return strHex;

        }
    }
}
