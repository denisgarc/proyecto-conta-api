﻿using SeedSolution.Data.Connection.Interfaces;
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
    public class CardexRepository: ICardexRepository
    {
        #region Private Variables

        private readonly IConnectionTools _dbConnector;

        #endregion

        #region Constructor
        public CardexRepository()
        {
            this._dbConnector = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
        }

        #endregion

        #region Public Methods

        public List<Cardex> GetCardex(int? id = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cat_obtener_catalogos";

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = 6;

                    if (id != null)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<Cardex>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCardex(Cardex cardex)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "car_guardar_cardex";

                    // Parametros
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = cardex.Id;
                    cmd.Parameters.Add("@cod_sucursal", SqlDbType.SmallInt).Value = cardex.Sucursal.Codigo;
                    cmd.Parameters.Add("@cod_operacion", SqlDbType.SmallInt).Value = cardex.Operacion.Codigo;
                    cmd.Parameters.Add("@cod_producto", SqlDbType.Int).Value = cardex.Producto.Codigo;
                    cmd.Parameters.Add("@fecha_operacion", SqlDbType.DateTime).Value = cardex.FechaOperacion;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = cardex.Cantidad;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 500).Value = cardex.Descripcion;

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
