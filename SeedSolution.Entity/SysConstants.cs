using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Entity
{
    public enum SysActionType
    {
        Consulta = 1,
        Adicion = 2,
        Edicion = 3,
        Eliminar = 4
    }
    public enum SysLogType
    {
        Informativo = 1,
        Alerta = 2,
        Error = 3
    }
}
