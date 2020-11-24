using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matricula.Areas.Mantenimiento.Pages.Co_Requesitos
{
    public class Co_RequesitosModel : PageModel
    {
        public static InputModelCo_Requesitos _dataInput;
        //ActionsBD actions = new ActionsBD();
        private static Co_RequesitosM _dataUser1;

        public void OnGet()
        {
            InputCo_Requesitos = new InputModelCo_Requesitos();

        }

        [BindProperty]
        public InputModelCo_Requesitos InputCo_Requesitos { get; set; }

        public class InputModelCo_Requesitos : Co_RequesitosM
        {
            public List<SelectListItem> listaCo_Requesitos { get; set; }

        }

        //public IActionResult OnPost()
        //{
        //    //Llamar al metodo "registrandoCo_Requesito"
        //}

        //private int registrandoCo_Requesito()
        //{
        //    //Llamar el metodo de comprobar el codigo de Co_Requesito y llamar el metodo de registrar de clase ActionsBDMantenimiento
        //    //Hacer la clase ActionsBDMantenimiento
        //}
    }
}
