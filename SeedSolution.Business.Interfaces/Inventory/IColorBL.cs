using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Business.Interfaces.Inventory
{
    public interface IColorBL
    {
        List<Color> GetColor(int? id = null);
        void SaveColor(Color color);
    }
}
