using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeedSolution.Entity.Inventory;

namespace SeedSolution.Business.Interfaces.Inventory
{
    public interface IUserMaintBL
    {
        void SaveClient(Client pClient);
        Client SearchClient(string document_number);
        bool Status();
        string Message();

    }
}
