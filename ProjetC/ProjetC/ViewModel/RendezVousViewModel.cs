using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ProjetC.DAL;
using ProjetC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace ProjetC.ViewModel
{
    public class RendezVousViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private DataAccess dataAccess;
        private Permanence _permanence;
        private INavigationService _navigationService;
        private RendezVous rdv;
        private String lastName, firstName, emailAdress, problem;
        private int phone;

           public String LastName
           {
               get { return lastName; }
               set { lastName = value; }
           }

           public String FirstName
           {
               get { return firstName; }
               set { firstName = value; }
           }

           public String EmailAdress
           {
               get { return emailAdress; }
               set { emailAdress = value; }
           }

           public int Phone
           {
               get { return phone; }
               set { phone = value; }
           }

           public String Problem
           {
               get { return problem; }
               set { problem = value; }
           }


        [PreferredConstructor]
        public RendezVousViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            _permanence = new Permanence();
            getAllPerma();
            rdv = new RendezVous();
        }


        public void OnNavigatedTo(NavigationEventArgs e) {
        }


          public ICommand _goToMainPageCommand;
          public ICommand GoToMainPageCommand
          {
             get
              {
                 if (_goToMainPageCommand == null)
                  _goToMainPageCommand = new RelayCommand(() => newInscription());
                   return _goToMainPageCommand;
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
            {
                exit();
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

        private void newInscription()
         {
            dataAccess = new DataAccess();
            creerObject();

            if (LastName == null)
            {
                var messageDialog = new MessageDialog("Last name cannot be empty!");
                messageDialog.ShowAsync();
            }
            else if (!ValidLastName(lastName))
            {
                var messageDialog = new MessageDialog("Bad Last name!");
                messageDialog.ShowAsync();
            }
            else if (FirstName == null)
            {
                var messageDialog = new MessageDialog("First name cannot be empty!");
                messageDialog.ShowAsync();
            }

            else if (!ValidLastName(firstName))
            {
                var messageDialog = new MessageDialog("Bad First name!");
                messageDialog.ShowAsync();
            }

            else if (EmailAdress == null)
            {
                var messageDialog = new MessageDialog("Email addresss cannot be empty!");
                messageDialog.ShowAsync();
            }

            else if (!ValidEmailAddress(emailAdress))
            {
                var messageDialog = new MessageDialog("Bad Email Address!");
                messageDialog.ShowAsync();
            }
            
        /*    else if (!ValidPhone(phone))
            {
                var messageDialog = new MessageDialog("Bad Phone number!");
                messageDialog.ShowAsync();
            }*/

           else if (phone>9999999999 || phone < 0)
            {
                var messageDialog = new MessageDialog("Phone number cannot be greater than 10!");
                messageDialog.ShowAsync();
            }

            else if (Problem == null)
            {
                var messageDialog = new MessageDialog("Problem cannot be empty!");
                messageDialog.ShowAsync();
            }

            else
            {
                dataAccess.NewRendezVous(rdv);
                _navigationService.NavigateTo("MainPage");
            }




         }

        private void creerObject()
        {
            rdv.nomEtudiant = lastName;
            rdv.idPerma = _permanence.idPerma;
            rdv.prenomEtudiant = firstName;
            rdv.emailEtudiant = emailAdress;
            rdv.telephoneEtudiant = phone;
            rdv.probleme = problem;
        }


        // Verification des ENTREEES


        private bool ValidFirstName(string firstName)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^[a-zA-Z\s]+$");
            return myRegex.IsMatch(firstName);
        }

        private bool ValidLastName(string lastName)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^[a-zA-Z\s]+$");
            return myRegex.IsMatch(lastName);
        }

        private bool ValidEmailAddress(string emailAddress)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"^([\w]+)\.([\w]+)@([\w]+)\.([\w]+)$");
            return myRegex.IsMatch(emailAddress);
        }

     /*   private bool ValidPhone(int phone)
        {
            System.Text.RegularExpressions.Regex myRegex = new Regex(@"[0 - 9]");
            return myRegex.IsMatch(phone);
        }*/
    }   
}


