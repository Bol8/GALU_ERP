using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GALU_ERP.Entidades;

namespace GALU_ERP.Models.ViewModel
{
    public class ViewModel
    {

        public pedido_c pedido { get; set; }
        public IEnumerable<linea_pedido_c> lineasPedido { get; set; }


    }
}