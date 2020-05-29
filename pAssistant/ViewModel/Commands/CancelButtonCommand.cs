using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace pAssistant.ViewModel.Commands
{
    public class CancelButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public EntryDetailsVM Vm { get; set; }

        public CancelButtonCommand(EntryDetailsVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Windows.Application.Current.Windows[1].Close();
        }
    }
}
