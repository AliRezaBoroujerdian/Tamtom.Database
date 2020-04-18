using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tamtom.Database.Dapper.Crud
{
    /// <summary>
    /// Base model  of Create, Read, Update, Delete for tables that have one primary key
    /// </summary>
    public interface ICrudBase
    {
        #region Create

        Task<int> Insert<InputType>(InputType model);

        #endregion

        #region Read

        #region ByID
        Task<ReturnType> SelectByID<ReturnType>(CrudBaseModels.PrimaryKeyID id);
        Task<ReturnType> SelectByID<ReturnType>(CrudBaseModels.PrimaryKeyGuid id);
        #endregion

        Task<IEnumerable<ReturnType>> Select<ReturnType>();

        Task<IEnumerable<ReturnType>> SelectWithPagination<ReturnType>(CrudBaseModels.SelectWithPaginationModel model);

        #endregion

        #region Update

        Task<int> Update<InputType>(InputType model);

        #endregion

        #region Delete

        Task<int> Delete(CrudModels.PrimaryKeyID id);
        Task<int> Delete(CrudModels.PrimaryKeyGuid id);

        #endregion
    }
}
