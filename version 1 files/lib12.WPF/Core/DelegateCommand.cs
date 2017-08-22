using System;
using System.Windows.Input;

namespace lib12.WPF.Core
{
    public class DelegateCommand : ICommand
    {
        #region Fields
        private readonly Predicate<object> canExecutePredicate;
        private readonly Action<object> executeAction;
        #endregion

        #region CanExecute
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (CanExecuteSupported)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (CanExecuteSupported)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteSupported ? canExecutePredicate(parameter) : true;
        }

        #endregion

        #region Props
        public bool CanExecuteSupported
        {
            get
            {
                return canExecutePredicate != null;
            }
        }
        #endregion

        #region ctor
        public DelegateCommand(Action<object> _executeAction, Predicate<object> _canExecutePredicate = null)
        {
            executeAction = _executeAction;
            canExecutePredicate = _canExecutePredicate;
        }

        #endregion

        #region Execute
        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
        #endregion
    }
}

