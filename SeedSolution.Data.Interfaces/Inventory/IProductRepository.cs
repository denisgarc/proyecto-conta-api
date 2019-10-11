using SeedSolution.Entity.DB;
using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Interfaces.Inventory
{
    public interface IProductRepository
    {
        List<ProductoDB> GetProduct(int? id = null);
        void SaveProduct(Producto producto);
    }
}
