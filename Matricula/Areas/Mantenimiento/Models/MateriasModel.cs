using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class MateriasM
    {
        [Required(ErrorMessage = "El campo Codigo Materia es requerido")]
        public string Codigo_Materia { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Creditos es requerido")]
        public string Creditos { get; set; }

        [Required(ErrorMessage = "El campo Nombre Requesito es requerido")]
        public string Nombre_Requesito { get; set; }

        [Required(ErrorMessage = "El campo Nombre Co-Requesito es requerido")]
        public string NombreCo_Requesito { get; set; }

        [Required(ErrorMessage = "El campo Nombre Horario es requerido")]
        public string NombreHorario { get; set; }

        public string Hora_Inicial { get; set; }

        public string Hora_Final { get; set; }

        [Required(ErrorMessage = "El campo Nombre Cupo es requerido")]
        public string Cupo { get; set; }

        [Required(ErrorMessage = "El campo Nombre Costo es requerido")]
        public string Costo { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
