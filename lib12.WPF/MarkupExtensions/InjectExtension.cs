using System;
using System.Windows.Markup;
using lib12.DependencyInjection;

namespace lib12.WPF.MarkupExtensions
{
    public class InjectExtension : MarkupExtension
    {
        #region Props
        public string Key { get; set; }
        [ConstructorArgument("type")]
        public Type Type { get; set; }
        #endregion

        #region ctor
        public InjectExtension()
        {

        }

        public InjectExtension(Type type)
        {
            Type = type;
        }
        #endregion

        #region Logic
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Type == null)
                throw new ArgumentNullException("Type");

            return Instances.Get(Type);
        }
        #endregion
    }
}