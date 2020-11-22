using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Matricula.Models;
using Matricula.Areas.Users.Models;
using Matricula.Data;
using Microsoft.AspNetCore.Identity;
using Matricula.Library;
using Matricula.Areas.Principal.Controllers;

namespace Matricula.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SignInManager<IdentityUser> SignInManager;
        private static InputModelLogin _model;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (LUser.login == true)
            {
                return RedirectToAction(nameof(PrincipalController.Principal), "Principal");
            }
            else
            {
                if (_model != null)
                {
                    return View(_model);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public IActionResult Index(InputModelLogin model)
        {
            ActionsBDLogin actionsBDLogin = new ActionsBDLogin();
            _model = model;
            if (ModelState.IsValid)
            {
                int estado = int.Parse(actionsBDLogin.inicioSesion(model.CorreoElectronico, model.Password));
                if (estado == 1)
                {
                    LUser.login = true;
                    LUser.usuario = actionsBDLogin.getUn_Usuario3(model.CorreoElectronico);
                    LUser.nombreCompleto = LUser.usuario.Nombre + " " + LUser.usuario.PrimerApellido;
                    return Redirect("/Principal/Principal");
                }
                else
                {
                    model.ErrorMessage = "Correo o contraseña inválidos";
                    return Redirect("/");
                }
            }
            else
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _model.ErrorMessage = error.ErrorMessage;
                    }
                }
                return Redirect("/");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
