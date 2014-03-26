namespace lib12.Data.QueryBuilding.Structures.Select
{
    public class OrderBy
    {
        #region Props
        public string Field { get; set; }
        public bool Desc { get; set; }
        #endregion

        public OrderBy()
        {

        }

        public OrderBy(string field, bool desc)
        {
            Field = field;
            Desc = desc;
        }
    }
}
