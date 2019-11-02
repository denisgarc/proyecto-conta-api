﻿using SeedSolution.Data.Connection.Interfaces;
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
    public class CardexRepository: ICardexRepository
    {
        #region Private Variables

        private readonly IConnectionTools _dbConnector;
        public string msgError;
        public bool status;

        #endregion

        #region Constructor
        public CardexRepository()
        {
            this._dbConnector = StructureMap.ObjectFactory.GetInstance<IConnectionTools>();
        }

        #endregion

        #region Public Methods

        public List<CardexDB> GetCardex(int? id = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "car_obtener_cardex";

                    // Agregamos los parametros
                    cmd.Parameters.Add("@reporte", SqlDbType.Bit).Value = false;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<CardexDB>();

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CardexDB> GetCardexFiltered(DateTime startDate, DateTime finishDate, int? branch = null, int? product = null)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "car_obtener_cardex";

                    // Agregamos los parametros
                    cmd.Parameters.Add("@reporte", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@fecha_desde", SqlDbType.DateTime).Value = startDate;
                    cmd.Parameters.Add("@fecha_hasta", SqlDbType.DateTime).Value = finishDate;

                    if (branch != null)
                        cmd.Parameters.Add("@cod_sucursal", SqlDbType.SmallInt).Value = branch;

                    if (product != null)
                        cmd.Parameters.Add("@cod_producto", SqlDbType.Int).Value = product;

                    // Realizamos la consulta de datos
                    var result = this._dbConnector.Getds(cmd).Tables[0];

                    // Validamos si existe error al consultar datos
                    if (!this._dbConnector.Status())
                        throw new Exception(this._dbConnector.Error());

                    var response = result.ToSerializeList<CardexDB>();

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
                    //if (!this._dbConnector.Status())
                    //    throw new Exception(this._dbConnector.Error());
                    this.status = this._dbConnector.Status();
                    this.msgError = this._dbConnector.Error();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public string GetError()
        {
            return this.msgError;
        }

        public bool GetStatus()
        {
            return this.status;
        }
    }
}
