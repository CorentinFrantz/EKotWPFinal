using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<RendezVousViewModel>();
            SimpleIoc.Default.Register<AdministrateurViewModel>();
            SimpleIoc.Default.Register<PageAdminViewModel>();

            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("RendezVous", typeof(RendezVousPage));
            navigationService.Configure("Admin", typeof(AdministrateurPage));
            navigationService.Configure("PageAdmin", typeof(PageAdmin));
        }
        public MainPageViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
        public RendezVousViewModel RendezVous
        {
            get { return ServiceLocator.Current.GetInstance<RendezVousViewModel>();  }
        }
        public AdministrateurViewModel Admin
        {
            get { return ServiceLocator.Current.GetInstance<AdministrateurViewModel>(); }
        }
        public PageAdminViewModel PageAdmin
        {
            get { return ServiceLocator.Current.GetInstance<PageAdminViewModel>();  }
        }
    }
}
