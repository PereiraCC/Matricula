using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Mantenimiento.Models
{
    public class HorariosM
    {
        [Required(ErrorMessage = "El campo Codigo Horario es requerido")]
        public string Codigo_Horario { get; set; }

        [Required(ErrorMessage = "El campo Día es requerido")]
        public string Dia { get; set; }

        [Required(ErrorMessage = "El campo Hora Inicial es requerido")]
        public string Hora_Inicial { get; set; }

        [Required(ErrorMessage = "El campo Hora Final es requerido")]
        public string Hora_Final { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
