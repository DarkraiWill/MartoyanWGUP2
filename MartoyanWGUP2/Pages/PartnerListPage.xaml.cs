using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MartoyanWGUP2.Pages
{
    public partial class PartnerListPage : Page
    {
        ProductionDBEntities _context = ProductionDBEntities.GetContext();
        public PartnerListPage()
        {
            InitializeComponent();
            PartnersList.ItemsSource = ProductionDBEntities.GetContext().Partners.ToList();
            CountDiscountByPartners();
        }
        private void CountDiscountByPartners()
        {
            var partnerSales = _context.PartnerProducts
                .GroupBy(x => x.PartnerID)
                .Select(group => new
                {
                    PartnerId = group.Key,
                    TotalSales = group.Sum(p => p.ProductionCount)
                })
                .ToList();

            foreach (var partner in _context.Partners)
            {
                var salesData = partnerSales.FirstOrDefault(ps => ps.PartnerId == partner.ID);
                if (salesData != null)
                {
                    if (salesData.TotalSales < 10000)
                    {
                        partner.Discount = 0;
                    }
                    else if (salesData.TotalSales >= 10000 && salesData.TotalSales < 50000)
                    {
                        partner.Discount = 5;
                    }
                    else if (salesData.TotalSales >= 50000 && salesData.TotalSales < 300000)
                    {
                        partner.Discount = 10;
                    }
                    else partner.Discount = 15;
                }
            }
            _context.SaveChanges();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PartnersList.SelectedItem is Partner partner)
            {
                NavigationService.Navigate(new AddPartnerPage(partner));
            }
        }

        private void RealizationHystoryButton_Click(object sender, RoutedEventArgs e)
        {
            List<Partner> partners = PartnersList.SelectedItems.Cast<Partner>().ToList();
            if (partners.Count > 1)
            {
                MessageBox.Show("Выберите только одного партнера!", "Внимание");
            }
            else if (partners.Count == 0) MessageBox.Show("Выберите партнера!", "Внимание");
            else NavigationService?.Navigate(new PartnerRealisationHistoryPage(partners[0]));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPartnerPage addpage = new AddPartnerPage(null);
            NavigationService?.Navigate(addpage);

            addpage.OnPartnerAdded += (newPartner) =>
            {
                var list = _context.Partners.ToList();
                list.Add(newPartner);
                PartnersList.ItemsSource = list;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Partner partners = (Partner)button.DataContext;
            NavigationService?.Navigate(new PartnerRealisationHistoryPage(partners));
        }
    }
}
