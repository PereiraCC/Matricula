using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.Areas.Users.Data;
using Matricula.Areas.Users.Models;
using Matricula.Library;
using Matricula.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matricula.Areas.Users.Controllers
{
    [Area("Users")]
    public class UsersController : Controller
    {
        ActionsBD actions = new ActionsBD();
        public IActionResult Users(string filtrar)
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


    }
}
