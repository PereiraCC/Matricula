using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Users.Models
{
    public class InputModelLogin
    {
        [Required(ErrorMessage = "El campo Correo Electronico es requerido")]
        [EmailAddress(ErrorMessage = "Digite un dirreccion de correo electronico valido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Password es requerido")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Password { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
