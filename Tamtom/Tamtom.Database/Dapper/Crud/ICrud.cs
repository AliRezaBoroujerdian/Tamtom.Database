using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tamtom.Database.Dapper.Crud
{
    /// <summary>
    /// Base model  of Create, Read, Update, Delete
    /// </summary>
    public interface ICrud
    {
        #region Create

        Task<int> Insert<InputType>(InputType model);
        Task<int> InsertAndReturnInsertedID<InputType>(InputType model);

        #endregion

        #region Read

        Task<ReturnType> SelectSingle<ReturnType>(CrudModels.SelectSingleModelWithID model);
        Task<ReturnType> SelectSingle<ReturnType>(CrudModels.SelectSingleModelWithGuid model);

        Task<IEnumerable<ReturnType>> Select<ReturnType>(CrudModels.SelectModel model);

        #endregion

        #region Update

        Task<int> Update<InputType>(InputType model);

        Task<int> DeActiveLanguage(CrudModels.DeActiveLanguageModelWithID model);
        Task<int> DeActiveLanguage(CrudModels.DeActiveLanguageModelWithGuid model);

        Task<int> DeActive(CrudModels.PrimaryKeyID id);
        Task<int> DeActive(CrudModels.PrimaryKeyGuid id);


        #endregion

        #region Delete
        Task<int> DeleteLanguage(CrudModels.DeleteLanguageModelWithID model);
        Task<int> DeleteLanguage(CrudModels.DeleteLanguageModelWithGuid model);

        Task<int> Delete(CrudModels.PrimaryKeyID id);
        Task<int> Delete(CrudModels.PrimaryKeyGuid id);

        #endregion
    }
}


