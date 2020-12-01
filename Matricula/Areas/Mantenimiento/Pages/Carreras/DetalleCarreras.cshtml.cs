using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Carreras
{
    public class DetalleCarrerasModel : PageModel
    {
        ActionsBDCarreras actions = new ActionsBDCarreras();

        public void OnGet(string id)
        {
            CarrerasM data = actions.getUnaCarrera(id);
            Input = new InputModelCarreras
            {
                DataUser = data
            };
        }

        public InputModelCarreras Input { get; set; }

        public class InputModelCarreras
        {
            public CarrerasM DataUser { get; set; }
        }
    }
}
