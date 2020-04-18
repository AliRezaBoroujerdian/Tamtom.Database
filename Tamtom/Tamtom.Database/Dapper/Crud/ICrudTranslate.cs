using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tamtom.Database.Dapper.Crud
{
    /// <summary>
    /// Base model  of Create, Read, Update, Delete for translate tables
    /// </summary>
    public interface ICrudTranslate
    {
        #region Create

        Task<int> Insert<InputType>(InputType model);

        #endregion

        #region Read

        Task<ReturnType> SelectByID<ReturnType>(CrudTranslateModels.SelectByIDModel model);
        Task<ReturnType> SelectByID<ReturnType>(CrudTranslateModels.SelectByGuidModel model);

        Task<IEnumerable<ReturnType>> Select<ReturnType>();

        Task<IEnumerable<ReturnType>> SelectWithPagination<ReturnType>(CrudTranslateModels.SelectWithPaginationModel model);

        Task<IEnumerable<ReturnType>> SelectWithPaginationWithLanguage<ReturnType>(CrudTranslateModels.SelectWithPaginationWithLanguageModel model);

        #endregion

        #region Update

        Task<int> Update<InputType>(InputType model);

        #endregion

        #region Delete
        Task<int> Delete(CrudTranslateModels.DeleteLanguageModelWithID model);
        Task<int> Delete(CrudTranslateModels.DeleteLanguageModelWithGuid model);

        #endregion
    }
}
