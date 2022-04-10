using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.Extensions
{
    static class StringEx
    {
        public static string UpperFirstLetter(this string fullName)
        {
            if (String.IsNullOrWhiteSpace(fullName) == false)
            {
                fullName = fullName.ToLower().Trim();
                string h = "";
                string[] subs = System.Text.RegularExpressions.Regex.Split(fullName, @"\s{1,}");

                foreach (string sub in subs)
                {

                    string temp = sub;
                    temp = char.ToUpper(temp[0]) + temp.Substring(1);
                    h += temp.Trim();
                    h += " ";
                }
                h = h.Trim();
                fullName = h;
                return fullName;

            }
            else throw new FormatException();
        }
    }
}