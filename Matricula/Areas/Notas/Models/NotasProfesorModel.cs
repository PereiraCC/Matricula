using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Users.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Notas.Models
{
    public class NotasProfesorM
    {
        public InputModelRegister profesor { get; set; }

        public List<MateriasM> listaMateriasxCarrera { get; set; }

        public List<MateriasM> lista_MateriasInscriptas { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
