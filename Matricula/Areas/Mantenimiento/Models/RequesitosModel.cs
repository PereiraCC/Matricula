using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class RequesitosM
    {
        [Required(ErrorMessage = "El campo Codigo Requesito es requerido")]
        public string Codigo_Requesito { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Requesito es requerido")]
        public string Nombre_Requesito { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
