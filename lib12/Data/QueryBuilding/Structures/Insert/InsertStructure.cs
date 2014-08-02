using System.Collections.Generic;
using lib12.Collections;

namespace lib12.Data.QueryBuilding.Structures.Insert
{
    public class InsertStructure : BaseQueryStructure
    {
        public string[] Columns { get; set; }

        public object[] Values { get; set; }

        public IEnumerable<object> BatchValues { get; set; }

        public bool IsBatchInsert
        {
            get { return BatchValues.IsNotNullAndNotEmpty(); }
        }
    }
}