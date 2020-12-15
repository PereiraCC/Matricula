using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Users.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Notas.Pages.NotasAcademicas
{
    public class ListadoMateriasEstudianteModel : PageModel
    {
        ActionsBDNotas actions = new ActionsBDNotas();

        public void OnGet()
        {
            Input = new InputModelMateriasEstu()
            {
                estudiante = LUser.usuario,
                listaMaterias = actions.getMateriasEstudiante(LUser.usuario.Identificacion),
            };
        }

        public InputModelMateriasEstu Input { get; set; }

        public class InputModelMateriasEstu
        {
            public InputModelRegister estudiante { get; set; }

            public List<MateriasM> listaMaterias { get; set; }
        }
    }
}
