using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Notas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Materias
{
    public class DetalleMateriasModel : PageModel
    {
        ActionsBDMaterias actions = new ActionsBDMaterias();

        public void OnGet(string id)
        {
            MateriasM data = actions.getUnaMateria(id);
            Input = new InputModelMaterias
            {
                DataUser = data
            };
        }

        public InputModelMaterias Input { get; set; }

        public class InputModelMaterias
        {
            public MateriasM DataUser { get; set; }

        }
    }
}
