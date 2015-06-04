using GALU_ERP.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GALU_ERP.Collections
{
    public class cProveedores
    {

        private static GaluEntities db = new GaluEntities();


        public static int getCountProv()
        {

            try
            {
                var query = from prov in db.proveedors
                            select prov;


                return query.Count();
            }
            catch (Exception)
            {
                return 0;

            }

        }

    }
}