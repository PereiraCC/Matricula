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

namespace Matricula.Areas.Mantenimiento.Pages.Horarios
{
    public class RegistrarHorariosModel : PageModel
    {
        public static InputModelHorarios _dataInput;
        ActionsBDHorarios actions = new ActionsBDHorarios();
        ActionsBDPeriodos actionsP = new ActionsBDPeriodos();
        private static HorariosM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Horarios = _dataInput;
            }
            else
            {
                Input_Horarios = new InputModelHorarios
                {
                    dias = obtenerDias(),
                    Horas_Iniciales = obtenerHoras_Iniciales(),
                    Horas_Finales = obtenerHoras_Finales(),
                };
            }

            if (_dataUser1 != null)
            {
                Input_Horarios = new InputModelHorarios
                {
                    Codigo_Horario = _dataUser1.Codigo_Horario,
                    Dia = _dataUser1.Dia,
                    Hora_Inicial = _dataUser1.Hora_Inicial,
                    Hora_Final = _dataUser1.Hora_Final,
                    dias = obtenerDias(),
                    Horas_Iniciales = obtenerHoras_Iniciales(),
                    Horas_Finales = obtenerHoras_Finales(),
                };
            }
            
        }

        [BindProperty]
        public InputModelHorarios Input_Horarios { get; set; }

        public class InputModelHorarios : HorariosM
        {
            public List<SelectListItem> dias { get; set; }

            public List<SelectListItem> Horas_Iniciales { get; set; }

            public List<SelectListItem> Horas_Finales { get; set; }

        }

        public IActionResult OnPost(string dataHorario)
        {
            if (dataHorario == null)
            {
                if (_dataUser1 == null)
                {
                    if (registrandoHorario() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoHorarios?area=Mantenimiento");
                        }
                    }
                    else
                    {
                        return Redirect("/Mantenimiento/Register_Horarios");
                    }
                }
                else
                {
                    if (LUser.usuario.Rol.Equals("Admin"))
                    {
                        if (modificandoHorario() == 0)
                        {
                            _dataInput = null;
                            _dataUser1 = null;
                            return Redirect("/Mantenimiento/listadoHorarios?area=Mantenimiento");
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
                _dataUser1 = JsonConvert.DeserializeObject<HorariosM>(dataHorario);
                return Redirect("/Mantenimiento/Register_Horarios");
            }

        }

        public int registrandoHorario()
        {
            _dataInput = Input_Horarios;
            int dato = 1;

            int cantidad = Int32.Parse(actions.verificarCodigoHorario(_dataInput.Codigo_Horario));
            if (cantidad == 0)
            {
                int estado = Int32.Parse(actions.registrarHorario(_dataInput));
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
                _dataInput.ErrorMessage = $"El {Input_Horarios.Codigo_Horario} ya esta registrado";
                dato = 1;
            }

            return dato;
        }

        public int modificandoHorario()
        {
            _dataInput = Input_Horarios;
            int dato = 1;

            int estado = Int32.Parse(actions.modificarHorario(_dataInput));
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

        public List<SelectListItem> obtenerDias()
        {
            List<string> ndias = llenarDias();

            List<SelectListItem> dias = new List<SelectListItem>();
            foreach (string dato in ndias)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                dias.Add(temp);
            }

            return dias;
        }

        public List<string> llenarDias()
        {
            List<string> ndias = new List<string>();
            ndias.Add("Lunes");
            ndias.Add("Martes");
            ndias.Add("Miercoles");
            ndias.Add("Jueves");
            ndias.Add("Viernes");
            ndias.Add("Sabado");

            return ndias;
        }

        public List<SelectListItem> obtenerHoras_Iniciales()
        {
            List<string> horas = new List<string>();
            horas.Add("8:00");
            horas.Add("13:00");
            horas.Add("18:00");

            List<SelectListItem> horas_Iniciales = new List<SelectListItem>();
            foreach (string dato in horas)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                horas_Iniciales.Add(temp);
            }

            return horas_Iniciales;
        }

        public List<SelectListItem> obtenerHoras_Finales()
        {
            List<string> horas = new List<string>();
            horas.Add("11:40");
            horas.Add("16:40");
            horas.Add("21:40");

            List<SelectListItem> horas_Finales = new List<SelectListItem>();
            foreach (string dato in horas)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                horas_Finales.Add(temp);
            }

            return horas_Finales;
        }

    }
}
