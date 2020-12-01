using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class CarrerasM
    {
        [Required(ErrorMessage = "El campo Codigo Carrera es requerido")]
        public string Codigo_Carrera { get; set; }

        [Required(ErrorMessage = "El campo Nombre Carrera es requerido")]
        public string Nombre_Carrera { get; set; }

        [Required(ErrorMessage = "El campo Descripcion Carrera es requerido")]
        public string Descripcion_Carrera { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
