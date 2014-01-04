
namespace lib12.Data.QueryBuilding.Builders
{
    public class SqlBuilder
    {
        public static SelectBuilder Select
        {
            get
            {
                return new SelectBuilder();
            }
        }
    }
}
