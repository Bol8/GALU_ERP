using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GALU_ERP.Validations;


namespace GALU_ERP.Models.User
{
    public class UserModel
    {

        [Display(Name = "#")]
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

       
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de Usuario")]
        public string userName { get; set; }

        //[UserLoginInUse]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

      
        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "Número incorrecto")]
        public string telefono { get; set; }
       
        [Display(Name = "Rol")]
        public string roles { get; set; }



    }
}