namespace IEH_Dashboard.Utility
{
    using System;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="SqlHelper" />
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// The ExecuteProcedureReturnString
        /// </summary>
        /// <param name="connString">The connString<see cref="string"/></param>
        /// <param name="procName">The procName<see cref="string"/></param>
        /// <param name="paramters">The paramters<see cref="SqlParameter[]"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string ExecuteProcedureReturnString(string connString, string procName,
            params SqlParameter[] paramters)
        {
            string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteScalar();
                    if (ret != null)
                        result = Convert.ToString(ret);
                }
            }
            return result;
        }

        /// <summary>
        /// The ExtecuteProcedureReturnData
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="connString">The connString<see cref="string"/></param>
        /// <param name="procName">The procName<see cref="string"/></param>
        /// <param name="translator">The translator<see cref="Func{SqlDataReader, TData}"/></param>
        /// <param name="parameters">The parameters<see cref="SqlParameter[]"/></param>
        /// <returns>The <see cref="TData"/></returns>
        public static TData ExtecuteProcedureReturnData<TData>(string connString, string procName,
            Func<SqlDataReader, TData> translator,
            params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            { }
                        }
                        return elements;
                    }
                }
            }
        }

        /// <summary>
        /// The GetNullableString
        /// </summary>
        /// <param name="reader">The reader<see cref="SqlDataReader"/></param>
        /// <param name="colName">The colName<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetNullableString(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        /// <summary>
        /// The GetNullableInt32
        /// </summary>
        /// <param name="reader">The reader<see cref="SqlDataReader"/></param>
        /// <param name="colName">The colName<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        /// <summary>
        /// The GetBoolean
        /// </summary>
        /// <param name="reader">The reader<see cref="SqlDataReader"/></param>
        /// <param name="colName">The colName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
        }

        /// <summary>
        /// The GetDateTime
        /// </summary>
        /// <param name="reader">The reader<see cref="SqlDataReader"/></param>
        /// <param name="colName">The colName<see cref="string"/></param>
        /// <returns>The <see cref="DateTime"/></returns>
        public static DateTime GetDateTime(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(DateTime) : Convert.ToDateTime(reader[colName]);
        }

        /// <summary>
        /// The IsColumnExists
        /// </summary>
        /// <param name="dr">The dr<see cref="System.Data.IDataRecord"/></param>
        /// <param name="colName">The colName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
