using pAssistant.Model;
using pAssistant.View;
using pAssistant.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pAssistant.ViewModel
{
    public class PassinstantVM : INotifyPropertyChanged
    {
        private Entry selectedEntry;

        public Entry SelectedEntry
        {
            get { return selectedEntry; }
            set
            {
                selectedEntry = value;
                VMInteractionHandler.SelectedEntry = value;
                OnPropertyChanged("SelectedEntry");
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set {
                searchText = value;
                SearchForEntry();
                OnPropertyChanged("SearchText");
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set {
                message = value;
                OnPropertyChanged("Message");
            }
        }



        public static ObservableCollection<Entry> Entries { get; set; }
        public NewEntryCommand NewEntryCommand { get; set; }
        public EditEntryCommand EditEntryCommand { get; set; }
        public DeleteEntryCommand DeleteEntryCommand { get; set; }
        public GetAccountNameCommand GetAccountNameCommand { get; set; }
        public GetPasswordCommand GetPasswordCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public PassinstantVM()
        {
            Entries = new ObservableCollection<Entry>();
            NewEntryCommand = new NewEntryCommand(this);
            EditEntryCommand = new EditEntryCommand(this);
            DeleteEntryCommand = new DeleteEntryCommand(this);
            GetAccountNameCommand = new GetAccountNameCommand(this);
            GetPasswordCommand = new GetPasswordCommand(this);
            VMInteractionHandler.PassinstantVM = this;
            UpdateEntries();
        }



        public void ToggleNewEntry()
        {
            if(VMInteractionHandler.SelectedEntry != null)
            {
                VMInteractionHandler.SelectedEntry = null;
            }
            EntryDetailsWindow entryDetailsWindow = new EntryDetailsWindow();
            entryDetailsWindow.Owner = System.Windows.Application.Current.MainWindow;
            entryDetailsWindow.ShowDialog();
        }

        public void DeleteEntry()
        {
            if(SelectedEntry != null)
            {
                DataBaseHandler.Delete(SelectedEntry);
            }
            UpdateEntries();
        }

        public void ToggleEditEntry()
        {
            if(SelectedEntry != null)
            {
                
                EntryDetailsWindow entryDetailsWindow = new EntryDetailsWindow();
                entryDetailsWindow.Owner = System.Windows.Application.Current.MainWindow;
                entryDetailsWindow.ShowDialog();
                VMInteractionHandler.SetEntryToEdit(SelectedEntry);
            }
        }

        public void UpdateEntries()
        {
            Entries.Clear();

            foreach (var item in DataBaseHandler.ReadTable())
            {
                
                Entries.Add(item as Entry);
            }
        }

        public void GetAccountName()
        {
            if(SelectedEntry != null)
            {
                Clipboard.SetText(SelectedEntry.AccountName);
                Message = $"Account name for {SelectedEntry.EntryName} coppied to clipboard!";
                Task.Delay(3000).ContinueWith(t => Message = "");
            }
        }

        public void GetPassword()
        {
            if (SelectedEntry != null)
            {
                Clipboard.SetText(SelectedEntry.Password);
                Message = $"Password for {SelectedEntry.EntryName} coppied to clipboard!";
                Task.Delay(3000).ContinueWith(t => Message = "");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void SearchForEntry()
        {
            if (SearchText != "")
            {
                Entries.Clear();

                foreach (var item in DataBaseHandler.ReadTable())
                {
                    if (item.EntryName.Contains(SearchText))
                    {
                        Entries.Add(item as Entry);
                    }
                }
            } else
            {
                UpdateEntries();
            }
        }
    }
}
