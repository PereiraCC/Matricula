using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Requesitos
{
    public class DetalleRequesitosModel : PageModel
    {
        ActionsBDRequesitos actions = new ActionsBDRequesitos();
        public void OnGet(string id)
        {
            RequesitosM data = actions.getUnRequesito(id);
            Input = new InputModelRequesitos
            {
                DataUser = data
            };
        }

        public InputModelRequesitos Input { get; set; }

        public class InputModelRequesitos
        {
            public RequesitosM DataUser { get; set; }
        }
    }
}
