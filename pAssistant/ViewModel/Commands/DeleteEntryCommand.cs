using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace pAssistant.ViewModel.Commands
{
    public class DeleteEntryCommand : ICommand
    {
        public PassinstantVM Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public DeleteEntryCommand(PassinstantVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.DeleteEntry();
        }
    }
}
