using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GALU_ERP.Models.Account
{
    public class Login
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar inicio de sesión?")]
        public bool RememberMe { get; set; }



    }
}