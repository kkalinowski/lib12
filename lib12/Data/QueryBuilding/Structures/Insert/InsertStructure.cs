namespace lib12.Data.QueryBuilding.Structures.Insert
{
    public class InsertStructure : BaseQueryStructure
    {
        public string[] Columns { get; set; }

        public object[] Values { get; set; }
    }
}