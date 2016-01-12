using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjetC.DAL;
using ProjetC.Model;
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
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private DataAccess dataAccess;
        private ObservableCollection<FAQ> _faq;
        private INavigationService _navigationService;
        private Permanence _permanence;

        [PreferredConstructor]
        public MainPageViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            dataAccess = new DataAccess();
            _faq = new ObservableCollection<FAQ>();
            getAllFAQ();
            _permanence = new Permanence();
            getAllPerma();
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        { }

        private ICommand _goToSecondPageCommand;
        public ICommand GoToSecondPageCommand
        {
            get
            {
                if (_goToSecondPageCommand == null)
                    _goToSecondPageCommand = new RelayCommand(() => GoToSecondPage());
                return _goToSecondPageCommand;
            }
        }
        private void GoToSecondPage()
        {
            _navigationService.NavigateTo("RendezVous");
        }

        public ICommand _goToAdminPageCommand;
        public ICommand GoToAdminPageCommand
        {
            get
            {
                if (_goToAdminPageCommand == null)
                    _goToAdminPageCommand = new RelayCommand(() => GoToAdminPage());
                return _goToAdminPageCommand;
            }
        }
        private void GoToAdminPage()
        {         
            _navigationService.NavigateTo("Admin");
        }
        public ObservableCollection<FAQ> FAQ
        {
            get
            {
                return _faq;
            }
            set
            {
                _faq = value;
                RaisePropertyChanged("FAQ");
            }
        }
        public async void getAllFAQ()
        {
            if (CheckNet())
            {
                List<FAQ> lstFAQ = await dataAccess.getAllFaq();
                foreach (var item in lstFAQ)
                    FAQ.Add(item);
            }
            else
            { exit(); }
        }


        public Permanence Permanence
        {
            get
            {
                return _permanence;
            }
            set
            {
                _permanence = value;
                RaisePropertyChanged("FAQ");
            }
        }

        public async void getAllPerma()
        {
            if (CheckNet()) {
                List<Permanence> lstPerma = await dataAccess.getAllPerma();
                DateTime dateAjd = DateTime.Today;
                foreach (var item in lstPerma)
                {
                    DateTime td = Convert.ToDateTime(item.datePerma);
                    if (td > dateAjd && _permanence.heureDebutPerma == 0)
                    {
                        _permanence = item;
                    }
                }
            }

        }

        public async void exit()
        {
            var messageDialog = new MessageDialog("No internet connection has been found.");
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
