using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFEdit.ViewModels.Services
{
    class EnvironmentService
    {
        private string appPath;
        private string startupFilePath;
        private bool hasStartupFailed;

        public string GetAppPath
        {
            get { return appPath; }
        }

        public string StartupFilePath
        {
            get { return startupFilePath; }
            set { startupFilePath = value; }
        }

        public bool HasStartupFailed
        {
            get { return hasStartupFailed; }
            set { hasStartupFailed = value; }
        }

        public EnvironmentService(string appPath)
        {
            this.appPath = appPath;
            startupFilePath = "";
            hasStartupFailed = false;
        }
    }
}
