using System.Windows.Controls;

namespace lib12.WPF.Test.Views
{
    /// <summary>
    /// Interaction logic for DataBasedTemplateSelectorView.xaml
    /// </summary>
    public partial class DataBasedTemplateSelectorView : UserControl
    {
        public DataBasedTemplateSelectorView()
        {
            DataContext = new DataBasedTemplateSelectorViewModel();
            InitializeComponent();
        }
    }
}
