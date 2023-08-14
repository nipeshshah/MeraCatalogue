using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using System.Reflection;

namespace MeraCatalogue.Framework
{
    public class SQLHelper
    {
        #region Fields

        public SqlConnection _Connection = null;

        #endregion Fields

        #region Constructors

        public SQLHelper(string connectionString = "")
        {
            if (connectionString == string.Empty)
                connectionString = ConfigurationManager.ConnectionStrings["MeraCatalogDB"].ConnectionString;
            _Connection = new SqlConnection(connectionString);
        }

        #endregion Constructors

        #region Methods

        public DataTable GetDatatable(List<string> dataList, string tableName, List<string> columnList)
        {
            DataTable dt;
            dt = new DataTable(tableName);

            foreach (string column in columnList)
            {
                dt.Columns.Add(column, typeof(string));
            }

            foreach (string item in dataList)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }

        public List<T> ToEntity<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //public T ConvertTo<T>(DataTable table) where T : new()
        //{
        //    var entitylist = new List<T>();
        //    var properties = typeof(T).GetProperties();

        //    foreach (var row in table.Rows)
        //    {
        //        var entity = new T();
        //        foreach (var property in properties)
        //        {
        //            //Get the description attribute
        //            var descriptionAttribute = (DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), true).SingleOrDefault();
        //            if (descriptionAttribute == null)
        //                continue;

        //            property.SetValue(entity, row[descriptionAttribute.Description]);
        //        }
        //        entitylist.Add(entity)
        //    }
        //    return entitylist;
        //}

        public DataTable GetDataTableOneColumn(List<object> dataList, string tableName, string columnName, Type columnType)
        {
            DataTable dt;
            dt = new DataTable(tableName);
            dt.Columns.Add(columnName, columnType);

            foreach (object item in dataList)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }

        public SqlParameter SqlParameter(string parameterName, SqlDbType parameterType, object parameterValue)
        {
            SqlParameter paramParameter = new SqlParameter("@" + parameterName, parameterType);
            paramParameter.Value = parameterValue;
            return paramParameter;
        }

        public void Dispose()
        {
            try
            {
                if (_Connection != null && _Connection.State != ConnectionState.Closed) _Connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            int returnValue = 0;
            try
            {
                Open();
                SqlCommand oCommand = new SqlCommand(query, _Connection);
                if (parameters != null) oCommand.Parameters.AddRange(parameters);

                returnValue = oCommand.ExecuteNonQuery();
                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnValue;
        }

        public int ExecuteNonQueryProcedure(string storedProcName, params SqlParameter[] parameters)
        {
            int returnValue = 0;
            try
            {
                Open();
                SqlCommand oCommand = GetSqlCommandObject(storedProcName, parameters);
                returnValue = oCommand.ExecuteNonQuery();
                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnValue;
        }

        public DataSet ExecuteProcedureReader(string storedProcName, params SqlParameter[] parameters)
        {
            DataSet Result = new DataSet();
            SqlDataAdapter objSqlDataAdapter = null;
            try
            {
                Open();
                SqlCommand oCommand = GetSqlCommandObject(storedProcName, parameters);
                oCommand.CommandTimeout = 240;
                objSqlDataAdapter = new SqlDataAdapter(oCommand);
                objSqlDataAdapter.Fill(Result);
                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Result;
        }

        public DataSet ExecuteQueryReader(string query, params SqlParameter[] parameters)
        {
            DataSet Result = new DataSet();
            SqlDataAdapter objSqlDataAdapter = null;
            try
            {
                Open();

                SqlCommand oCommand = new SqlCommand(query, _Connection);

                if (parameters != null) oCommand.Parameters.AddRange(parameters);

                objSqlDataAdapter = new SqlDataAdapter(oCommand);
                objSqlDataAdapter.Fill(Result);

                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Result;
        }

        public int ExecutScalarProcedure(string storedProcName, params SqlParameter[] parameters)
        {
            int returnValue = 0;
            try
            {
                Open();
                SqlCommand oCommand = GetSqlCommandObject(storedProcName, parameters);
                returnValue = Convert.ToInt32(oCommand.ExecuteScalar());
                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnValue;
        }

        public string ExecutScalarProcedureString(string storedProcName, params SqlParameter[] parameters)
        {
            string returnValue = string.Empty;
            try
            {
                Open();
                SqlCommand oCommand = GetSqlCommandObject(storedProcName, parameters);
                returnValue = oCommand.ExecuteScalar().ToString();
                oCommand.Dispose();
                Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return returnValue;
        }

        internal SqlParameter SqlParameter(string parameterName, SqlDbType parameterType, int parameterSize, string parameterValue)
        {
            SqlParameter paramParameter = new SqlParameter("@" + parameterName, parameterType, parameterSize);
            paramParameter.Value = parameterValue;
            return paramParameter;
        }

        private SqlCommand GetSqlCommandObject(string storedProcName, params SqlParameter[] parameters)
        {
            SqlCommand oCommand = new SqlCommand(storedProcName, _Connection);
            oCommand.CommandType = CommandType.StoredProcedure;
            if (parameters != null) oCommand.Parameters.AddRange(parameters);
            return oCommand;
        }

        private void Open()
        {
            try
            {
                if (_Connection != null && _Connection.State == ConnectionState.Closed) _Connection.Open();
            }
            catch (Exception) { }
        }

        #endregion Methods
    }
}
//Email This
//BlogThis!
//Share to Twitter
//Share to Facebook
//Share to Pinterest