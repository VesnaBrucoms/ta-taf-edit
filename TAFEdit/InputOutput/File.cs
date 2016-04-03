using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAFEdit.InputOutput
{
    /// <summary>
    /// Handles operations on files.
    /// </summary>
    public class File
    {
        /// <summary>
        /// Checks if filename ends with the specified extension. Adds the extension if it doesn't.
        /// </summary>
        public static string CheckNameExtensionExists(string fileName, string extension)
        {
            if (!fileName.EndsWith(extension))
            {
                return fileName += extension;
            }
            else
            {
                return fileName;
            }
        }

        /// <summary>
        /// Checks if filename ends with the specified extension. Adds the extension if it doesn't.
        /// </summary>
        public static string CheckNameExtensionExists(string fileName, string extension, bool ignoreCase)
        {
            if (ignoreCase)
            {
                if (!fileName.EndsWith(extension, true, null))
                {
                    return fileName += extension;
                }
                else
                {
                    return fileName;
                }
            }
            else
                return CheckNameExtensionExists(fileName, extension);
        }

        /// <summary>
        /// Removes the file extension.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Returns the filename without the extension.</returns>
        public static string RemoveExtension(string filePath)
        {
            int newLength = 0;

            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                char chara = filePath[i];
                if (chara == '.')
                {
                    newLength = i;
                    break;
                }
            }

            if (newLength != 0)
            {
                return filePath.Substring(0, newLength);
            }
            else
                return filePath;
        }

        /// <summary>
        /// Extracts the last part of the path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Returns the name after the final '\\' character.</returns>
        public static string ExtractFileName(string filePath)
        {
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                char chara = filePath[i];
                if (chara == '\\')
                {
                    filePath = filePath.Substring(i + 1);
                    break;
                }
            }

            return filePath;
        }

        /// <summary>
        /// Removes the last part of the path.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Returns the path minus the last part of the path.</returns>
        public static string ExtractFilePath(string filePath)
        {
            int newLength = 0;

            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                char chara = filePath[i];
                if (chara == '\\')
                {
                    newLength = i;
                    break;
                }
            }

            if (newLength != 0)
                return filePath.Substring(0, newLength);
            else
                return filePath;
        }

        /// <summary>
        /// Creates a save file dialog at the specified directory, with the filename and filter.
        /// </summary>
        /// <param name="initialDirectory">The starting directory.</param>
        /// <param name="fileName">The name of the file to be saved.</param>
        /// <param name="fileFilter">The file format filter. e.g. OTA file (*.ota)|*.ota</param>
        /// <returns>Returns the full path and name of the save location. Return NULL if the user closes or cancels the dialog.</returns>
        public static string GetSaveFileName(string initialDirectory, string fileName, string fileFilter)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.InitialDirectory = Path.GetFullPath(initialDirectory);
            //dlg.FileName = Path.GetFileNameWithoutExtension(fileName);
            dlg.FileName = fileName;
            dlg.Filter = fileFilter;

            bool? result = dlg.ShowDialog();

            if (result == true)
                return dlg.FileName;

            return null;
        }

        /// <summary>
        /// Creates an open file dialog at the specified directory, with the set filters.
        /// </summary>
        /// <param name="initialDirectory">The starting directory.</param>
        /// <param name="fileFilter">The file format filter. e.g. OTA file (*.ota)|*.ota</param>
        /// <returns>Returns the full path and name of the chosen file. Returns NULL if the user closes or cancels the dialog.</returns>
        public static string GetOpenFileName(string initialDirectory, string fileFilter)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = Path.GetFullPath(initialDirectory);
            //dlg.FileName = Path.GetFileNameWithoutExtension("Readme");
            dlg.Filter = fileFilter;

            bool? result = dlg.ShowDialog();

            if (result == true)
                return dlg.FileName;

            return null;
        }

        /// <summary>
        /// Creates a folder browser dialog at the specified directory, with the description.
        /// </summary>
        /// <param name="initialDirectory">The starting directory.</param>
        /// <param name="description">Sets the description seen on the dialog.</param>
        /// <returns>Returns the selected path if the user clicks OK. Returns the initialDirectory if Cancel was clicked. Returns NULL otherwise.</returns>
        public static string GetFolderName(string initialDirectory, string description)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            dlg.Description = description;

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
                return dlg.SelectedPath;
            else if (result == DialogResult.Cancel)
                return initialDirectory;

            return null;
        }
    }
}
