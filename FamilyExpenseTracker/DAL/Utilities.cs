using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Utilities
    {
        public static string GetConnectionString()
        {
            return @"data source = DESKTOP-CG3UDHL\SQLEXPRESS; 
                     initial catalog = FamilyExpenseTracker; 
                     integrated security = sspi";
        }
    }
}
