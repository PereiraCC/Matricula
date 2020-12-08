using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Users.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Matricular.Models
{
    public class MatricularM : LUser
    {
        public InputModelRegister estudiante { get; set; }

        [Required(ErrorMessage = "El campo Nombre Periodo es requerido")]
        public string Nombre_Periodo { get; set; }

        [Required(ErrorMessage = "El campo Numero_Tarjeta es requerido")]
        public string Numero_Tarjeta { get; set; }

        [Required(ErrorMessage = "El campo Monto es requerido")]
        public string Monto { get; set; }

        public List<MateriasM> lista_Materias { get; set; }

        public List<MateriasM> lista_MateriasMatriculadas { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
