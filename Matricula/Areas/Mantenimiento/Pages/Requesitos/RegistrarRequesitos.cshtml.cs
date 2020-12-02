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
using Newtonsoft.Json;

namespace Matricula.Areas.Mantenimiento.Pages.Requesitos
{
    public class Registrar_RequesitosModel : PageModel
    {
        public static InputModelRequesitos _dataInput;
        ActionsBDRequesitos actions = new ActionsBDRequesitos();
        private static RequesitosM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Requesitos = _dataInput;
            }
            else
            {
                Input_Requesitos = new InputModelRequesitos();
            }

            if (_dataUser1 != null)
            {
                Input_Requesitos = new InputModelRequesitos
                {
                    Codigo_Requesito = _dataUser1.Codigo_Requesito,
                    Nombre_Requesito = _dataUser1.Nombre_Requesito
                };
            }
        }

        [BindProperty]
        public InputModelRequesitos Input_Requesitos { get; set; }

        public class InputModelRequesitos : RequesitosM
        {
        }

        public IActionResult OnPost(string dataRequesito)
        {
            if(dataRequesito == null)
            {
                if(_dataUser1 == null)
                {
                    if (registrandoRequesito() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            _dataInput = null;
                            return Redirect("/Mantenimiento/listadoRequesitos?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_Requesitos");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoRequesito() == 0)
                        {
                            _dataInput = null;
                            return Redirect("/Mantenimiento/listadoRequesitos?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/Register_Requesitos");
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
                _dataUser1 = JsonConvert.DeserializeObject<RequesitosM>(dataRequesito);
                return Redirect("/Mantenimiento/Register_Requesitos");
            }
            
        }

        public int registrandoRequesito()
        {
            _dataInput = Input_Requesitos;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoRequesito(_dataInput.Codigo_Requesito));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarRequesito(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Requesitos.Codigo_Requesito} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        private int modificandoRequesito()
        {
            _dataInput = Input_Requesitos;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarRequesito(_dataInput));
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
