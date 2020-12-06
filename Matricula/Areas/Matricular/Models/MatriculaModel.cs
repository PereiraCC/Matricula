using Matricula.Areas.Mantenimiento.Models;
using Matricula.Areas.Users.Models;
using Matricula.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matricula.Areas.Matricular.Models
{
    public class MatricularM : LUser
    {
        public InputModelRegister estudiante { get; set; }

        public List<MateriasM> lista_Materias { get; set; }

        public List<MateriasM> lista_MateriasMatriculadas { get; set; }
    }
}
