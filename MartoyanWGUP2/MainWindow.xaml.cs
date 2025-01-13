using MartoyanWGUP2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MartoyanWGUP2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
