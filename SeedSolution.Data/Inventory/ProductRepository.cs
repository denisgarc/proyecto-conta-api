using SeedSolution.Data.Connection.Interfaces;
using SeedSolution.Data.Interfaces.Inventory;
using SeedSolution.Data.Tools;
using SeedSolution.Entity.DB;
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
    public class ProductRepository: IProductRepository
    {
        #region Private Variables

        private readonly IConnectionTools _dbConnector;

        #endregion

        #region Constructor
        public ProductRepository()
        {
            this._dbConnector = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
        }

        #endregion

        #region Public Methods

        public List<ProductoDB> GetProduct(int? id = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cat_obtener_catalogos";

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = 4;

                    if (id != null)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<ProductoDB>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveProduct(Producto producto)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pro_guardar_producto";

                    // Parametros
                    cmd.Parameters.Add("@codigo", SqlDbType.SmallInt).Value = producto.Codigo;
                    cmd.Parameters.Add("@cod_marca", SqlDbType.SmallInt).Value = producto.Marca.Codigo;
                    cmd.Parameters.Add("@cod_color", SqlDbType.SmallInt).Value = producto.Color.Codigo;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = producto.Descripcion;
                    cmd.Parameters.Add("@tamano", SqlDbType.SmallInt).Value = producto.Tamano;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = producto.Estado;

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
