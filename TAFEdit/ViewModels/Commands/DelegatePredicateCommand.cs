using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TAFEdit.ViewModels.Commands
{
    class DelegatePredicateCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        public DelegatePredicateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegatePredicateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {

                if (canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {

                if (canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            return canExecute(parameter);
        }
    }
}
