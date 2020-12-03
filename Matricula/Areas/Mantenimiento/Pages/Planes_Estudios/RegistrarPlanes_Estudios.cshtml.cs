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

namespace Matricula.Areas.Mantenimiento.Pages.Planes_Estudios
{
    public class RegistrarPlanes_EstudiosModel : PageModel
    {
        public static InputModelPlanesEstudio _dataInput;
        ActionsBDPlanesEstudio actions = new ActionsBDPlanesEstudio();
        private static PlanesEstudioM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Plan = _dataInput;
            }
            else
            {
                Input_Plan = new InputModelPlanesEstudio
                {
                    lista_Carreras = obtenerListaCarreras()
                };
            }

            if (_dataUser1 != null)
            {
                Input_Plan = new InputModelPlanesEstudio
                {
                    Codigo_Plan = _dataUser1.Codigo_Plan,
                    Nombre_Plan = _dataUser1.Nombre_Plan,
                    Descripcion_Plan = _dataUser1.Descripcion_Plan,
                    Nombre_Carrera = _dataUser1.Nombre_Carrera,
                    lista_Carreras = obtenerListaCarreras()
                };
            }

        }

        [BindProperty]
        public InputModelPlanesEstudio Input_Plan { get; set; }

        public class InputModelPlanesEstudio : PlanesEstudioM
        {
            public List<SelectListItem> lista_Carreras { get; set; }
        }

        public IActionResult OnPost(string dataPlan)
        {
            if (dataPlan == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoPlanEstudio() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoPlanes_Estudios?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_PlanesEstudio");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoPlan() == 0)
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoPlanes_Estudios?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/Register_PlanesEstudio");
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
                _dataUser1 = JsonConvert.DeserializeObject<PlanesEstudioM>(dataPlan);
                return Redirect("/Mantenimiento/Register_PlanesEstudio");
            }
        }

        private int registrandoPlanEstudio()
        {
            _dataInput = Input_Plan;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoPlan(_dataInput.Codigo_Plan));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarPlan(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Plan.Codigo_Plan} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        public int modificandoPlan()
        {
            _dataInput = Input_Plan;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarPlan(_dataInput));
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

        public List<SelectListItem> obtenerListaCarreras()
        {
            List<string> carreras = actions.getCarreras();
            List<SelectListItem> LCarreras = new List<SelectListItem>();
            foreach (string dato in carreras)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                LCarreras.Add(temp);
            }

            return LCarreras;
        }
    }
}
