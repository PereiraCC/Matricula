using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Users.Models
{
    public class InputModelRegister
    {
        [Required(ErrorMessage = "El campo Identificacion es requerido")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Primer Apellido es requerido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "El campo Segundo Apellido es requerido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido")]
        [DataType(DataType.Date)]
        public string FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo Correo Electronico es requerido")]
        [EmailAddress(ErrorMessage = "Digite un dirreccion de correo electronico valido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{5})$", ErrorMessage = "El formato Telefono NO es valido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string Direccion { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Password es requerido")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "El numero de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Rol es requerido")]
        public string Rol { get; set; }
       
    }
}
