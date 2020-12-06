using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Matricular.Models;
using Matricula.Library;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Matricular.Controllers
{
    public class MatricularController : Controller
    {
        [Area("Matricular")]
        public IActionResult Matricular()
        {
            MatricularM data = new MatricularM();
            data.estudiante = LUser.usuario;
            return View(data);
        }
    }
}
