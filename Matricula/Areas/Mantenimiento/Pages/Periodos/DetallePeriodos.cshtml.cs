using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Periodos
{
    public class DetallePeriodosModel : PageModel
    {
        ActionsBDPeriodos actions = new ActionsBDPeriodos();

        public void OnGet(string id)
        {
            PeriodosM data = actions.getUnPeriodo(id);
            Input = new InputModelPeriodos
            {
                DataUser = data
            };
        }

        public InputModelPeriodos Input { get; set; }

        public class InputModelPeriodos
        {
            public PeriodosM DataUser { get; set; }
        }
    }
}
