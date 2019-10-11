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
    public class ColorRepository: IColorRepository
    {
        #region Private Variables

        private readonly IConnectionTools _dbConnector;

        #endregion

        #region Constructor
        public ColorRepository()
        {
            this._dbConnector = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
        }

        #endregion

        #region Public Methods

        public List<Color> GetColor(int? id = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "cat_obtener_catalogos";

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = 3;

                    if (id != null)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<Color>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveColor(Color color)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "col_guardar_color";

                    // Parametros
                    cmd.Parameters.Add("@codigo", SqlDbType.SmallInt).Value = color.Codigo;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = color.Nombre;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = color.Estado;

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
