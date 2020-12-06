using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Matricular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Matricula.Areas.Matricular.Pages.Matriculacion
{
    public class PantallaMatriculaModel : PageModel
    {
        private static MatricularM _dataUser1;

        public void OnGet()
        {
            Input_Matricula = new InputModelMatricula
            {
                estudiante = _dataUser1.estudiante,
                lista_Materias = _dataUser1.lista_Materias,
                lista_MateriasMatriculadas = _dataUser1.lista_MateriasMatriculadas
            };
        }

        [BindProperty]
        public InputModelMatricula Input_Matricula { get; set; }

        public class InputModelMatricula : MatricularM
        {
        }

        public IActionResult OnPost(string dataMatricula)
        {
            _dataUser1 = JsonConvert.DeserializeObject<MatricularM>(dataMatricula);
            return Redirect("/Matricular/Pantalla_Matricula");
        }
    }
}
