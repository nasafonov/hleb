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
    /// Логика взаимодействия для FoodFinderWindow.xaml
    /// </summary>
    public partial class FoodFinderWindow : Window
    {
        APIrequest _request = new API();
        List<string> _ingredients = new List<string>();

        public FoodFinderWindow()
        {         
            InitializeComponent();
        }
        private void ButtonBread2_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            UserWindow us = new UserWindow();
            us.Show();
            Close();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked == true)
                _ingredients.Add(check1.Content.ToString());

            if (check2.IsChecked == true)
                _ingredients.Add(check2.Content.ToString());


            dataGridRecipe.ItemsSource = _request.Filter(_ingredients).ModelOfRecipes;


            st.Visibility = Visibility.Visible;


        }

        
    }
}
