using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeedSolution.Entity.Inventory;

namespace SeedSolution.Business.Interfaces.Inventory
{
    public interface IUserPaymentBL
    {
        void SavePayment(Payment pUserPayment);
        List<Payment> SearchPayment(int pClientId);
        bool Status();
        string Message();
    }
}
