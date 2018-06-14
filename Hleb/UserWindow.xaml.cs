
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


using System.Windows.Shapes;

using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private byte[] data;

        public UserWindow()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                //создание диалогового окна для выбора файла
                fileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
                string way = fileDialog.FileName;
                Image img = new Image();
                ImageSourceConverter imgs = new ImageSourceConverter();
                userPhoto.Source = null;
                userPhoto.SetValue(Image.SourceProperty, imgs.ConvertFromString(way));
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Something Went Wrong");
            }




           
           


            
        }
    }
}
