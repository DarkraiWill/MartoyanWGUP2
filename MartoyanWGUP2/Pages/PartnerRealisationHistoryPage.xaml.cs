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

namespace MartoyanWGUP2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnerRealisationHistoryPage.xaml
    /// </summary>
    public partial class PartnerRealisationHistoryPage : Page
    {
        public PartnerRealisationHistoryPage(Partner partner)
        {
            InitializeComponent();
            Title = $"История реализации товара {partner.PartnersType.PartnerTypeName} {partner.PartnerName}";
            PartnerProductsDataGrid.ItemsSource = partner.PartnerProducts.ToList();
        }
    }
}
