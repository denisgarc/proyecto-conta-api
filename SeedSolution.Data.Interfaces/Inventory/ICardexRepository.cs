using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Interfaces.Inventory
{
    public interface ICardexRepository
    {
        List<Cardex> GetCardex(int? id = null);
        void SaveCardex(Cardex cardex);
    }
}
