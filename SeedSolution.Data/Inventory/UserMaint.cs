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
    public class UserMaint : IUserMaint
    {
        private IConnectionTools tools;
        private string ResponseMessage { get; set; }
        private bool ResponseStatus { get; set; }

        public UserMaint()
        {
            tools = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
            ResponseStatus = false;
            ResponseMessage = string.Empty;
        }

        public void SaveClient(Client pClient)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "save_client"
                };
                cmd.Parameters.Add("@client_name", SqlDbType.VarChar, 100).Value = pClient.client_name;
                cmd.Parameters.Add("@client_document", SqlDbType.VarChar, 50).Value = pClient.client_document;
                cmd.Parameters.Add("@client_birthday", SqlDbType.Date).Value = pClient.client_birthday;
                tools.Getds(cmd);
                ResponseStatus = tools.Status();
                ResponseMessage = string.IsNullOrEmpty(tools.Error()) ? string.Empty : tools.Error();

            }
            catch (Exception ex)
            {
                ResponseMessage = "UserMaint - SaveClient - " + ex.Message;
                ResponseStatus = false;
                throw ex;
            }

        }

        public Client SearchClient(string document_number)
        {
            SqlCommand cmd;
            Client respuesta = null;
            try
            {
                cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_client_detail"
                };
                cmd.Parameters.Add("@client_document", SqlDbType.VarChar).Value = document_number;

                respuesta = tools.Getds(cmd).Tables[0].ToList<Client>().First();
                ResponseStatus = tools.Status();
                ResponseMessage = string.IsNullOrEmpty(tools.Error()) ? string.Empty : tools.Error();
            }
            catch (Exception ex)
            {
                ResponseMessage = "UserMaint - SearchClient - " + ex.Message;
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
