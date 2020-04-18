using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static Tamtom.Application.DataAccess;

namespace Tamtom.Database.Dapper
{
    /// <summary>
    /// Created by AliRezaBoroujerdian
    /// Create date: 6 January 2020
    /// Implement the static class for connecting to the db with generic method
    /// </summary>
    public static class Generic
    {
        #region  Execute without model
        /// <summary>
        /// asynchronous - execute procedure with procedure's name and return IEnumerable model
        /// </summary>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model">model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the IEnumerable model that you give as return type</returns>
        public static async Task<IEnumerable<ReturnType>> ExecuteStoredProcedureAsync<ReturnType>(string storedProcedureName)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            return await dbConnection.QueryAsync<ReturnType>(storedProcedureName, commandType: CommandType.StoredProcedure);
        }
        #endregion

        #region Execute with one model
        /// <summary>
        /// asynchronous - execute procedure with procedure's name and return first or default model
        /// </summary>
        /// <typeparam name="InputType">the type you want to send to the procedure</typeparam>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model">model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the model that you give as return type</returns>
        public static async Task<ReturnType> ExecuteStoredProcedureFirstOrDefaultAsync<InputType, ReturnType>(string storedProcedureName, InputType model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.AddDynamicParams(model);

            return await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// execute procedure with procedure's name and return first or default model
        /// </summary>
        /// <typeparam name="InputType">the type you want to send to the procedure</typeparam>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model">model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the model that you give as return type</returns>
        public static ReturnType ExecuteStoredProcedureFirstOrDefault<InputType, ReturnType>(string storedProcedureName, InputType model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.AddDynamicParams(model);

            return dbConnection.QueryFirstOrDefault<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        }


        /// <summary>
        /// asynchronous - execute procedure with procedure's name and return IEnumerable model
        /// </summary>
        /// <typeparam name="InputType">the type you want to send to the procedure</typeparam>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model">model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the IEnumerable model that you give as return type</returns>
        public static async Task<IEnumerable<ReturnType>> ExecuteStoredProcedureAsync<InputType, ReturnType>(string storedProcedureName, InputType model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.AddDynamicParams(model);

            return await dbConnection.QueryAsync<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion


        /*
        #region Execute with two model
        /// <summary>
        /// asynchronous - execute procedure with procedure's name and return first or default model
        /// </summary>
        /// <typeparam name="InputType1">the first type you want to send to the procedure</typeparam>
        /// <typeparam name="InputType2">the second type you want to send to the procedure</typeparam>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model1">first model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <param name="model2">second model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the model that you give as return type</returns>
        public static async Task<ReturnType> ExecuteStoredProcedureFirstOrDefaultAsync<InputType1, InputType2, ReturnType>(string storedProcedureName, InputType1 model1, InputType2 model2)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.AddDynamicParams(model1);
            parameter.AddDynamicParams(model2);

            return await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// asynchronous - execute procedure with procedure's name
        /// </summary>
        /// <typeparam name="InputType1">the first type you want to send to the procedure</typeparam>
        /// <typeparam name="InputType2">the second type you want to send to the procedure</typeparam>
        /// <typeparam name="ReturnType">the type you want to receive from procedure</typeparam>
        /// <param name="storedProcedureName">[Schema].StoredProcedureName</param>
        /// <param name="model1">first model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <param name="model2">second model contain the stored procedure input parameter - data must be stored in property (not field)</param>
        /// <returns>return the model that you give as return type</returns>
        public static async Task<IEnumerable<ReturnType>> ExecuteStoredProcedureAsync<InputType1, InputType2, ReturnType>(string storedProcedureName, InputType1 model1, InputType2 model2)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.AddDynamicParams(model1);
            parameter.AddDynamicParams(model2);

            return await dbConnection.QueryAsync<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion

        //#region Execute with four model
        //public static async Task<ReturnType> ExecuteStoredProcedureFirstOrDefaultAsync<InputType1, InputType2, ReturnType>(string storedProcedureName, InputType1 model1,params InputType2[] model2)
        //{
        //    using IDbConnection dbConnection = new SqlConnection(ConnectionString);

        //    if (dbConnection.State == ConnectionState.Closed)
        //        dbConnection.Open();

        //    DynamicParameters parameter = new DynamicParameters();
        //    parameter.AddDynamicParams(model1);
        //    parameter.AddDynamicParams(model2);

        //    return await dbConnection.QueryFirstOrDefaultAsync<ReturnType>(storedProcedureName, parameter, commandType: CommandType.StoredProcedure);
        //}
        //#endregion
        */
    }
}

