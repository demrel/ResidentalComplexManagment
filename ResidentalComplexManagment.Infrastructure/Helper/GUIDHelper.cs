using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResidentalComplexManagment.Infrastructure.Helper
{
    public static class GUIDHelper
    {
        public static string GetAlphaNumeric(this Guid guid)
        {
            Regex rgx = new("[^a-zA-Z0-9]");
            return  rgx.Replace(guid.ToString(), "");
          
        }
    }
}
