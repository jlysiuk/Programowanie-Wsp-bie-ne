using System;
using System.Windows.Input;

namespace ViewModel {
    //Obiekty tej klasy sluza do polaczenia kontrolek i elementow warstwy View z metodami z warstwy Model przy wykorzystaniu warstwy ViewModel
    public class Relay : ICommand {
        public event EventHandler CanExecuteChanged;
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public Relay(Action<object> execute, Predicate<object> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public Relay(Action<object> execute) : this(execute, null) {

        }

        public bool CanExecute(object parameter) {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter) {
            _execute(parameter);
        }
    }
}
