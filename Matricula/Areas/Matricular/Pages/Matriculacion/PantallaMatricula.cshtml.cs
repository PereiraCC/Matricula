using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Matricular.Data;
using Matricula.Areas.Matricular.Models;
using Matricula.Controllers;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Matricula.Areas.Matricular.Pages.Matriculacion
{
    public class PantallaMatriculaModel : PageModel
    {
        public static InputModelMatricula _dataInput;
        ActionsBDPeriodos actionsP = new ActionsBDPeriodos();
        ActionBDMatricular action = new ActionBDMatricular();
        private static MatricularM _dataUser1;

        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input_Matricula = _dataInput;
            }
            else
            {
                Input_Matricula = new InputModelMatricula
                {
                    Lista_Periodos = obtenerPeriodos(),
                };
            }

            if (_dataUser1 != null)
            {
                Input_Matricula = new InputModelMatricula
                {
                    estudiante = _dataUser1.estudiante,
                    lista_Materias = _dataUser1.lista_Materias,
                    lista_MateriasMatriculadas = _dataUser1.lista_MateriasMatriculadas,
                    Lista_Periodos = obtenerPeriodos(),
                };
            }
            
        }

        [BindProperty]
        public InputModelMatricula Input_Matricula { get; set; }

        public class InputModelMatricula : MatricularM
        {
            public List<SelectListItem> Lista_Periodos { get; set; }
        }

        public IActionResult OnPost(string dataMatricula)
        {
            if(dataMatricula == null)
            {
                if (registrandoMatricula() == 0)
                {
                    if (LUser.usuario == null)
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else
                    {
                        _dataInput = null;
                        _dataUser1 = null;
                        return Redirect("/Matricular/Matricular?area=Matricular");
                    }
                }
                return Redirect("/Matricular/Pantalla_Matricula");
            }
            else
            {
                _dataUser1 = JsonConvert.DeserializeObject<MatricularM>(dataMatricula);
                return Redirect("/Matricular/Pantalla_Matricula");
            }
            
        }

        public int registrandoMatricula()
        {
            _dataInput = Input_Matricula;
            _dataInput.lista_MateriasMatriculadas = _dataUser1.lista_MateriasMatriculadas;
            string[] temp = _dataInput.Nombre_Periodo.Split(" ");
            _dataInput.Nombre_Periodo = temp[0] + " " + temp[1];
            int dato = 1;

            int estado = Int32.Parse(action.registrarMatricular(_dataInput));
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

        public List<SelectListItem> obtenerPeriodos()
        {
            List<PeriodosM> periodos = actionsP.getPeriodos();

            List<SelectListItem> LPeriodos = new List<SelectListItem>();
            foreach (PeriodosM dato in periodos)
            {
                SelectListItem temp = new SelectListItem(dato.Nombre_Periodo + " " + dato.Nombre_Anno, dato.Nombre_Periodo + " " + dato.Nombre_Anno);
                LPeriodos.Add(temp);
            }

            return LPeriodos;
        }
    }
}
