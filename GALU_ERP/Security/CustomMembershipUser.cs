using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using GALU_ERP.Entidades;


namespace GALU_ERP.Security
{
    public class CustomMembershipUser : MembershipUser
    {

        #region Properties

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string UserRoleName { get; set; }

        #endregion


        public CustomMembershipUser(usuario user)
            //Hacemos una llamada a la clase base y le pasamos los datos para que se puedea construir un objeto MembershipUser
            : base("CustomMembershipProvider",      //providerName
                    user.Nombre,                    //name
                    user.id,                        //providerUserKey
                    user.Email,                     //email
                    string.Empty,                   //passwordQuestion
                    string.Empty,                   //comment
                    true,                           //isApproved
                    false,                          //isLockedOut
                    DateTime.Now,                   //creationDate
                    DateTime.Now,                   //lastLoginDate
                    DateTime.Now,                   //lastActivityDate
                    DateTime.Now,                   //lastPasswordChangedDate
                    DateTime.Now                    //lastLockoutDate
            )
        {

            UserId = user.id;
            FirstName = user.Nombre;
            LastName = user.Apellidos;
            UserRoleName = user.role.Nombre;

        }



    }
}