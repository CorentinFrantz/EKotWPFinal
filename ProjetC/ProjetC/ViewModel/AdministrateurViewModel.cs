using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ProjetC.DAL;
using ProjetC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace ProjetC.ViewModel
{
    public class AdministrateurViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private DataAccess dataAccess;
        private INavigationService _navigationService;
        private ObservableCollection<Admin> _admin;
        private String motdepasse;
        private Admin admin;
   
        public AdministrateurViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataAccess = new DataAccess();
            _admin = new ObservableCollection<Admin>();
            admin = new Admin();

        }

        public String MotDePasse
        {
            get { return motdepasse; }
            set { motdepasse = value; }
        }

        public ObservableCollection<Admin> Admin
        {
            get
            {
                return _admin;
            }
            set
            {
                _admin = value;
                RaisePropertyChanged("AdministrateurPage");
            }
        }
        public async void getPassword()
        {
            if (CheckNet())
            {
                List<Admin> lstAdmin = await dataAccess.getPassword();
                foreach (var item in lstAdmin)
                {
                    if (item.motDePasse.Equals(MotDePasse))
                    {
                        _navigationService.NavigateTo("PageAdmin");

                    }
                    else
                    {
                        message();
                    }
                }
            }
            else
            {
                exit();
            }
        }


    public ICommand _goToPageAdminCommand;
        public ICommand GoToPageAdminCommand
        {
            get
            {
                if (_goToPageAdminCommand == null)
                    _goToPageAdminCommand = new RelayCommand(() => getPassword());
                return _goToPageAdminCommand;
            }
        }
        private void GoToPageAdmin()
        {
          _navigationService.NavigateTo("PageAdmin");

        }

        public ICommand _ButtonAccueil;
        public ICommand ButtonAccueil
        {
            get
            {
                if (_ButtonAccueil == null)
                    _ButtonAccueil = new RelayCommand(() => GoToMainPage());
                return _ButtonAccueil;
            }
        }

        private void GoToMainPage()
        {
            _navigationService.NavigateTo("MainPage");
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public async void message()
        {
            var messageDialog = new MessageDialog("Bad password");
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();

        }

        public async void exit()
        {
            var messageDialog = new MessageDialog("No internet connection has been found.");
            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Close program",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            await messageDialog.ShowAsync();
        }


        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label.Equals("Close program"))
            {
                Application.Current.Exit();
            }
        }


        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }


}
}
