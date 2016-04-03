using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.ViewModels
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        protected string windowTitle;
        protected string statusBarText;

        public string GetWindowTitle
        {
            get { return windowTitle; }
        }

        public string GetStatusBarText
        {
            get { return statusBarText; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
                Console.WriteLine(propertyName);
            }
        }
    }
}
