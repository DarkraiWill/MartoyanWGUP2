using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MartoyanWGUP2.Pages
{
    public partial class AddPartnerPage : Page
    {
        ProductionDBEntities db = ProductionDBEntities.GetContext();
        public event Action<Partner> OnPartnerAdded;

        Partner _currentpartner;
        public AddPartnerPage(Partner partner)
        {
            InitializeComponent();

            if (partner != null)
            {
                Title = "Редактирование партнера";
                _currentpartner = partner;
                
            }
            else
            {
                Title = "Добавление партнера";
                _currentpartner = new Partner();
            }


            PartnerType.ItemsSource = db.PartnersTypes.ToList();
            DataContext = _currentpartner;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PartnerName.Text == null
                || PartnerType.SelectedIndex == -1
                || PartnerRate.Text == null
                || PartnerAddress.Text == null
                || DirectorSurname.Text == null
                || DirectorName.Text == null
                || DirectorLastName.Text == null
                || PartnerPhone.Text == null
                || PartnerEmail.Text == null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (_currentpartner.ID == 0)
            {
                db.Partners.Add(_currentpartner);
                OnPartnerAdded.Invoke(_currentpartner);
            }
            try
            {
                db.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                if (NavigationService.CanGoBack) NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PartnerRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = textBox.Text.Replace(" ", string.Empty);
            textBox.SelectionStart = textBox.Text.Length;
            if (!IsValidInput(textBox.Text, e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private void PartnerPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!IsValidInputNumber(textBox.Text, e.Text[0]))
            {
                e.Handled = true;
            }
        }

        private bool IsValidInput(string text, char input)
        {
            if (!char.IsDigit(input))
                return false;

            if (text.Length > 1)
                return false;

            return true;
        }

        private bool IsValidInputNumber(string text, char input)
        {
            if (!char.IsDigit(input))
                return false;

            if (text.Length > 12)
                return false;

            return true;
        }

    }
}
