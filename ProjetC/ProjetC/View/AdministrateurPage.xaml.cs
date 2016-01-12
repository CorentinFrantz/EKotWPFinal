using ProjetC.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjetC
{
    public sealed partial class AdministrateurPage : Page
    {
        public AdministrateurPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((AdministrateurViewModel)DataContext).OnNavigatedTo(e);
        }
    }
}
