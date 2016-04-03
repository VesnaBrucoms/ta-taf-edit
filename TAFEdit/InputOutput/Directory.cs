using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAFEdit.InputOutput
{
    /// <summary>
    /// Handles operations on directories.
    /// </summary>
    static class Directory
    {
        /// <summary>
        /// Returns a list of every file in a directory with a specified extension.
        /// </summary>
        public static List<string> GetFiles(string filePath, string extension)
        {
            if (!System.IO.Directory.Exists(filePath) || System.IO.Directory.GetFiles(filePath) == null || System.IO.Directory.GetFiles(filePath).Length == 0)
            {
                return new List<string>();
            }
            else
            {
                List<string> files = new List<string>();
                foreach (string file in System.IO.Directory.GetFiles(filePath))
                {
                    if (file.EndsWith(extension))
                    {
                        string[] split = file.Split('\\');
                        files.Add(split[split.Length - 1]);
                    }
                }

                return files;
            }
        }

        public static string CheckDirectoryExists(string directory)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                DialogResult result = MessageBox.Show(directory + " does not exist.\n\nDo you want to create it?", "Directory", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                 if (result == DialogResult.Yes)
                 {
                     System.IO.Directory.CreateDirectory(directory);
                     return directory;
                 }
                 else if (result == DialogResult.No)
                 {
                     return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                 }
                 else
                 {
                     return null;
                 }
            }
            else
            {
                return directory;
            }
        }
    }
}
