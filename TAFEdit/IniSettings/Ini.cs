using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TAFEdit.IniSettings
{
    class Ini
    {
        private const char DELIMITER = '=';

        private List<SettingKey> settings;

        public Ini()
        {
            settings = new List<SettingKey>();
        }

        public bool SettingExists(string settingName)
        {
            foreach (SettingKey setting in settings)
            {
                if (setting.GetName == settingName)
                    return true;
            }

            return false;
        }

        public void AddNewSetting(string name, string value)
        {
            settings.Add(new SettingKey(name, value));
        }

        public string GetValueByName(string settingName)
        {
            foreach (SettingKey setting in settings)
            {
                if (setting.GetName == settingName)
                    return setting.Value;
            }

            return "";
        }

        public void ChangeValueByName(string settingName, string newValue)
        {
            foreach (SettingKey setting in settings)
            {
                if (setting.GetName == settingName)
                {
                    setting.Value = newValue;
                }
            }
        }

        public bool DeleteSetting(SettingKey setting)
        {
            return settings.Remove(setting);
        }

        public bool DeleteSettingByName(string name)
        {
            for (int i = 0; i < settings.Count; i++)
            {
                if (settings[i].GetName == name)
                {
                    settings.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Reads a .ini file from the programme's directory.
        /// </summary>
        /// <param name="fileName">The .ini file's name.</param>
        /// <returns>True if successful, false if not</returns>
        public bool Read(string fileName)
        {
            string filePath = Directory.GetCurrentDirectory();
            fileName = TAFEdit.InputOutput.File.CheckNameExtensionExists(fileName, ".ini");
            if (!File.Exists(filePath + "\\" + fileName))
            {
                return false;
            }

            using (StreamReader reader = new StreamReader(filePath + "\\" + fileName, false))
            {
                string lineText = "";

                while (!reader.EndOfStream)
                {
                    lineText = reader.ReadLine();
                    if (lineText.Contains(DELIMITER))
                    {
                        int delimiterIndex = lineText.IndexOf(DELIMITER);
                        settings.Add(new SettingKey(lineText.Substring(0, delimiterIndex), lineText.Substring(delimiterIndex + 1)));
                    }
                }
            }
            return true;
        }

        public bool Read(string filePath, string fileName)
        {
            fileName = TAFEdit.InputOutput.File.CheckNameExtensionExists(fileName, ".ini");
            if (!File.Exists(filePath + "\\" + fileName))
            {
                return false;
            }

            using (StreamReader reader = new StreamReader(filePath + "\\" + fileName, false))
            {
                string lineText = "";

                while (!reader.EndOfStream)
                {
                    lineText = reader.ReadLine();
                    if (lineText.Contains(DELIMITER))
                    {
                        int delimiterIndex = lineText.IndexOf(DELIMITER);
                        settings.Add(new SettingKey(lineText.Substring(0, delimiterIndex), lineText.Substring(delimiterIndex + 1)));
                    }
                }
            }
            return true;
        }

        public void Write(string fileName)
        {
            string filePath = Directory.GetCurrentDirectory();
            if (settings.Count != 0)
            {
                fileName = TAFEdit.InputOutput.File.CheckNameExtensionExists(fileName, ".ini");

                using (StreamWriter writer = new StreamWriter(filePath + "\\" + fileName, false))
                {
                    foreach (SettingKey setting in settings)
                    {
                        writer.WriteLine(setting.GetName + DELIMITER + setting.Value);
                    }
                }
            }
        }

        public void Write(string filePath, string fileName)
        {
            if (settings.Count != 0)
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                fileName = TAFEdit.InputOutput.File.CheckNameExtensionExists(fileName, ".ini");

                using (StreamWriter writer = new StreamWriter(filePath + "\\" + fileName, false))
                {
                    foreach (SettingKey setting in settings)
                    {
                        writer.WriteLine(setting.GetName + DELIMITER + setting.Value);
                    }
                }
            }
        }
    }
}
