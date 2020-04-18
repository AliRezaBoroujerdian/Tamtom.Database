using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Tamtom.Database.Dapper.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using static Tamtom.Application.DataAccess;

namespace Tamtom.Database.Dapper.Crud
{
    public class CrudTranslate : ICrudTranslate
    {
        readonly string schemaName;
        readonly string tableName;

        /// <summary>
        /// crud with dapper from related stored procedure
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="schemaName">schema name - optional (default value is "dbo")</param>
        public CrudTranslate(string tableName, string schemaName = "dbo")
        {
            this.schemaName = schemaName;
            this.tableName = tableName;
        }

        #region Create
        public async virtual Task<int> Insert<InputType>(InputType model) => await ExecuteStoredProcedureFirstOrDefaultAsync<InputType, int>($"[{schemaName}].APP_SP_INS_{tableName}", model);
        #endregion

        #region Read

        #region ByID
        public async virtual Task<ReturnType> SelectByID<ReturnType>(CrudTranslateModels.SelectByIDModel model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add($"@{tableName}ID", model.ID);
            parameter.Add($"@LanguageID", model.LanguageID);

            return await dbConnection.QueryFirstOrDefaultAsync<ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}_ByID", parameter, commandType: CommandType.StoredProcedure);
        }

        public async virtual Task<ReturnType> SelectByID<ReturnType>(CrudTranslateModels.SelectByGuidModel model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add($"@{tableName}ID", model.ID);
            parameter.Add($"@LanguageID", model.LanguageID);

            return await dbConnection.QueryFirstOrDefaultAsync<ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}_ByID", parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion

        public async virtual Task<IEnumerable<ReturnType>> Select<ReturnType>() => await ExecuteStoredProcedureAsync<ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}");

        public async virtual Task<IEnumerable<ReturnType>> SelectWithPagination<ReturnType>(CrudTranslateModels.SelectWithPaginationModel model) => await ExecuteStoredProcedureAsync<CrudTranslateModels.SelectWithPaginationModel, ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}_Pagination", model);

        public async virtual Task<IEnumerable<ReturnType>> SelectWithPaginationWithLanguage<ReturnType>(CrudTranslateModels.SelectWithPaginationWithLanguageModel model) => await ExecuteStoredProcedureAsync<CrudTranslateModels.SelectWithPaginationWithLanguageModel, ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}_PaginationWithLanguage", model);

        #endregion

        #region Update

        public async virtual Task<int> Update<InputType>(InputType model) => await ExecuteStoredProcedureFirstOrDefaultAsync<InputType, int>($"[{schemaName}].APP_SP_UPD_{tableName}", model);

        #endregion

        #region Delete
        public async virtual Task<int> Delete(CrudTranslateModels.DeleteLanguageModelWithID model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add($"@{tableName}ID", model.ID);
            parameter.Add($"@LanguageID", model.LanguageID);

            return await dbConnection.QueryFirstOrDefaultAsync<int>($"[{schemaName}].APP_SP_DEL_{tableName}", parameter, commandType: CommandType.StoredProcedure);
        }
        public async virtual Task<int> Delete(CrudTranslateModels.DeleteLanguageModelWithGuid model)
        {
            using IDbConnection dbConnection = new SqlConnection(ConnectionString);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            DynamicParameters parameter = new DynamicParameters();
            parameter.Add($"@{tableName}ID", model.ID);
            parameter.Add($"@LanguageID", model.LanguageID);

            return await dbConnection.QueryFirstOrDefaultAsync<int>($"[{schemaName}].APP_SP_DEL_{tableName}", parameter, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
