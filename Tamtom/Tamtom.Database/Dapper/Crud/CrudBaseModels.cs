using System;
using System.Collections.Generic;
using System.Text;

namespace Tamtom.Database.Dapper.Crud
{
    public class CrudBaseModels
    {
        #region Primary key

        public struct PrimaryKeyID
        {
            public int ID { get; set; }

            public static implicit operator int(PrimaryKeyID primaryKeyID) => primaryKeyID.ID;
            public static implicit operator PrimaryKeyID(int primaryKeyID) => new PrimaryKeyID() { ID = primaryKeyID };

            public override string ToString() => $"{ID}";
        }

        public struct PrimaryKeyGuid
        {
            public Guid ID { get; set; }

            public static implicit operator Guid(PrimaryKeyGuid primaryKeyID) => primaryKeyID.ID;
            public static explicit operator PrimaryKeyGuid(Guid primaryKeyID) => new PrimaryKeyGuid() { ID = primaryKeyID };

            public override string ToString() => $"{ID}";
        }

        #endregion

        #region Read
        public struct SelectWithPaginationModel
        {
            public int FetchRow { get; set; }
            public int SkipRow { get; set; }
            public int? SortType { get; set; }
        }
        #endregion
    }
}
