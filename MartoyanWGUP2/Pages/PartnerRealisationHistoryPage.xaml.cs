
using System.Linq;
using System.Windows.Controls;

namespace MartoyanWGUP2.Pages
{
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
