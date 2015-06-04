using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GALU_ERP.Entidades;

namespace GALU_ERP.Collections
{
    public class cProducto
    {
        private static GaluEntities db = new GaluEntities();



        public static  int getCountProducts()
        {
            try
            {
                var query = from p in db.articuloes
                            select p;


                return query.Count(); 

            }catch(Exception ){


                return 0;
            }


           
        }


    }
}