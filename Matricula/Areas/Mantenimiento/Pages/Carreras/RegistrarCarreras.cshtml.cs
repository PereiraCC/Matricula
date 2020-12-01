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

namespace Matricula.Areas.Mantenimiento.Pages.Carreras
{
    public class RegistrarCarrerasModel : PageModel
    {
        public static InputModelCarreras _dataInput;
        ActionsBDCarreras actions = new ActionsBDCarreras();
        private static CarrerasM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Carreras = _dataInput;
            }
            else
            {
                Input_Carreras = new InputModelCarreras();
            }

            if (_dataUser1 != null)
            {
                Input_Carreras = new InputModelCarreras
                {
                    Codigo_Carrera = _dataUser1.Codigo_Carrera,
                    Nombre_Carrera = _dataUser1.Nombre_Carrera,
                    Descripcion_Carrera = _dataUser1.Descripcion_Carrera
                };
            }

        }

        [BindProperty]
        public InputModelCarreras Input_Carreras { get; set; }

        public class InputModelCarreras : CarrerasM
        {
        }

        public IActionResult OnPost(string dataCarrera)
        {
            if (dataCarrera == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoCarrera() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/listadoCarreras?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_Carreras");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoCarrera() == 0)
                        {
                            return Redirect("/Mantenimiento/listadoCarreras?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/Register_Carreras");
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
                _dataUser1 = JsonConvert.DeserializeObject<CarrerasM>(dataCarrera);
                return Redirect("/Mantenimiento/Register_Carreras");
            }
        }

        public int registrandoCarrera()
        {
            _dataInput = Input_Carreras;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoCarrera(_dataInput.Codigo_Carrera));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarCarrera(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Carreras.Codigo_Carrera} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        public int modificandoCarrera()
        {
            _dataInput = Input_Carreras;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarCarrera(_dataInput));
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
