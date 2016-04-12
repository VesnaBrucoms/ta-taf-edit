using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TAFEdit.InputOutput;
using TAFEdit.Models;
using TAFEdit.ViewModels.Commands;

namespace TAFEdit.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        GafModel gafModel;

        #region ModelProperties
        public string IdVersion
        {
            get { return "" + gafModel.Header.IdVersion; }
        }

        public string Entries
        {
            get { return "" + gafModel.Header.Entries; }
        }

        public string Unknown1
        {
            get { return "" + gafModel.Header.Unknown1; }
        }

        public string Pointers
        {
            get
            {
                string list = "";
                foreach (int pointer in gafModel.PtrEntries)
                {
                    list += ", " + pointer;
                }

                return list;
            }
        }
        #endregion

        #region ViewModelProperties
        #endregion

        #region CommandProperties
        public ICommand OpenCommand
        {
            get { return new DelegateCommand(Open); }
        }
        #endregion

        public MainWindowViewModel()
        {
            windowTitle = "TAF Edit";

            gafModel = new GafModel();
            gafModel.Header = new Models.GafModelData.GafHeader();
            gafModel.PtrEntries = new int[1];
        }

        private void updateProperties()
        {
            OnPropertyChanged("IdVersion");
            OnPropertyChanged("Entries");
            OnPropertyChanged("Unknown1");
            OnPropertyChanged("Pointers");
        }

        #region Commands
        private void Open(object parameters)
        {
            string filepath = File.GetOpenFileName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "GAF file (*.gaf)|*.gaf");

            if (filepath != null)
            {
                gafModel = GafInputOutput.Read(filepath);
                updateProperties();
            }
        }
        #endregion
    }
}
