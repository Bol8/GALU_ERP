//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GALU_ERP.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class pedido_c
    {
        public pedido_c()
        {
            this.linea_pedido_c = new HashSet<linea_pedido_c>();
        }
    
        public int Num_ped { get; set; }
        public System.DateTime Fecha_A { get; set; }
        public Nullable<float> Total { get; set; }
        public string Destino { get; set; }
        public string Tipo { get; set; }
        public int Estado { get; set; }
        public int Forma_pago { get; set; }
        public int idCliente { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual estado_ped estado_ped { get; set; }
        public virtual forma_pago forma_pago1 { get; set; }
        public virtual ICollection<linea_pedido_c> linea_pedido_c { get; set; }
    }
}
