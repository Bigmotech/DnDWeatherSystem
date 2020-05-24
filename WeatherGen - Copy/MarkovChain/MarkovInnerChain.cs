using System.Collections.Generic;
using System.ComponentModel;

namespace WeatherGen
{
    class MarkovInnerChain<TKey, TValue> : Dictionary<TKey, TValue>, System.ComponentModel.INotifyPropertyChanged
    {
        private int total;
        public int Total {
            get { return total; }
            set {
                total = value;
                OnPropertyChanged("Total");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string proptertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proptertyName));
        }

    
    }
}
