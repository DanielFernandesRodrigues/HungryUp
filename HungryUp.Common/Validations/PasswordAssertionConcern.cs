using HungryUp.Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEndpoints.Common.Validations
{
    public class PasswordAssertionConcern
    {
        public static void AssertIsValid(string password)
        {
            AssertionConcern.AssertArgumentNotNull(password, ErrorMessages.InvalidUserPassword);
        }

        public static string Encrypt(string password)
        {
            password += "|HurryUp";
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            System.Text.StringBuilder sbString = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));
            return sbString.ToString();
        }
    }
}
