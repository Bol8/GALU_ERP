using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GALU_ERP.Entidades;
using GALU_ERP.Models.User;
using GALU_ERP.Security;


namespace GALU_ERP.Gestion
{
    public class gUsers
    {

       private static  GaluEntities db = new GaluEntities();

        



        public static bool SaveUser(UserModel model)
        {

            try
            {
                model.Password = encodePassword(model.Password);
                usuario user = new usuario(model);

                db.usuarios.Add(user);
                db.SaveChanges();


                return true;

            }
            catch (Exception)
            {

                return false;

            }



        }


        private static string encodePassword(string pass)
        {
            return new Cryptography().encodeData(pass);
        }

    }
}