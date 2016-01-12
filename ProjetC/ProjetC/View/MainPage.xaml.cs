using ProjetC.ViewModel;
using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjetC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((MainPageViewModel)DataContext).OnNavigatedTo(e);
        }

        // Traitement des liens externes
        private void SettingsHub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedIndex == 0)
            {
                Launcher.LaunchUriAsync(new Uri("https://ekot.alwaysdata.net/ajout.php", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 1)
            {
                Launcher.LaunchUriAsync(new Uri("https://ekot.alwaysdata.net/suppression.php", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 2)
            {
                Launcher.LaunchUriAsync(new Uri("https://ekot.alwaysdata.net/quota.phpyahoo.fr", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 3)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.commentcamarche.net/faq/31072-ecran-bleu-windows", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 4)
            {
                Launcher.LaunchUriAsync(new Uri("https://helpx.adobe.com/fr/acrobat/kb/cant-open-pdf.html", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 5)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.commentcamarche.net/forum/affich-1227748-mon-pc-ne-s-allume-plus", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 6)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.commentcamarche.net/forum/affich-2978116-application-ne-se-lance-pas", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 7)
            {
                Launcher.LaunchUriAsync(new Uri("http://windows.microsoft.com/fr-be/windows-vista/troubleshoot-internet-connection-problems", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 8)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.commentcamarche.net/forum/affich-1422868-probleme-de-connexion-wifi", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 9)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.commentcamarche.net/forum/affich-28175861-je-ne-peux-plus-jouer-a-aucun-jeu-en-ligne", UriKind.Absolute));
            }
            else if (listView.SelectedIndex == 10)
            {
                Launcher.LaunchUriAsync(new Uri("http://www.tomsguide.fr/forum/id-459656/resolu-probleme-steam-jeux-anglais.html", UriKind.Absolute));

            }

        }
    }
}


