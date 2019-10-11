using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;

namespace SeedSolution.Data.Tools
{
    public static class Extensions
    {
        public static List<T> ToSerializeList<T>(this DataTable table) where T : new()
        {
            try
            {
                if (table == null)
                    throw new Exception("No se encontraron datos válidos");

                List<T> vResultado = new List<T>();

                vResultado = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(table,
                    Formatting.Indented,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

                return vResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            foreach (var row in table.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties);
                result.Add(item);
            }
            return result;
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(System.DayOfWeek))
                {
                    DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                    property.SetValue(item, day, null);
                }
                else if (property.PropertyType.IsGenericType
                    && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (row[property.Name] == DBNull.Value)
                    {
                        property.SetValue(item, null, null);
                    }
                    else
                    {
                        try
                        {
                            SetValorPropiedadNullable<T>(row, item, property);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                else if (property.PropertyType == typeof(System.Boolean))
                {
                    if (row[property.Name] == DBNull.Value)
                    {
                        property.SetValue(item, false, null);
                    }
                    else
                    {
                        var valorBool = row[property.Name].ToString() == "1" || row[property.Name].ToString() == "True" ? true : false;
                        property.SetValue(item, valorBool, null);
                    }
                }
                else
                {
                    try
                    {
                        SetValorPropiedad<T>(row, item, property);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return item;
        }
        private static void SetValorPropiedad<T>(DataRow row, T item, PropertyInfo property) where T : new()
        {
            if (row[property.Name].GetType() == typeof(byte))
            {
                if (property.PropertyType == typeof(short))
                {
                    short int16Value = Convert.ToInt16(row[property.Name]);
                    property.SetValue(item, int16Value, null);
                }
                else if (property.PropertyType == typeof(int))
                {
                    int int32Value = Convert.ToInt32(row[property.Name]);
                    property.SetValue(item, int32Value, null);
                }
                else if (property.PropertyType == typeof(long))
                {
                    long int64Value = Convert.ToInt64(row[property.Name]);
                    property.SetValue(item, int64Value, null);
                }
            }
            else
            {
                property.SetValue(item, row[property.Name], null);
            }
        }
        private static void SetValorPropiedadNullable<T>(DataRow row, T item, PropertyInfo property) where T : new()
        {
            if (row[property.Name].GetType() == typeof(byte))
            {
                if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(short))
                {
                    short? int16Value = Convert.ToInt16(row[property.Name]);
                    property.SetValue(item, int16Value, null);
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(int))
                {
                    int? int32Value = Convert.ToInt32(row[property.Name]);
                    property.SetValue(item, int32Value, null);
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) == typeof(long))
                {
                    long? int64Value = Convert.ToInt64(row[property.Name]);
                    property.SetValue(item, int64Value, null);
                }
            }
            else
            {
                property.SetValue(item, row[property.Name], null);
            }
        }
        public static List<T> ToListPrimitive<T>(this DataTable table)
        {
            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            List<T> result = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                var item = (T)row[0];
                result.Add(item);
            }
            return result;
        }
    }
}
