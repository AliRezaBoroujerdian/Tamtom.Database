using System;
using System.Collections.Generic;
using System.Text;

namespace Tamtom.Database.Dapper.Crud
{
    public class CrudTranslateModels
    {
        #region Read
        public struct SelectByIDModel
        {
            public string LanguageID { get; set; }
            public int ID { get; set; }
        }

        public struct SelectByGuidModel
        {
            public string LanguageID { get; set; }
            public Guid ID { get; set; }
        }

        public struct SelectWithPaginationModel
        {
            public int FetchRow { get; set; }
            public int SkipRow { get; set; }
            public int? SortType { get; set; }
        }

        public struct SelectWithPaginationWithLanguageModel
        {
            public string LanguageID { get; set; }
            public int FetchRow { get; set; }
            public int SkipRow { get; set; }
            public int? SortType { get; set; }
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
    }
}
