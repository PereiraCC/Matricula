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

namespace Matricula.Areas.Mantenimiento.Pages.Periodos
{
    public class RegistrarPeriodosModel : PageModel
    {
        public static InputModelPeriodos _dataInput;
        ActionsBDPeriodos actions = new ActionsBDPeriodos();
        private static PeriodosM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Periodos = _dataInput;
            }
            else
            {
                Input_Periodos = new InputModelPeriodos
                {
                    Annos = obtenerAnnos()
                };
            }

            if (_dataUser1 != null)
            {
                Input_Periodos = new InputModelPeriodos
                {
                    Codigo_Periodo = _dataUser1.Codigo_Periodo,
                    Nombre_Periodo = _dataUser1.Nombre_Periodo,
                    Nombre_Anno = _dataUser1.Nombre_Anno,
                    Annos = obtenerAnnos()
                };
            }

        }

        [BindProperty]
        public InputModelPeriodos Input_Periodos { get; set; }

        public class InputModelPeriodos : PeriodosM 
        {
            public List<SelectListItem> Annos { get; set; }

        }

        public IActionResult OnPost(string dataPeriodo)
        {
            if (dataPeriodo == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoPeriodo() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoPeriodos?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_Periodos");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoPeriodo() == 0)
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoPeriodos?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/Register_Horarios");
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
                _dataUser1 = JsonConvert.DeserializeObject<PeriodosM>(dataPeriodo);
                return Redirect("/Mantenimiento/Register_Periodos");
            }
        }

        public int registrandoPeriodo()
        {
            _dataInput = Input_Periodos;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoPeriodo(_dataInput.Codigo_Periodo));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarPeriodo(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Periodos.Codigo_Periodo} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        public int modificandoPeriodo()
        {
            _dataInput = Input_Periodos;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarPeriodo(_dataInput));
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

        public List<SelectListItem> obtenerAnnos()
        {
            List<string> LAnnos = actions.getAnnos();

            List<SelectListItem> Annos = new List<SelectListItem>();
            foreach (string dato in LAnnos)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                Annos.Add(temp);
            }

            return Annos;
        }
    }
}
