using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantOnline.Commands
{
    class RelayCommand : ICommand
    {

        private Action<object> commandTask;
        private Predicate<object> _canExecute;

        public RelayCommand(Action<object> workToDo)
        {
            commandTask = workToDo;
        }

        public RelayCommand(Action<object> workToDo, Predicate<object> canExecute)
        {
            commandTask = workToDo ?? throw new NullReferenceException("execute");
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {

            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            commandTask(parameter);
        }
    }
}
