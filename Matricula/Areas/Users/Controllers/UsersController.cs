using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Users.Data;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        public IActionResult Users()
        {
            ActionsBD actions = new ActionsBD();
            actions.getRoles();
            return View();
        }
    }
}
