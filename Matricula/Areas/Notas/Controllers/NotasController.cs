using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Notas.Data;
using Matricula.Areas.Notas.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Notas.Controllers
{
    [Area("Notas")]
    public class NotasController : Controller
    {
        ActionsBDNotas actions = new ActionsBDNotas();
        public static NotasProfesorM data;

        public IActionResult ListaMateriasProfesor()
        {
            if (data == null)
            {
                data = new NotasProfesorM();
                data.profesor = LUser.usuario;
                data.listaMateriasxCarrera = actions.getMateriasxCarrera(LUser.usuario.Carrera);

                data.lista_MateriasInscriptas = addMateriaMatricula(null, null);
            }
            return View(data);
            
        }

        public IActionResult addMateria(string id)
        {
            data.profesor = LUser.usuario;
            data.listaMateriasxCarrera = actions.getMateriasxCarrera(LUser.usuario.Carrera);
            data.lista_MateriasInscriptas = addMateriaMatricula(data.lista_MateriasInscriptas, id);

            return Redirect("/Notas/ListaMateriasProfesor?area=Notas");
        }

        public List<MateriasM> addMateriaMatricula(List<MateriasM> m, string id)
        {
            List<MateriasM> materiasTemp;

            if (m == null)
            {
                materiasTemp = new List<MateriasM>();
            }
            else
            {
                materiasTemp = m;
            }


            if (id != null)
            {
                MateriasM materia = actions.getUnaMateria(id);
                materiasTemp.Add(materia);
            }

            return materiasTemp;
        }

        
    }
}
