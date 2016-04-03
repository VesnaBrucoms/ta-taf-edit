/*using TAFEdit.ViewModels.AboutViewModels;
using TAFEdit.Views;
using TAFEdit.Views.AboutViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TAFEdit.ViewModels.Services
{
    class WindowViewLoaderService
    {
        private static WindowViewLoaderService instance = new WindowViewLoaderService();

        private Dictionary<Type, Type> viewViewModels;
        private Window parentWindow;

        public static WindowViewLoaderService GetInstance
        {
            get { return instance; }
        }

        public Window SetMainWindow
        {
            set { parentWindow = value; }
        }

        private WindowViewLoaderService()
        {
            viewViewModels = new Dictionary<Type, Type>();
        }

        public void Register(Type viewModel, Type view)
        {
            viewViewModels.Add(viewModel, view);
        }

        public void ShowWindow(object viewModel)
        {
            if (viewViewModels.ContainsKey(viewModel.GetType()))
            {
                Type view;
                viewViewModels.TryGetValue(viewModel.GetType(), out view);

                if (view == typeof(MissionSettingsView))
                {
                    MissionSettingsView window = new MissionSettingsView();
                    MissionSettingsViewModel missionSettingsViewModel = (MissionSettingsViewModel)viewModel;
                    window.DataContext = missionSettingsViewModel;
                    window.Show();
                }
                else if (view == typeof(AddEditView))
                {
                    AddEditView window = new AddEditView();
                    AddEditViewModel addEditViewModel = (AddEditViewModel)viewModel;
                    window.DataContext = addEditViewModel;
                    window.Show();
                }
                else if (view == typeof(SaveDialogView))
                {
                    SaveDialogView window = new SaveDialogView();
                    SaveDialogViewModel saveDialogViewModel = (SaveDialogViewModel)viewModel;
                    window.DataContext = saveDialogViewModel;
                    window.Show();
                }
                else if (view == typeof(RemoveDialogView))
                {
                    RemoveDialogView window = new RemoveDialogView();
                    RemoveDialogViewModel removeDialogViewModel = (RemoveDialogViewModel)viewModel;
                    window.DataContext = removeDialogViewModel;
                    window.Show();
                }
                else if (view == typeof(AboutView))
                {
                    AboutView window = new AboutView();
                    AboutViewModel aboutViewModel = (AboutViewModel)viewModel;
                    window.DataContext = aboutViewModel;
                    window.Show();
                }
            }
        }

        public bool? ShowDialog(object viewModel)
        {
            bool? result = null;

            if (viewViewModels.ContainsKey(viewModel.GetType()))
            {
                Type view;
                viewViewModels.TryGetValue(viewModel.GetType(), out view);

                if (view == typeof(MissionSettingsView))
                {
                    MissionSettingsView window = new MissionSettingsView();
                    MissionSettingsViewModel missionSettingsViewModel = (MissionSettingsViewModel)viewModel;
                    window.DataContext = missionSettingsViewModel;
                    window.Owner = parentWindow;
                    result = window.ShowDialog();
                }
                else if (view == typeof(AddEditView))
                {
                    AddEditView window = new AddEditView();
                    AddEditViewModel addEditViewModel = (AddEditViewModel)viewModel;
                    window.DataContext = addEditViewModel;
                    window.Owner = parentWindow;
                    result = window.ShowDialog();
                }
                else if (view == typeof(SaveDialogView))
                {
                    SaveDialogView window = new SaveDialogView();
                    SaveDialogViewModel saveDialogViewModel = (SaveDialogViewModel)viewModel;
                    window.DataContext = saveDialogViewModel;
                    window.Owner = parentWindow;
                    result = window.ShowDialog();
                }
                else if (view == typeof(RemoveDialogView))
                {
                    RemoveDialogView window = new RemoveDialogView();
                    RemoveDialogViewModel removeDialogViewModel = (RemoveDialogViewModel)viewModel;
                    window.DataContext = removeDialogViewModel;
                    window.Owner = parentWindow;
                    result = window.ShowDialog();
                }
                else if (view == typeof(AboutView))
                {
                    AboutView window = new AboutView();
                    AboutViewModel aboutViewModel = (AboutViewModel)viewModel;
                    window.DataContext = aboutViewModel;
                    window.Owner = parentWindow;
                    result = window.ShowDialog();
                }
            }

            return result;
        }
    }
}*/
