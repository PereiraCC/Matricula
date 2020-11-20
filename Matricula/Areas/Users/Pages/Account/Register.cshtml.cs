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
using Newtonsoft.Json;

namespace Matricula.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public static InputModel _dataInput;
        ActionsBD actions = new ActionsBD();
        private static InputModelRegister _dataUser1, _dataUser2;

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

            if(_dataUser1 != null)
            {
                Input = new InputModel
                {
                    Identificacion = _dataUser1.Identificacion,
                    Nombre = _dataUser1.Nombre,
                    PrimerApellido = _dataUser1.PrimerApellido,
                    SegundoApellido = _dataUser1.SegundoApellido,
                    FechaNacimiento = _dataUser1.FechaNacimiento,
                    CorreoElectronico = _dataUser1.CorreoElectronico,
                    Telefono = _dataUser1.Telefono,
                    Direccion = _dataUser1.Direccion,
                    Password = _dataUser1.Password,
                    Rol = _dataUser1.Rol,
                    Carrera = _dataUser1.Carrera,
                    rolesLista = obtenerRol(_dataUser1.Rol),
                    carrerasLista = obtenerCarrera(_dataUser1.Carrera)
                };
            }
            //_dataUser2 = _dataUser1;
            //_dataUser1 = null;
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

        public IActionResult OnPost(string dataUser)
        {
            if(dataUser == null)
            {
                if(_dataUser1 == null)
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
                else
                {
                    if (modificando() == 0)
                    {
                        return Redirect("/Users/Users?area=Users");
                    }
                    else
                    {
                        return Redirect("/Users/Register");
                    }
                }
               
            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<InputModelRegister>(dataUser);
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

        private int modificando()
        {
            _dataInput = Input;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarPersona(_dataInput));
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

        public List<SelectListItem> obtenerRol(string rol)
        {
            List<SelectListItem> rolesLista = new List<SelectListItem>();
            rolesLista.Add(new SelectListItem
            {
                Value = rol,
                Text = rol
            });

            return rolesLista;
        }

        public List<SelectListItem> obtenerCarrera(string carrera)
        {
            List<SelectListItem> carreraLista = new List<SelectListItem>();
            carreraLista.Add(new SelectListItem
            {
                Value = carrera,
                Text = carrera
            });

            return carreraLista;
        }

    }
}
