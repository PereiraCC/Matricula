using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Notas.Models;
using Matricula.Areas.Users.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Notas.Pages.NotasAcademicas
{
    public class ListadoEstudiantesMateriaModel : PageModel
    {
        ActionsBDNotas actions = new ActionsBDNotas();

        public void OnGet(string id)
        {
            Input = new InputModelEstudiantes()
            {
                profesor = LUser.usuario,
                lista_estudiantes = actions.getEstudiantesxMateria(id),
                Nombre_Materia = actions.getNombreMateria(id),
            };
            
        }

        public InputModelEstudiantes Input { get; set; }

        public class InputModelEstudiantes
        {
            public InputModelRegister profesor { get; set; }

            public string Nombre_Materia { get; set; }

            public List<EstudianteModel> lista_estudiantes { get; set; }
        }
    }
}
