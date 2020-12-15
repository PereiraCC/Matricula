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
    public class DetalleEstudianteModel : PageModel
    {
        ActionsBDNotas actions = new ActionsBDNotas();

        public void OnGet(string id)
        {
            string[] codigos = id.Split(",");
            EstudianteModel data = actions.getUnEstudiante(codigos[0]);
            Input = new InputModelDetalleEstudiante
            {
                DataUser = data,
                idMateria = actions.getidMateria(codigos[1])
            };
        }

        public InputModelDetalleEstudiante Input { get; set; }

        public class InputModelDetalleEstudiante
        {
            public EstudianteModel DataUser { get; set; }

            public string idMateria { get; set; }
        }
    }
}
