using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Controllers;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Matricula.Areas.Mantenimiento.Pages.Co_Requesitos
{
    public class Co_RequesitosModel : PageModel
    {
        public static InputModelCo_Requesitos _dataInput;
        ActionsBDCo_Requesitos actions = new ActionsBDCo_Requesitos();
        private static Co_RequesitosM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                InputCo_Requesitos = _dataInput;
            }
            else
            {
                InputCo_Requesitos = new InputModelCo_Requesitos();
            }

            if (_dataUser1 != null)
            {
                InputCo_Requesitos = new InputModelCo_Requesitos
                {
                    Codigo_CoRequesito = _dataUser1.Codigo_CoRequesito,
                    Nombre = _dataUser1.Nombre
                };
            }
        }

        [BindProperty]
        public InputModelCo_Requesitos InputCo_Requesitos { get; set; }

        public class InputModelCo_Requesitos : Co_RequesitosM
        {
            public List<SelectListItem> listaCo_Requesitos { get; set; }

        }

        public IActionResult OnPost(string dataCo_Requesito)
        {
            if (dataCo_Requesito == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoCo_Requesito() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            _dataInput = null;
                            return Redirect("/Mantenimiento/Mantenimiento?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/RegisterCo_Requesitos");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificando() == 0)
                        {
                            _dataInput = null;
                            return Redirect("/Mantenimiento/listadoCo_Requesitos?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/RegisterCo_Requesitos");
                        }
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }
            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<Co_RequesitosM>(dataCo_Requesito);
                return Redirect("/Mantenimiento/RegisterCo_Requesitos");
            }
        }

        private int registrandoCo_Requesito()
        {
            _dataInput = InputCo_Requesitos;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoCo_Requesito(_dataInput.Codigo_CoRequesito));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarCo_Requesito(_dataInput));
                if (estado == 0)
                {
                    dato = 0;
                }
                else
                {
                    dato = 1;
                }
            }
            else
            {
                _dataInput.ErrorMessage = $"El {InputCo_Requesitos.Codigo_CoRequesito} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        private int modificando()
        {
            _dataInput = InputCo_Requesitos;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarCo_Requesito(_dataInput));
            if (estado == 0)
            {
                dato = 0;
            }
            else
            {
                dato = 1;
            }
            return dato;
        }
    }
}
