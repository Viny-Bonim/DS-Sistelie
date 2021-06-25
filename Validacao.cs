using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DS_Sistelie
{
    public class Validacao
    {
        public static bool IsEmail(string text)
        {
            bool blnValidEmail = false;
            Regex regEmail = new Regex(@"^[a-zA-Z][\w\.-]{1,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (text.Length > 0)
                blnValidEmail = regEmail.IsMatch(text);

            return blnValidEmail;
        }
    }
}
