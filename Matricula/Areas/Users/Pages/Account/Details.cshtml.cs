using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Users.Pages.Account
{
    public class DetailsModel : PageModel
    {
        ActionsBD actions = new ActionsBD();
        public void OnGet(string id)
        {
            InputModelRegister data = actions.getUn_Usuario(id);
            Input = new InputModel
            {
                DataUser = data
            };
        }

        public InputModel Input { get; set; }

        public class InputModel
        {
            public InputModelRegister DataUser { get; set; }
        }
    }
}
