using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matricula.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private static InputModel _dataInput;
        ActionsBD actions = new ActionsBD();

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input = _dataInput;
                Input.rolesLista = obtenerRoles();
                Input.carrerasLista = obtenerCarreras();
            }
            else
            {
                Input = new InputModel
                {
                    rolesLista = obtenerRoles(),
                    carrerasLista = obtenerCarreras(),
                };
            }   
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : InputModelRegister
        {
            [TempData]
            public string ErrorMessage { get; set; }

            public List<SelectListItem> rolesLista { get; set; }

            public List<SelectListItem> carrerasLista { get; set; }

        }

        public IActionResult OnPost()
        {
            if (registrando() == 0)
            {
                //Seria un 0 lo enviaria al login
                return Redirect("/Users/Users?area=Users");

            }
            else
            {
                return Redirect("/Users/Register");
            }
        }

        private int registrando()
        {
            _dataInput = Input;
            int dato = 1;

            if (_dataInput.Rol != "Seleccione un Rol")
            {
                int cantidad = Int32.Parse(actions.verificarCorreo(Input.CorreoElectronico));
                if(cantidad == 0)
                {
                    //llamar la accion que nos lleva al sp
                    int estado = Int32.Parse(actions.registrarPersona(_dataInput));
                    if(estado == 0)
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
                    _dataInput.ErrorMessage = $"El {Input.CorreoElectronico} ya esta registrado";
                    dato = 1;
                }
            }
            else
            {
                //Algo mal
                _dataInput.ErrorMessage = "Seleccione un rol";
                dato = 1;
            }
            return dato;
        }

        public List<SelectListItem> obtenerRoles()
        {
            ArrayList data = actions.getRoles();

            List<SelectListItem> roles = new List<SelectListItem>();
            foreach (string dato in data)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                roles.Add(temp);
            }

            return roles;
        }

        public List<SelectListItem> obtenerCarreras()
        {
            ArrayList data = actions.getCarreras();

            List<SelectListItem> carreras = new List<SelectListItem>();
            foreach (string dato in data)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                carreras.Add(temp);
            }

            return carreras;
        }

    }
}
