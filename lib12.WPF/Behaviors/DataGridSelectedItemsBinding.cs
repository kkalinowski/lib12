using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace lib12.WPF.Behaviors
{
    public class DataGridSelectedItemsBinding : Behavior<DataGrid>
    {
        #region SelectedItems
        public object[] SelectedItems
        {
            get { return (object[])GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(object[]), typeof(DataGridSelectedItemsBinding));
        #endregion

        #region Start
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItems = AssociatedObject.SelectedItems.Cast<object>().ToArray();
        }
        #endregion
    }
}
