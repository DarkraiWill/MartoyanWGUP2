using MartoyanWGUP2.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MartoyanWGUP2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Partners.NavigationService.Navigate(new Pages.PartnerListPage());
            ProductionClass pc = new ProductionClass();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Partners.CanGoBack) Partners.GoBack();
        }

        private void Partners_Navigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            Title = $"{page.Title}";

            if (page is Pages.AddPartnerPage)
                Back.Visibility = Visibility.Visible;
            else if (page is Pages.PartnerRealisationHistoryPage)
                Back.Visibility = Visibility.Visible;
            else
                Back.Visibility = Visibility.Hidden;
        }
    }
}
