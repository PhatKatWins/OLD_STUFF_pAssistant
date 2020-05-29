using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace pAssistant.ViewModel.Commands
{
    public class GetAccountNameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public PassinstantVM Vm { get; set; }

        public GetAccountNameCommand(PassinstantVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.GetAccountName();
        }
    }
}
