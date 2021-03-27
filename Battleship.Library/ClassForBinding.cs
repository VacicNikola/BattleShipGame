using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleship.Library
{
    public class ClassForBinding : INotifyPropertyChanged
    {
        private string _status, _source, _naslov;

        public string Status { get { return _status; } set { _status = value; OnPropertyChanged("Status"); } }

        public string Source { get { return _source; } set { _source = value; OnPropertyChanged("Source"); } }

        public string Naslov { get { return _naslov; } set { _naslov = value; OnPropertyChanged("Naslov"); } }

        public ClassForBinding()
        {
            //Status = "";
        }

        private void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
