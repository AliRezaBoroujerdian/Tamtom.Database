using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Tamtom.Database.Dapper.Generic;

namespace Tamtom.Database.Dapper.Crud
{
    public class Crud : ICrud
    {
        readonly string schemaName;
        readonly string tableName;

        /// <summary>
        /// crud with dapper from related stored procedure
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="schemaName">schema name - optional (default value is "dbo")</param>
        public Crud(string tableName, string schemaName = "dbo")
        {
            this.schemaName = schemaName;
            this.tableName = tableName;
        }

        #region Create
        public async virtual Task<int> Insert<InputType>(InputType model) => await ExecuteStoredProcedureFirstOrDefaultAsync<InputType, int>($"[{schemaName}].APP_SP_INS_{tableName}", model);
        public async virtual Task<int> InsertAndReturnInsertedID<InputType>(InputType model) => await ExecuteStoredProcedureFirstOrDefaultAsync<InputType, int>($"[{schemaName}].APP_SP_INS_{tableName}AndReturnInsertedID", model);
        #endregion

        #region Read
        public async virtual Task<ReturnType> SelectSingle<ReturnType>(CrudModels.SelectSingleModelWithID model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.SelectSingleModelWithID, ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}ByID", model);
        public async virtual Task<ReturnType> SelectSingle<ReturnType>(CrudModels.SelectSingleModelWithGuid model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.SelectSingleModelWithGuid, ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}ByGuid", model);

        public async virtual Task<IEnumerable<ReturnType>> Select<ReturnType>(CrudModels.SelectModel model) => await ExecuteStoredProcedureAsync<CrudModels.SelectModel, ReturnType>($"[{schemaName}].APP_SP_SEL_{tableName}", model);
        #endregion

        #region Update
        public async virtual Task<int> Update<InputType>(InputType model) => await ExecuteStoredProcedureFirstOrDefaultAsync<InputType, int>($"[{schemaName}].APP_SP_UPD_{tableName}", model);

        public async virtual Task<int> DeActiveLanguage(CrudModels.DeActiveLanguageModelWithID model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.DeActiveLanguageModelWithID, int>($"[{schemaName}].APP_SP_UPD_DeActive{tableName}LanguageByID", model);
        public async virtual Task<int> DeActiveLanguage(CrudModels.DeActiveLanguageModelWithGuid model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.DeActiveLanguageModelWithGuid, int>($"[{schemaName}].APP_SP_UPD_DeActive{tableName}LanguageByID", model);

        public async virtual Task<int> DeActive(CrudModels.PrimaryKeyID id) => await ExecuteStoredProcedureFirstOrDefaultAsync<int, int>($"[{schemaName}].APP_SP_UPD_DeActive{tableName}ByID", id);
        public async virtual Task<int> DeActive(CrudModels.PrimaryKeyGuid id) => await ExecuteStoredProcedureFirstOrDefaultAsync<Guid, int>($"[{schemaName}].APP_SP_UPD_DeActive{tableName}ByID", id);
        #endregion

        #region Delete
        public async virtual Task<int> DeleteLanguage(CrudModels.DeleteLanguageModelWithID model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.DeleteLanguageModelWithID, int>($"[{schemaName}].APP_SP_DEL_{tableName}LanguageByID", model);
        public async virtual Task<int> DeleteLanguage(CrudModels.DeleteLanguageModelWithGuid model) => await ExecuteStoredProcedureFirstOrDefaultAsync<CrudModels.DeleteLanguageModelWithGuid, int>($"[{schemaName}].APP_SP_DEL_{tableName}LanguageByID", model);

        public async virtual Task<int> Delete(CrudModels.PrimaryKeyID id) => await ExecuteStoredProcedureFirstOrDefaultAsync<int, int>($"[{schemaName}].APP_SP_DEL_{tableName}ByID", id);
        public async virtual Task<int> Delete(CrudModels.PrimaryKeyGuid id) => await ExecuteStoredProcedureFirstOrDefaultAsync<Guid, int>($"[{schemaName}].APP_SP_DEL_{tableName}ByID", id);
        #endregion

    }
}

