using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace GALU_ERP.Security
{
    [Serializable]
    public class CustomPrincipal:IPrincipal
    {

        public IIdentity Identity { get; private set; }

        public CustomPrincipal(CustomIdentity identity) 
        { 
            Identity = identity;
        
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public CustomIdentity CustomIdentity { get { return (CustomIdentity)Identity; } set { Identity = value; } }
    }
}