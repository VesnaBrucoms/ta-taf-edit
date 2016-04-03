using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TAFEdit.IniSettings;
using TAFEdit.ViewModels;
using TAFEdit.ViewModels.Services;

namespace TAFEdit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Ini iniSettings;
        private EnvironmentService environmentService;

        public void App_Startup(object sender, StartupEventArgs e)
        {
            iniSettings = new Ini();
            environmentService = new EnvironmentService(AppDomain.CurrentDomain.BaseDirectory);
            iniSettings.Read(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TAF Edit", "settings");

            Views.MainWindow mainWindow = new Views.MainWindow();
            mainWindow.DataContext = new MainWindowViewModel();
            MainWindow = mainWindow;
            mainWindow.Show();
        }

        public void App_Exit(object sender, ExitEventArgs e)
        {
            iniSettings.Write(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TAF Edit", "settings");
        }
    }
}
