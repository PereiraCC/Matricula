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

namespace Matricula.Areas.Mantenimiento.Pages.Materias
{
    public class RegistrarMateriasModel : PageModel
    {
        public static InputModelMaterias _dataInput;
        ActionsBDMaterias actions = new ActionsBDMaterias();
        private static MateriasM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Materias = _dataInput;
            }
            else
            {
                Input_Materias = new InputModelMaterias
                {
                    lista_Creditos = obtenerListaCreditos(),
                    lista_Requesitos = obtenerListaRequesitos(),
                    lista_CoRequesitos = obtenerListaCo_Requesitos()
                };
            }

            if (_dataUser1 != null)
            {
                Input_Materias = new InputModelMaterias
                {
                    Codigo_Materia = _dataUser1.Codigo_Materia,
                    Nombre = _dataUser1.Nombre,
                    Descripcion = _dataUser1.Descripcion,
                    Creditos = _dataUser1.Creditos,
                    Nombre_Requesito = _dataUser1.Nombre_Requesito,
                    NombreCo_Requesito = _dataUser1.NombreCo_Requesito,
                    lista_Creditos = obtenerListaCreditos(),
                    lista_Requesitos = obtenerListaRequesitos(),
                    lista_CoRequesitos = obtenerListaCo_Requesitos()
                };
            }

        }

        [BindProperty]
        public InputModelMaterias Input_Materias { get; set; }

        public class InputModelMaterias : MateriasM
        {
            public List<SelectListItem> lista_Creditos { get; set; }

            public List<SelectListItem> lista_Requesitos { get; set; }

            public List<SelectListItem> lista_CoRequesitos { get; set; }

        }

        public IActionResult OnPost(string dataMateria)
        {
            if (dataMateria == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoMateria() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/listadoMaterias?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_Materias");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoMateria() == 0)
                        {
                            return Redirect("/Mantenimiento/listadoMaterias?area=Mantenimiento");
                        }
                        else
                        {
                            return Redirect("/Mantenimiento/Register_Materias");
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
                _dataUser1 = JsonConvert.DeserializeObject<MateriasM>(dataMateria);
                return Redirect("/Mantenimiento/Register_Materias");
            }
        }

        public int registrandoMateria()
        {
            _dataInput = Input_Materias;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoMateria(_dataInput.Codigo_Materia));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarMateria(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Materias.Codigo_Materia} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        public int modificandoMateria()
        {
            _dataInput = Input_Materias;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarMateria(_dataInput));
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

        public List<SelectListItem> obtenerListaCreditos()
        {
            List<string> cre = new List<string>();
            cre.Add("1");
            cre.Add("2");
            cre.Add("3");

            List<SelectListItem> Lcreditos = new List<SelectListItem>();
            foreach (string dato in cre)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                Lcreditos.Add(temp);
            }

            return Lcreditos;
        }

        public List<SelectListItem> obtenerListaRequesitos()
        {
            List<string> reque = actions.getRequesitos();
            List<SelectListItem> Lrequesitos = new List<SelectListItem>();
            foreach (string dato in reque)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                Lrequesitos.Add(temp);
            }

            return Lrequesitos;
        }

        public List<SelectListItem> obtenerListaCo_Requesitos()
        {
            List<string> co_reque = actions.getCo_Requesitos();
            List<SelectListItem> Lco_requesitos = new List<SelectListItem>();
            foreach (string dato in co_reque)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                Lco_requesitos.Add(temp);
            }

            return Lco_requesitos;
        }
    }
}
