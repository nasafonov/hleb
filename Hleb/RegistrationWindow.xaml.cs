using Hleb.Classes.DTO;
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
using System.Windows.Shapes;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        VKAPI _vkClient = new VKAPI();
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void Authorize()
        {
            var browserWindow = new BrowserWindow();

            browserWindow.OnRedirected += _vkClient.AuthorizationRedirect;
            browserWindow.Show();

            browserWindow.NavigateTo(_vkClient.GetAuthUrl(), _vkClient.RedirectPage);
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you're sucsessfully loged in");
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void ButtonVK_Click(object sender, RoutedEventArgs e)
        {
            Authorize();
        }
    }
}
