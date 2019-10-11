using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Business.Interfaces.Inventory
{
    public interface IOperationBL
    {
        List<Operacion> GetOperation(int? id = null);
        void SaveOperation(Operacion operation);
    }
}
