using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using lib12.Exceptions;

namespace lib12.WPF.TemplateSelectors
{
    /// <summary>
    /// Choses a approperiate data template for the object from the internal collection.
    /// </summary>
    [ContentProperty("Templates")]
    public class TypeTemplateSelector : DataTemplateSelector
    {
        #region Props
        public List<DataTemplate> Templates { get; private set; }
        #endregion

        #region ctor
        public TypeTemplateSelector()
        {
            Templates = new List<DataTemplate>();
        }
        #endregion

        #region Public Methods
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var type = item.GetType();
                var dataTemplate = Templates.FirstOrDefault(x => x.DataType == type);

                if (dataTemplate != null)
                    return dataTemplate;
                else
                    throw new lib12Exception(string.Format("No template for type {0} was found", item.GetType()));
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
        }
        #endregion
    }
}
