using System;
using System.ComponentModel;

namespace JedSharp.GLPIFatClient.UIModels.ViewModel
{
    public class TicketViewModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyRaised("Id");
            }
        }

        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyRaised("Name");
            }
        }

        private String _content;
        public String Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyRaised("Content");
            }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                OnPropertyRaised("CreationDate");
            }
        }

        private DateTime _modificationDate;
        public DateTime ModificationDate
        {
            get { return _modificationDate; }
            set
            {
                _modificationDate = value;
                OnPropertyRaised("ModificationDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
