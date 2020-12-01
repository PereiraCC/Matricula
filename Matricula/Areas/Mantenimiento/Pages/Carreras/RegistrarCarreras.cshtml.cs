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

namespace Matricula.Areas.Mantenimiento.Pages.Carreras
{
    public class RegistrarCarrerasModel : PageModel
    {
        public static InputModelCarreras _dataInput;
        ActionsBDCarreras actions = new ActionsBDCarreras();
        private static MateriasM _dataUser1;

        public void OnGet()
        {
            Input_Carreras = new InputModelCarreras();
        }

        [BindProperty]
        public InputModelCarreras Input_Carreras { get; set; }

        public class InputModelCarreras : CarrerasM
        {
        }

        public IActionResult OnPost()
        {
            if (registrandoCarrera() == 0)
            {
                if (LUser.usuario == null)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    //Retornar al listado de carreras
                    return Redirect("/Mantenimiento/listadoMaterias?area=Mantenimiento");
                }
            }
            else
            {
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
    }
}
