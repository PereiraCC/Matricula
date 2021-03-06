﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Mantenimiento.Models;

using Matricula.Areas.Matricular.Data;
using Matricula.Areas.Matricular.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Matricular.Controllers
{
    public class MatricularController : Controller
    {
        ActionBDMatricular actions = new ActionBDMatricular();
        public static MatricularM data;
        
        [Area("Matricular")]
        public IActionResult Matricular()
        {
            if(data == null)
            {
                data = new MatricularM();
                data.estudiante = LUser.usuario;
                if (actions.consultarMateriasMatriculadas(LUser.usuario.Identificacion).Equals("0"))
                {
                    data.lista_Materias = actions.getMateriasxCarrera(LUser.usuario.Carrera);
                }
                else
                {
                    data.lista_Materias = actions.getMateriasxCarreraxEstudiante(LUser.usuario.Carrera, LUser.usuario.Identificacion);
                }
                
                data.lista_MateriasMatriculadas = addMateriaMatricula(null,null);
            }
            return View(data);
        }

        public IActionResult addMateria(string id)
        {
            data.estudiante = LUser.usuario;
            if (actions.consultarMateriasMatriculadas(LUser.usuario.Identificacion).Equals("0"))
            {
                data.lista_Materias = actions.getMateriasxCarrera(LUser.usuario.Carrera);
            }
            else
            {
                data.lista_Materias = actions.getMateriasxCarreraxEstudiante(LUser.usuario.Carrera, LUser.usuario.Identificacion);
            }
            data.lista_MateriasMatriculadas = addMateriaMatricula(data.lista_MateriasMatriculadas, id);


            return Redirect("/Matricular/Matricular?area=Matricular");
        }

        public List<MateriasM> addMateriaMatricula(List<MateriasM> m ,string id)
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
