using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GALU_ERP.Entidades;


namespace GALU_ERP.Collections
{
    public class cLineaPedidos_C
    {
        private static GaluEntities db = new GaluEntities();


        public static int getNumLine(int numPed)
        {

            var query = (from l in db.linea_pedido_c
                         where l.Num_ped == numPed
                         orderby l.Linea descending
                         select l.Linea).FirstOrDefault();
                        

            return query + 1; ;
        }



    }
}