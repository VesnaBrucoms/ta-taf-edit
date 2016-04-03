using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TAFEdit.IniSettings
{
    class IniDefaultValues
    {
        public static string STRING_OTA_LAST_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public const bool BOOL_TOOLBAR_VISIBLE = true;
        public const bool BOOL_STATUSBAR_VISIBLE = true;
        public const bool BOOL_TOOLBAR_STAND_VISIBLE = true;
        public const bool BOOL_TOOLBAR_SETTINGS_VISIBLE = true;
    }
}
