using pAssistant.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace pAssistant.ViewModel.Commands
{
    public class SaveNewEntryCommand : ICommand
    {

        public EntryDetailsVM Vm { get; set; }

        public event EventHandler CanExecuteChanged;

        public SaveNewEntryCommand(EntryDetailsVM vm)
        {
            Vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.SaveEntry();
            System.Windows.Application.Current.Windows[1].Close();
        }
    }
}
