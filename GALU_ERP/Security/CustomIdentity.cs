using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace GALU_ERP.Security
{
    [Serializable]
    public class CustomIdentity : IIdentity
    {

        #region Properties

        public IIdentity Identity { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserRoleName { get; set; }

        #endregion

        #region Constructor

        public CustomIdentity(IIdentity identity)
        {
            Identity = identity;

            var custonMembershipUser = (CustomMembershipUser)Membership.GetUser(identity.Name);

            if (custonMembershipUser != null)
            {
                UserId = custonMembershipUser.UserId;
                FirstName = custonMembershipUser.FirstName;
                LastName = custonMembershipUser.LastName;
                Email = custonMembershipUser.Email;
                UserRoleName = custonMembershipUser.UserRoleName;
            }

        }

        #endregion



        string IIdentity.AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        bool IIdentity.IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        string IIdentity.Name
        {
            get { return Identity.Name; }
        }
    }
}