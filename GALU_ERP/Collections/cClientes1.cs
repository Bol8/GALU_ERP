using GALU_ERP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GALU_ERP.Collections
{
    public class cClientes1
    {
        private static GaluEntities db = new GaluEntities();


        public static int getCountClientes()
        {
            try
            {
                var query = from c in db.clientes
                            select c;


                return query.Count();
            }
            catch (Exception)
            {
                return 0;
            }



        }

    }
}