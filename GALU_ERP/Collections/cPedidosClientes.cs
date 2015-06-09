using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GALU_ERP.Entidades;


namespace GALU_ERP.Collections
{
    public class cPedidosClientes
    {

        private static GaluEntities db = new GaluEntities();


        public static int getCountOrders()
        {

            try
            {
                var query = from p in db.pedido_c
                            select p;


                return query.Count();

            }
            catch (Exception )
            {
                return 0;
            }

        }


    }
}