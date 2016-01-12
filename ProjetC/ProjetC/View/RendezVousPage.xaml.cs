using ProjetC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjetC
{
    public sealed partial class RendezVousPage : Page
    {
        public RendezVousPage()
        {
            this.InitializeComponent();
         //   this.DataContext = new RendezVousViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((RendezVousViewModel)DataContext).OnNavigatedTo(e);
        }


    }
}
