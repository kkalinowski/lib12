using System;
using System.Windows.Input;

namespace lib12.WPF.Core
{
    public class DelegateCommand<T> : ICommand
    {
        #region Fields
        private readonly Predicate<T> canExecutePredicate;
        private readonly Action<T> executeAction;
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
            return CanExecuteSupported ? canExecutePredicate((T)parameter) : true;
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
        public DelegateCommand(Action<T> _executeAction, Predicate<T> _canExecutePredicate = null)
        {
            executeAction = _executeAction;
            canExecutePredicate = _canExecutePredicate;
        }

        #endregion

        #region Execute
        public void Execute(object parameter)
        {
            executeAction((T)parameter);
        }
        #endregion
    }
}

