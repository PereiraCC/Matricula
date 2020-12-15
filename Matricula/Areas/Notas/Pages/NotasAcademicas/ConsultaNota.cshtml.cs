using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Notas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Notas.Pages.NotasAcademicas
{
    public class ConsultaNotaModel : PageModel
    {
        ActionsBDNotas actions = new ActionsBDNotas();
        public static EstudianteModel data = new EstudianteModel();

        public void OnGet(string id)
        {
            string[] codigos = id.Split(",");
            data = actions.getUnEstudiante(codigos[0]);
            data.Nota_Estudiante = actions.getNotaEstudiante(codigos[0], codigos[1]);

            Input_Nota_Estudiante = new InputModelNotasEstudiante
            {
                DataUser = data,
                Nombre_Materia = codigos[1]
            };
        }

        [BindProperty]
        public InputModelNotasEstudiante Input_Nota_Estudiante { get; set; }

        public class InputModelNotasEstudiante
        {
            public EstudianteModel DataUser { get; set; }

            public string Nombre_Materia { get; set; }

            [TempData]
            public string ErrorMessage { get; set; }

        }
    }
}
