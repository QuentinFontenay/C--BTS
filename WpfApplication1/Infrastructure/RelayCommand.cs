using System;
using System.Windows.Input;

namespace WpfApplication1.Infrastructure
{
    public class RelayCommand : ICommand

    {
    private readonly Action _actionAExecuter = null;

    public event EventHandler CanExecuteChanged;

    public RelayCommand(Action action)
    {
        _actionAExecuter = action;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _actionAExecuter();
    }
    }
}