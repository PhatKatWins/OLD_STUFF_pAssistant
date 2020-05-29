using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace pAssistant.Model
{
    public class Entry : INotifyPropertyChanged
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        private string entryName;

        public string EntryName
        {
            get { return entryName; }
            set
            {
                entryName = value;
                OnPropertyChanged("EntryName");
            }
        }

        private string accountName;

        public string AccountName
        {
            get { return accountName; }
            set
            {
                accountName = value;
                OnPropertyChanged("AccountName");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set
            {
                createdDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }

        private DateTime lastEditedDate;

        public DateTime LastEditedDate
        {
            get { return lastEditedDate; }
            set
            {
                lastEditedDate = value;
                OnPropertyChanged("LastEditedDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
