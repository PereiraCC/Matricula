using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Matricula.Controllers;
using Matricula.Library;
using Matricula.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        ActionsBD actions = new ActionsBD();
        public IActionResult Users(string filtrar)
        {
            if(LUser.login == true)
            {
                DataPaginador<InputModelRegister> data = new DataPaginador<InputModelRegister>();
                if (filtrar == null)
                {
                    data.List = actions.getUsuarios();
                    return View(data);
                }
                else
                {
                    data.List = actions.getUn_Usuario2(filtrar);
                    return View(data);
                }
            }
            else
            {
                return Redirect("/");
            }
           
        }

        public IActionResult Logout()
        {
            LUser.login = false;
            LUser.usuario = null;
            LUser.nombreCompleto = "";
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
