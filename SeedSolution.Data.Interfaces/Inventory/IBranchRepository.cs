using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Interfaces.Inventory
{
    public interface IBranchRepository
    {
        List<Sucursal> GetBranch(int? id = null);
        void SaveBranch(Sucursal branch);
    }
}
