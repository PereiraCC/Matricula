using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class PeriodosM
    {
        [Required(ErrorMessage = "El campo Codigo Periodo es requerido")]
        public string Codigo_Periodo { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Periodo es requerido")]
        public string Nombre_Periodo { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Año Inicial es requerido")]
        public string Nombre_Anno { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
