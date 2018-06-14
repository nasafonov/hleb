using Hleb.Classes;
using Hleb.Classes.Interfaces;
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
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        public UserWindow()
        {
            InitializeComponent();
            TextboxName.Text = _repo.AuthorizedUser.Name;
            TextboxSurname.Text = _repo.AuthorizedUser.LastName;
        }

        private void ButtonHome2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mm = new MainWindow();
            mm.Show();
            Close();
        }

        private void ButtonCatalog_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            FoodFinderWindow ff = new FoodFinderWindow();
            ff.Show();
            Close();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            InformationWindow mw = new InformationWindow();
            mw.Show();
            Close();
        }

        private void Favourite_Click(object sender, RoutedEventArgs e)
        {
            var fw = new FavouritesWindow();
            fw.Show();
            Close();
        }

    }
}
