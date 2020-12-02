using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class PlanesEstudioM
    {
        [Required(ErrorMessage = "El campo Codigo Plan de Estudio es requerido")]
        public string Codigo_Plan { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Plan de Estudio es requerido")]
        public string Nombre_Plan { get; set; }

        [Required(ErrorMessage = "El campo Descripcion del Plan de Estudio es requerido")]
        public string Descripcion_Plan { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la Carrera es requerido")]
        public string Nombre_Carrera { get; set; }

        public List<string> Lista_Materias { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
