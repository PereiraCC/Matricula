using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Planes_Estudios
{
    public class DetallePlan_EstudioModel : PageModel
    {
        ActionsBDPlanesEstudio actions = new ActionsBDPlanesEstudio();

        public void OnGet(string id)
        {
            PlanesEstudioM data = actions.getUnPlan(id);
            Input = new InputModelPlan
            {
                DataUser = data
            };
        }

        public InputModelPlan Input { get; set; }

        public class InputModelPlan
        {
            public PlanesEstudioM DataUser { get; set; }
        }
    }
}
