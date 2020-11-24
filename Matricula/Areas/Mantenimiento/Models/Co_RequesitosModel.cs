using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class Co_RequesitosM
    {
        [Required(ErrorMessage = "El campo Codigo Co_Requesito es requerido")]
        public string Codigo_CoRequesito { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
