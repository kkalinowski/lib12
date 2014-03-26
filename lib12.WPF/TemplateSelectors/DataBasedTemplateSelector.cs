using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using lib12.Exceptions;
using lib12.Extensions;
using lib12.Reflection;

namespace lib12.WPF.TemplateSelectors
{
    /// <summary>
    /// Choses a approperiate data template for the object from the internal collection.
    /// </summary>
    [ContentProperty("Templates")]
    public class DataBasedTemplateSelector : DataTemplateSelector
    {
        #region Props
        public List<DataBasedTemplate> Templates { get; private set; }

        public string Path { get; set; }
        #endregion

        #region ctor
        public DataBasedTemplateSelector()
        {
            Templates = new List<DataBasedTemplate>();
        }
        #endregion

        #region Public Methods
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var value = item.GetType().GetPropertyValue(item, Path);
                var dataTemplate = Templates.FirstOrDefault(x => x.Value.Equals(value));

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
