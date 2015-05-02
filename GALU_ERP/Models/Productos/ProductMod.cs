using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GALU_ERP.Models.Productos
{
    public class ProductModel
    {


        [Display(Name = "#")]
        public long id { get; set; }

        [Display(Name = "Nombre completo")]
        public string nombreCompleto { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

        //[UserLoginInUse]
        [Display(Name = "Identificador de agente")]
        public string loginUser { get; set; }

        [Display(Name = "Contraseña")]
        public string loginPass { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string roles { get; set; }




    }
}