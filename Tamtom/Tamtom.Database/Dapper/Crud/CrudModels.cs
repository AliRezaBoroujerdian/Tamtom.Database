using System;

namespace Tamtom.Database.Dapper.Crud
{
    public struct CrudModels
    {
        #region Read
        public struct SelectSingleModelWithID
        {
            public string LanguageID { get; set; }
            public int ID { get; set; }
        }

        public struct SelectSingleModelWithGuid
        {
            public string LanguageID { get; set; }
            public Guid ID { get; set; }
        }

        public struct SelectModel
        {
            public string LanguageID { get; set; }
            public int SortType { get; set; }
            public int FetchRow { get; set; }
            public int SkipRow { get; set; }
        }
        #endregion

        #region Update
        public struct DeActiveLanguageModelWithID
        {
            public string LanguageID { get; set; }
            public int ID { get; set; }
        }

        public struct DeActiveLanguageModelWithGuid
        {
            public string LanguageID { get; set; }
            public Guid ID { get; set; }
        }
        #endregion

        #region Delete
        public struct DeleteLanguageModelWithID
        {
            public string LanguageID { get; set; }
            public int ID { get; set; }
        }

        public struct DeleteLanguageModelWithGuid
        {
            public string LanguageID { get; set; }
            public Guid ID { get; set; }
        }
        #endregion

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
    }
}

