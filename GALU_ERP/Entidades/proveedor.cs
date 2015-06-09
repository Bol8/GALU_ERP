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
    using System.ComponentModel.DataAnnotations;
    using Validations;

    public partial class proveedor
    {
        public proveedor()
        {
            this.pedido_p = new HashSet<pedido_p>();
        }





        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "C�digo")]
        public int idProv { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Raz�n Social")]
        [StringLength(20, ErrorMessage = "Max. 20 caracteres")]
        public string RazonSocial { get; set; }



        [NIF(ErrorMessage = "El NIF es incorrecto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "NIF")]
        public string NIF { get; set; }




        [NIF(ErrorMessage = "El NIF es incorrecto")]
        [Display(Name = "NIF_R")]
        public string NIF_R { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Domicilio")]
        [StringLength(20, ErrorMessage = "Max. 20 caracteres")]
        public string Domicilio { get; set; }


        [CP(ErrorMessage = "CP incorrecto")]
        [Display(Name = "CP")]
        [StringLength(5, ErrorMessage = "Max. 5 d�gitos")]
        public string CP { get; set; }


        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Poblaci�n")]
        [StringLength(20, ErrorMessage = "Max. 20 caracteres")]
        public string Poblacion { get; set; }


        [Display(Name = "Provincia")]
        [StringLength(20, ErrorMessage = "Max. 20 caracteres")]
        public string Provincia { get; set; }




        [Display(Name = "Pa�s")]
        [StringLength(20, ErrorMessage = "Max. 20 caracteres")]
        public string Pais { get; set; }



        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Fecha Alta")]
        public System.DateTime Fecha_A { get; set; }





        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Estado")]
        public int Estado { get; set; }



        [Display(Name = "Imagen")]
        public string Imagen { get; set; }



        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "Tel�fono")]
        [StringLength(9, ErrorMessage = "Max. 9 d�gitos")]
        [Phone(ErrorMessage = "N�mero incorrecto")]
        public string Telefono { get; set; }



        [Display(Name = "Mail")]
        // [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Mail incorrecto")]
        public string Mail { get; set; }





        public virtual estado estado1 { get; set; }
        public virtual ICollection<pedido_p> pedido_p { get; set; }
    }
}
