using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace GALU_ERP.Security
{
    public static class SecurityExtensions
    {
        public static CustomPrincipal ToCustomPrincipal(this IPrincipal principal)
        {
            return (CustomPrincipal)principal;
        }


    }
}