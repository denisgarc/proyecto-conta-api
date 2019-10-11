using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Interfaces.Inventory
{
    public interface IOperationRepository
    {
        List<Operacion> GetOperation(int? id = null);
        void SaveOperation(Operacion operation);
    }
}
