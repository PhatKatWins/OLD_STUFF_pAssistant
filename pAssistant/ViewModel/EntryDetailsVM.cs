using pAssistant.Model;
using pAssistant.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace pAssistant.ViewModel
{
    public class EntryDetailsVM :INotifyPropertyChanged
    {
        private Entry entry;

        public Entry Entry
        {
            get { return entry; }
            set
            {
                entry = value;
                OnPropertyChanged("Entry");
            }
        }

        //public Entry EntryToEdit { get; set; }

        public SaveNewEntryCommand SaveNewEntryCommand { get; set; }
        public CancelButtonCommand CancelButtonCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public EntryDetailsVM()
        {
            SaveNewEntryCommand = new SaveNewEntryCommand(this);
            CancelButtonCommand = new CancelButtonCommand(this);

            VMInteractionHandler.EntryDetailsVM = this;
            if(VMInteractionHandler.SelectedEntry == null)
            {
                Entry = new Entry();
            } else
            {
                Entry = VMInteractionHandler.SelectedEntry;
            };
        }

        public void SaveEntry()
        {
            if(VMInteractionHandler.SelectedEntry == null) {
                Entry.CreatedDate = DateTime.Now;
                Entry.LastEditedDate = DateTime.Now;
                DataBaseHandler.Insert(Entry);
                VMInteractionHandler.UpdateEntryList();
            } else
            {
                Entry.LastEditedDate = DateTime.Now;
                DataBaseHandler.Update(Entry);
                VMInteractionHandler.UpdateEntryList();
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
