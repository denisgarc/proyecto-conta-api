using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Interfaces.Inventory
{
    public interface IColorRepository
    {
        List<Color> GetColor(int? id = null);
        void SaveColor(Color color);
    }
}
