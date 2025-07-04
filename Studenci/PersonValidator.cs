using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Studenci
{
    public class PersonValidator
    {
        public static bool IsValidName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return Regex.IsMatch(name, @"^[A-Za-zĄĆĘŁŃÓŚŻŹąćęłńóśżź\s]+$");
        }
    }
}
