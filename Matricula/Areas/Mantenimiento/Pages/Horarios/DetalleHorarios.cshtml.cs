using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Data;
using Matricula.Areas.Mantenimiento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Matricula.Areas.Mantenimiento.Pages.Horarios
{
    public class DetalleHorariosModel : PageModel
    {
        ActionsBDHorarios actions = new ActionsBDHorarios();
        ActionsBDPeriodos actionsP = new ActionsBDPeriodos();

        public void OnGet(string id)
        {
            HorariosM data = actions.getUnHorario(id);
            data.Nombre_Periodo = obtenerUnPeriodo(data.Nombre_Periodo);
            Input = new InputModelHorarios
            {
                DataUser = data
            };
        }

        public InputModelHorarios Input { get; set; }

        public class InputModelHorarios
        {
            public HorariosM DataUser { get; set; }
        }

        public string obtenerUnPeriodo(string id)
        {
            string resul = "";
            List<PeriodosM> periodos = actionsP.getPeriodos();

            foreach (PeriodosM dato in periodos)
            {
                if (dato.Codigo_Periodo.Equals(id))
                {
                    resul = dato.Nombre_Periodo + " " + dato.Nombre_Anno;
                    break;
                }
            }

            return resul;
        }
    }
}
