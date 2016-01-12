using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjetC.DAL;
using ProjetC.Model;
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
    public class PageAdminViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private DataAccess dataAccess;
        private ObservableCollection<RendezVous> _problem;
        private INavigationService _navigationService;
        private Permanence _permanence;

        [PreferredConstructor]
        public PageAdminViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            
            _problem = new ObservableCollection<RendezVous>();
            _permanence = new Permanence();
            getAllPerma();
        }


        public void OnNavigatedTo(NavigationEventArgs e)
        { }

        public ObservableCollection<RendezVous> RendezVous
        {
            get
            {
                return _problem;
            }
            set
            {
                _problem = value;
                RaisePropertyChanged("PageAdmin");
            }
        }
        public async void getAllProblem()
        {
            if (CheckNet())
            {
                dataAccess = new DataAccess();
                List<RendezVous> lstProblem = await dataAccess.getAllProblem();
                foreach (var item in lstProblem)
                {
                    if (item.idPerma == _permanence.idPerma)
                        RendezVous.Add(item);
                }
            }
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

        public ICommand _recherche;
        public ICommand Recherche
        {
            get
            {
                if (_recherche == null)
                    _recherche = new RelayCommand(() => getAllProblem());
                return _recherche;
            }
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
            if (CheckNet())
            {
                dataAccess = new DataAccess();
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
            else
                exit();
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

