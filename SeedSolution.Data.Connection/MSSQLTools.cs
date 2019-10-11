using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SeedSolution.Data.Connection.Interfaces;

namespace SeedSolution.Data.Connection
{
    public  class MSSQLTools : IConnectionTools
    {
        public string Query { get; set; }
        public string strError { get; set; }
        public bool blnStatus { get; set; }
        private string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SeedSolution.ConnectionString"].ConnectionString;

        public string Error()
        {
            return strError;
        }
        public bool Status()
        {
            return blnStatus;
        }

        private SqlConnection Connector = null;

        /// <summary>
        /// Funcion que se conecta a la base de datos y ejecuta una consulta retornando un dataset
        /// </summary>
        /// <returns></returns>
        public DataSet Getds()
        {
            strError = string.Empty;
            DataSet d = new DataSet();
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                SqlCommand comando = new SqlCommand(Query);
                AddTimeout(comando);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(d);
            }
            catch (Exception ex)
            {
                this.blnStatus = false;                
                strError = Geterror(ex); d = null;
                
            }
            finally
            {
                Connector.Close();
            }
            return d;
        }

        /// <summary>
        /// Funcion que se conecta a la base de datos  y ejecuta una consulta retornando un DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable Getdt()
        {
            DataSet d = new DataSet();
            DataTable t = new DataTable();
            try
            {
                Connector = new SqlConnection();
                Connector.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(Query, Connector);
                adapter.Fill(d);
                t = d.Tables[0];
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                t = null;
                this.blnStatus = false;
                strError = Geterror(ex); d = null;
            }
            finally
            {
                Connector.Close();
            }
            return t;
        }

        /// <summary>
        /// Funcion que ejecuta comandos sql y retorna verdadero o falso segun el resultado de la ejecucion
        /// </summary>
        /// <returns></returns>
        public bool Exec()
        {
            bool resp = false;
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                SqlCommand cmd = new SqlCommand(Query, Connector);
                AddTimeout(cmd);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                resp = true;
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                resp = false;

            }
            finally
            {
                Connector.Close();
            }
            return resp;
        }

        /// <summary>
        /// Funcion que se conecta a la base de datos y ejecuta una lista querys retornando verdadero o falso segun el resultado  de la ejecucion
        /// </summary>
        /// <param name="QueryList"></param>
        /// <returns></returns>
        public bool Exec(List<string> QueryList)
        {
            bool resp = false;
            SqlTransaction trans = Connector.BeginTransaction();
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                using (SqlCommand cmd = new SqlCommand("", Connector, trans))
                {
                    cmd.CommandType = CommandType.Text;
                    AddTimeout(cmd);
                    foreach (string sql in QueryList)
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                resp = true;
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                trans.Rollback();
                resp = false;
            }
            finally
            {
                Connector.Close();
            }
            return resp;
        }

        /// <summary>
        /// Registra errores en Elmah
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string Geterror(Exception ex)
        {
            //Logging error on Elmah
            string msg = string.Empty;
            System.Diagnostics.StackTrace Trace = new System.Diagnostics.StackTrace(ex, true);
            msg = "Ocurrio un problema en funcion " + Trace.GetFrame(0).GetMethod()
                + ", linea:" + Trace.GetFrame(0).GetFileLineNumber()
                + ", ErrorMesage: <<" + GetExceptionsMsg(ex) + ">>"
                + ", ErrorTrace: " + GetExceptionTrace(ex);
            //ErrorLog.LogError(ex, msg);
            return GetExceptionsMsg(ex);
        }

        /// <summary>
        /// Funcion que convierte una GetExceptionTrace a un mensaje de texto
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionTrace(Exception ex)
        {
            var str = ex.StackTrace;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                str = str + "\n\r;InnerException= " + ex.StackTrace;
            }
            
            return str;
        }

        /// <summary>
        /// Funcion que convierte una GetExceptionsMsg a un mensaje de texto
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExceptionsMsg(Exception ex)
        {
            var str = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                str = str + ";InnerException= " + ex.Message;
            }

            return str;
        }

        /// <summary>
        /// Ejecuta una lista de sqlcommand para trabajar con transacciones.
        /// </summary>
        /// <param name="CommandsList"></param>
        /// <returns></returns>
        public bool Exec(List<SqlCommand> CommandsList)
        {
            bool resp = false;
            SqlTransaction transaction = null;
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                transaction = Connector.BeginTransaction();
                foreach (SqlCommand cmd in CommandsList)
                {

                    cmd.Connection = Connector;
                    cmd.Transaction = transaction;
                    AddTimeout(cmd);
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                resp = true;
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                transaction.Rollback();
                resp = false;
            }
            return resp;
        }

        /// <summary>
        /// Funcion que ejecuta un comando sql y retorna como resultado verdadero o falso segun el resultado de la ejecucion
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool Exec(SqlCommand cmd)
        {
            bool resp = false;
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                cmd.Connection = Connector;
                AddTimeout(cmd);
                cmd.ExecuteNonQuery();
                resp = true;
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                resp = false;
            }
            finally
            {
                Connector.Close();
            }
            return resp;
        }

        /// <summary>
        /// Ejecuta una consulta que devuelve siempre solo un resultado.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>cadena</returns>
        public string ExecEscalar(SqlCommand cmd)
        {
            string resp = "";
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                cmd.Connection = Connector;
                AddTimeout(cmd);
                var obj = cmd.ExecuteScalar();
                if (obj != null)
                    resp = obj.ToString();
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                resp = "";
            }
            finally
            {
                Connector.Close();
            }
            return resp;
        }

        /// <summary>
        /// Ejecuta un comando sql y retorna un dataset como resultado
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public DataSet Getds(SqlCommand cmd)
        {
            strError = string.Empty;
            DataSet d = new DataSet();
            try
            {
                Connector = new SqlConnection();
                Connector.ConnectionString = strConnection;
                Connector.Open();
                cmd.Connection = Connector;
                AddTimeout(cmd);
                using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                {
                    a.Fill(d);
                }
                this.blnStatus = true;
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
                d = null;
                this.blnStatus = false;                
            }
            finally
            {
                Connector.Close();
            }
            return d;
        }

        /// <summary>
        /// Retorna parametros de sql
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tipo"></param>
        /// <param name="size"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static SqlParameter GetOutputParameter(string name, SqlDbType tipo, int? size = null, object valor = null)
        {
            SqlParameter p1 = new SqlParameter(name, tipo);
            if (size.HasValue)
            {
                p1.Size = size.Value;
            }
            if (valor != null)
                p1.Value = valor;
            p1.Direction = ParameterDirection.Output;
            
            return p1;
        }

        /// <summary>
        /// Agrega el time out configurado en el Config.
        /// </summary>
        /// <param name="comando"></param>
        public static void AddTimeout(SqlCommand comando)
        {
            try
            {
                int DbTimeoutSecs = 0;
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings["DbTimeoutSecs"], out DbTimeoutSecs);
                comando.CommandTimeout = DbTimeoutSecs; //0= Hasta que haya respuesta.				
            }
            catch
            {
                comando.CommandTimeout = 0;
            }
        }

        public List<T> GetList<T>(SqlCommand cmd) where T : new()
        {
            List<T> lista = new List<T>();
            try
            {
                using (Connector = new SqlConnection())
                {
                    Connector.ConnectionString = strConnection;
                    Connector.Open();
                    cmd.Connection = Connector;
                    AddTimeout(cmd);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
                        Dictionary<string, PropertyInfo> props = new Dictionary<string, PropertyInfo>();
                        int nroCols = 0;
                        bool first = true;
                        while (reader.Read())
                        {
                            T item = new T();
                            if (first)
                            {
                                nroCols = reader.FieldCount;
                            }

                            for (int i = 0; i < nroCols; i++)
                            {
                                string colName = reader.GetName(i).ToUpper();
                                object colValue = reader.GetValue(i);
                                PropertyInfo property = null;
                                if (first)
                                {
                                    property = properties.FirstOrDefault(p => p.Name.ToUpper() == colName);
                                    props.Add(colName, property);
                                }
                                else
                                {
                                    property = props[colName];
                                }

                                if (property != null)
                                {
                                    SetPropertyValue<T>(colValue, item, property);
                                }
                            }
                            lista.Add(item);
                            first = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strError = Geterror(ex);
            }
            return lista;
        }

        private void SetPropertyValue<T>(object value, T item, PropertyInfo property) where T : new()
        {
            if (property.PropertyType == typeof(System.DayOfWeek))
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), value.ToString());
                property.SetValue(item, day, null);
            }
            else if (property.PropertyType.IsGenericType
                && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == DBNull.Value)
                {
                    property.SetValue(item, null, null);
                }
                else
                {
                    try
                    {
                        SetValueNullable<T>(value, item, property);
                    }
                    catch (Exception)
                    {
                        //Console.WriteLine(ex.ToString());
                    }
                }
            }
            else if (property.PropertyType == typeof(System.Boolean))
            {
                if (value == DBNull.Value)
                {
                    property.SetValue(item, false, null);
                }
                else
                {
                    var valorBool = value.ToString() == "1" || value.ToString() == "True" ? true : false;
                    property.SetValue(item, valorBool, null);
                }
            }
            else
            {
                try
                {
                    SetValue<T>(value, item, property);
                }
                catch (Exception)
                {
                    //Console.WriteLine(ex.ToString());
                }
            }
        }

        private void SetValueNullable<T>(object value, T item, PropertyInfo property) where T : new()
        {
            if (value.GetType() == typeof(byte))
            {
                if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(short))
                {
                    short? int16Value = Convert.ToInt16(value);
                    property.SetValue(item, int16Value, null);
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(int))
                {
                    int? int32Value = Convert.ToInt32(value);
                    property.SetValue(item, int32Value, null);
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(long))
                {
                    long? int64Value = Convert.ToInt64(value);
                    property.SetValue(item, int64Value, null);
                }
            }
            else
            {
                property.SetValue(item, value, null);
            }
        }

        private void SetValue<T>(object value, T item, PropertyInfo property) where T : new()
        {
            if (value.GetType() == typeof(byte))
            {
                if (property.PropertyType == typeof(short))
                {
                    short int16Value = Convert.ToInt16(value);
                    property.SetValue(item, int16Value, null);
                }
                else if (property.PropertyType == typeof(int))
                {
                    int int32Value = Convert.ToInt32(value);
                    property.SetValue(item, int32Value, null);
                }
                else if (property.PropertyType == typeof(long))
                {
                    long int64Value = Convert.ToInt64(value);
                    property.SetValue(item, int64Value, null);
                }
            }
            else
            {
                property.SetValue(item, value, null);
            }
        }

    }
}
