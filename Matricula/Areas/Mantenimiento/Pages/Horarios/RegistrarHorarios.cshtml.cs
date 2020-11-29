using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matricula.Areas.Mantenimiento.Pages.Horarios
{
    public class RegistrarHorariosModel : PageModel
    {
        public void OnGet()
        {
            Input_Horarios = new InputModelHorarios
            {
                dias = obtenerDias(),
                Horas_Iniciales = obtenerHoras_Iniciales(),
                Horas_Finales = obtenerHoras_Finales()
            };
        }

        [BindProperty]
        public InputModelHorarios Input_Horarios { get; set; }

        public class InputModelHorarios : HorariosModel
        {
            public List<SelectListItem> dias { get; set; }

            public List<SelectListItem> Horas_Iniciales { get; set; }

            public List<SelectListItem> Horas_Finales { get; set; }

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
