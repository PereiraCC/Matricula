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
        public static NotasProfesorM data2;

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

        public IActionResult ListadoMateriasProfesorInscriptas(string filtrar)
        {
            if (filtrar == null)
            {
                data2 = new NotasProfesorM();
                data2.profesor = LUser.usuario;
                data2.lista_MateriasInscriptas = actions.getMateriasInscriptas(LUser.usuario.Identificacion);
            }
            else
            {
                data2 = new NotasProfesorM();
                data2.profesor = LUser.usuario;
                data2.lista_MateriasInscriptas = actions.getMateriasInscriptas(LUser.usuario.Identificacion);
                List<MateriasM> datafiltrada = new List<MateriasM>();
                List<MateriasM> resul = buscarMateria(data2.lista_MateriasInscriptas, filtrar);
                foreach (MateriasM temp in resul)
                {
                    if (temp.Nombre != null)
                    {
                        datafiltrada.Add(temp);
                    }
                }
                data2.lista_MateriasInscriptas = datafiltrada;  
            }

            return View(data2);
        }

        public List<MateriasM> buscarMateria(List<MateriasM> data, string filtro)
        {
            List<MateriasM> resul = new List<MateriasM>();
            foreach (MateriasM temp in data)
            {
                if (temp.Nombre.Equals(filtro))
                {
                    MateriasM tempe = new MateriasM();
                    tempe.Codigo_Materia = temp.Codigo_Materia;
                    tempe.Nombre = temp.Nombre;
                    tempe.Descripcion = temp.Descripcion;
                    tempe.Creditos = temp.Creditos;
                    tempe.Nombre_Requesito = temp.Nombre_Requesito;
                    tempe.NombreCo_Requesito = temp.NombreCo_Requesito;

                    resul.Add(tempe);
                }
            }

            return resul;
        }
    }
}
