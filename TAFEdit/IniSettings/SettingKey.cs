using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAFEdit.IniSettings
{
    class SettingKey
    {
        private string name;
        private string value;

        public string GetName
        {
            get { return name; }
        }
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public SettingKey(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
