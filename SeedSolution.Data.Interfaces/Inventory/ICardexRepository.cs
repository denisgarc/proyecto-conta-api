using SeedSolution.Entity.DB;
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
        List<CardexDB> GetCardex(int? id = null);
        List<CardexDB> GetCardexFiltered(DateTime startDate, DateTime finishDate, int? branch = null, int? product = null);
        void SaveCardex(Cardex cardex);
    }
}
