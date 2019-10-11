using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Data.Tools;
using SeedSolution.Entity.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedSolution.Data.Inventory
{
    public class OperationRepository: IOperationRepository
    {
        #region Private Variables

        private readonly IConnectionTools _dbConnector;

        #endregion

        #region Constructor
        public OperationRepository()
        {
            this._dbConnector = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
        }

        #endregion

        #region Public Methods
        public List<Operacion> GetOperation(int? id = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cat_obtener_catalogos";

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = 5;

                    if (id != null)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<Operacion>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveOperation(Operacion operation)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "op_guardar_operacion";

                    // Parametros
                    cmd.Parameters.Add("@codigo", SqlDbType.SmallInt).Value = operation.Codigo;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = operation.Nombre;
                    cmd.Parameters.Add("@credito", SqlDbType.Bit).Value = operation.Credito;
                    cmd.Parameters.Add("@debito", SqlDbType.Bit).Value = operation.Debito;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = operation.Estado;

                    // Ejecutamos el procedimiento
                    this._dbConnector.Exec(cmd);

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
