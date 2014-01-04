using lib12.Data.QueryBuilding.Structures;

namespace lib12.Data.QueryBuilding.Builders
{
    public interface IBuilder<TStructure> : IBuild where TStructure : IStructure
    {
        TStructure Structure { get; }
    }
}
