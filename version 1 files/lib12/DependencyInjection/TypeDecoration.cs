
namespace lib12.DependencyInjection
{
    internal sealed class TypeDecoration
    {
        public bool IsSingleton { get; set; }
        public bool IsTransient { get; set; }
        public bool WireUpAllProperties { get; set; }
    }
}
