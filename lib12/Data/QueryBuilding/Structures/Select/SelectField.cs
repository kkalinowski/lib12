
namespace lib12.Data.QueryBuilding.Structures.Select
{
    public class SelectField
    {
        #region Props
        public string Field { get; set; }
        public string Alias { get; set; }

        public bool HasAlias
        {
            get
            {
                return !string.IsNullOrEmpty(Alias);
            }
        }
        #endregion

        public SelectField()
        {

        }

        public SelectField(string field)
        {
            Field = field;
        }

        public SelectField(string field, string alias)
        {
            Field = field;
            Alias = alias;
        }

        public string Build()
        {
            return HasAlias ? string.Format("{0} AS {1}", Field, Alias) : Field;
        }
    }
}
