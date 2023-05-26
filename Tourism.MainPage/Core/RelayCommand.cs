 using System;
using System.Windows.Input;

namespace Tourism.MainPage.Core
{
    public class RelayCommand : ICommand
    {
        //I created a 2 field
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
                
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public bool CanExecute( object parameter ) 
        {
             return _canExecute(parameter);  
        } 

        public void Execute( object parameter )     
        { 
         _execute(parameter);
        }
    }
}
