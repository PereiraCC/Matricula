using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Horarios
{
    public class DetalleHorariosModel : PageModel
    {
        ActionsBDHorarios actions = new ActionsBDHorarios();

        public void OnGet(string id)
        {
            HorariosM data = actions.getUnHorario(id);
            Input = new InputModelHorarios
            {
                DataUser = data
            };
        }

        public InputModelHorarios Input { get; set; }

        public class InputModelHorarios
        {
            public HorariosM DataUser { get; set; }
        }
    }
}
