using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Co_Requesitos
{
    public class DetalleCo_RequesitosModel : PageModel
    {
        ActionsBDCo_Requesitos actions = new ActionsBDCo_Requesitos();
        public void OnGet(string id)
        {
            Co_RequesitosM data = actions.getUnCo_Requesito(id);
            Input = new InputModelCo_Requesitos
            {
                DataUser = data
            };
        }

        public InputModelCo_Requesitos Input { get; set; }

        public class InputModelCo_Requesitos
        {
            public Co_RequesitosM DataUser { get; set; }
        }
    }
}
