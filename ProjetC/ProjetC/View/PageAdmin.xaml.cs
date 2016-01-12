using ProjetC.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ProjetC
{
    public sealed partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((PageAdminViewModel)DataContext).OnNavigatedTo(e);
        }
    }
}
