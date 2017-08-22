using System.Windows;
using System.Windows.Input;
using lib12.WPF.Core;
using lib12.WPF.EventTranscriptions;

namespace lib12.WPF.Test.Views
{
    public class EventToCommandViewModel
    {
        public ICommand LeftClickCommand { get; set; }
        public ICommand RightClickCommand { get; set; }
        public string CommandParameter { get; set; }

        public EventToCommandViewModel()
        {
            LeftClickCommand = new DelegateCommand(ExecuteLeftClick);
            RightClickCommand = new DelegateCommand(ExecuteRightClick);
            CommandParameter = "Parameter test";
        }

        private void ExecuteLeftClick(object parameter)
        {
            var eventParameter = (EventTranscriptionParameter<RoutedEventArgs>)parameter;
            MessageBox.Show("Left clicked! " + eventParameter.CommandParameter);
        }

        private void ExecuteRightClick(object parameter)
        {
            var eventParameter = (EventTranscriptionParameter<MouseButtonEventArgs>)parameter;
            MessageBox.Show("Right clicked! "+eventParameter.EventArgs.RightButton);
        }
    }
}
