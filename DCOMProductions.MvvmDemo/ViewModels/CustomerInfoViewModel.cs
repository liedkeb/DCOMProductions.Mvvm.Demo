using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCOMProductions.MvvmDemo.ViewModels
{
    internal class CustomerInfoViewModel : INotifyPropertyChanged
    {
        private string info;
        public String Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(v));
            }
        }
        #endregion
    }
}
