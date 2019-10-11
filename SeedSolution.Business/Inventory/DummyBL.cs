using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeedSolution.Business.Interfaces.Inventory;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Entity.Inventory;

namespace SeedSolution.Business.Inventory
{
    public class DummyBL : IUserMaintBL, IUserPaymentBL
    {
        private IUserMaint _userMaint;
        private IUserPayment _paymentMaint;

        public DummyBL()
        {
            _userMaint = StructureMap.ObjectFactory.GetInstance<IUserMaint>();
            _paymentMaint = StructureMap.ObjectFactory.GetInstance<IUserPayment>();
        }

        private bool ResponseStatus { get; set; }
        private string ResponseMessage { get; set; }

        public void SaveClient(Client pClient)
        {
            this._userMaint.SaveClient(pClient);
            this.ResponseStatus = this._userMaint.Status();
            this.ResponseMessage = this._userMaint.Message();
        }

        public Client SearchClient(string document_number)
        {
            return this._userMaint.SearchClient(document_number);
        }

        public void SavePayment(Payment pUserPayment)
        {
            this._paymentMaint.SavePayment(pUserPayment);
        }

        public List<Payment> SearchPayment(int pClientId)
        {
            return this._paymentMaint.SearchPayment(pClientId);
        }
        public bool Status()
        {
            return ResponseStatus;
        }
        public string Message()
        {
            return this.ResponseMessage;
        }
    }
}
