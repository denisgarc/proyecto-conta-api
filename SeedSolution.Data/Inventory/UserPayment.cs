using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Data.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Entity.Inventory;

namespace SeedSolution.Data.Inventory
{
    public class UserPayment : IUserPayment
    {
        private IConnectionTools tools;
        private string ResponseMessage { get; set; }
        private bool ResponseStatus { get; set; }

        public UserPayment()
        {
            tools = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
            ResponseStatus = false;
            ResponseMessage = string.Empty;
        }

        public void SavePayment(Payment pPayment)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "save_payment"
                };
                cmd.Parameters.Add("@client_id", SqlDbType.Int).Value = pPayment.client_id;
                cmd.Parameters.Add("@transaction_amount", SqlDbType.Money).Value = pPayment.transaction_amount;
                tools.Getds(cmd);
                ResponseStatus = tools.Status();
                ResponseMessage = string.IsNullOrEmpty(tools.Error()) ? string.Empty : tools.Error();

            }
            catch (Exception ex)
            {
                ResponseMessage = "UesrPayment - SavePayment - " + ex.Message;
                ResponseStatus = false;
            }

        }

        public List<Payment> SearchPayment(int pClientId)
        {
            SqlCommand cmd;
            List <Payment> respuesta = null;
            try
            {
                cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_payment_detail"
                };
                cmd.Parameters.Add("@client_id", SqlDbType.Int).Value = pClientId;

                respuesta = tools.Getds(cmd).Tables[0].ToList<Payment>();
                ResponseStatus = tools.Status();
                ResponseMessage = string.IsNullOrEmpty(tools.Error()) ? string.Empty : tools.Error();

            }
            catch (Exception ex)
            {
                ResponseMessage = "UesrPayment - SearchPayment - " + ex.Message;
                ResponseStatus = false;
            }
            return respuesta;
        }
        public bool Status()
        {
            return ResponseStatus;
        }
        public string Message()
        {
            return ResponseMessage;
        }
    }
}
