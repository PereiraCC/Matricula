using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Notas.Models;
using Matricula.Controllers;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Matricula.Areas.Notas.Pages.NotasAcademicas
{
    public class RegistroNotasModel : PageModel
    {
        public static InputModelNotaEstudiante _dataInput;
        ActionsBDNotas actions = new ActionsBDNotas();
        public static EstudianteModel data = new EstudianteModel();
        public static string nombreMateria;
        public static string idEstu;

        public void OnGet(string id)
        {
            if(id != null)
            {
                idEstu = id;
            }
            
            string[] codigos = idEstu.Split(",");
            data = actions.getUnEstudiante(codigos[0]);
            data.Nota_Estudiante = actions.getNotaEstudiante(codigos[0], codigos[1]);
            nombreMateria = codigos[1];
            Input_Nota_Estudiante = new InputModelNotaEstudiante
            {
                DataUser = data,
                listaCalificaciones = obtenerListaCalificaciones(),
                Nombre_Materia = nombreMateria
            };
        }

        [BindProperty]
        public InputModelNotaEstudiante Input_Nota_Estudiante { get; set; }

        public class InputModelNotaEstudiante
        {
            public EstudianteModel DataUser { get; set; }

            public List<SelectListItem> listaCalificaciones { get; set; }

            public string Nombre_Materia { get; set; }

            [TempData]
            public string ErrorMessage { get; set; }

        }

        public List<SelectListItem> obtenerListaCalificaciones()
        {
            List<string> notas = new List<string>();
            notas.Add("1");
            notas.Add("2");
            notas.Add("3");
            notas.Add("4");
            notas.Add("5");
            notas.Add("6");
            notas.Add("7");
            notas.Add("8");
            notas.Add("9");
            notas.Add("10");


            List<SelectListItem> LNotas = new List<SelectListItem>();
            foreach (string dato in notas)
            {
                SelectListItem temp = new SelectListItem(dato, dato);
                LNotas.Add(temp);
            }

            return LNotas;
        }

        public IActionResult OnPost()
        {
            if (Input_Nota_Estudiante.DataUser.Nota_Estudiante != null)
            {
                if(!Input_Nota_Estudiante.DataUser.Nota_Estudiante.Equals("Sin Calificacion"))
                {
                    if (registrandoNota() == 0)
                    {
                        if (LUser.usuario == null)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                        else
                        {
                            return Redirect("/principal/principal?area=principal");
                        }
                    }
                    else
                    {
                        return Redirect("/Notas/RegistroNotas");
                    }
                }
                else
                {
                    Input_Nota_Estudiante.ErrorMessage = "Seleccione una nota valida";
                    return Redirect("/Notas/RegistroNotas");
                }
                
            }
            else
            {
                Input_Nota_Estudiante.ErrorMessage = "Seleccione una nota valida";
                return Redirect("/Notas/RegistroNotas");
            }
        }

        public int registrandoNota()
        {
            _dataInput = Input_Nota_Estudiante;
            _dataInput.DataUser.estudiante = data.estudiante;
            _dataInput.Nombre_Materia = nombreMateria;
            int dato = 1;
            int estado = Int32.Parse(actions.registrarNota(_dataInput));
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
