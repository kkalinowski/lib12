using System.Windows.Controls;

namespace lib12.WPF.Test.Views
{
    /// <summary>
    /// Interaction logic for EventToCommandView.xaml
    /// </summary>
    public partial class EventToCommandView : UserControl
    {
        public EventToCommandView()
        {
            InitializeComponent();
            DataContext = new EventToCommandViewModel();
        }
    }
}
