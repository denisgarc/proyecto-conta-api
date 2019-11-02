using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Business.Interfaces.Inventory
{
    public interface ICardexBL
    {
        List<Cardex> GetCardex(int? id = null);
        List<Cardex> GetCardexFiltered(DateTime startDate, DateTime finishDate, int? branch = null, int? product = null);
        void SaveCardex(Cardex cardex);
        string GetError();
        bool GetStatus();
    }
}
