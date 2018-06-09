using Hleb.Classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


           // dataGridRecipe.ItemsSource = _request.Filter(_ingredients).ModelOfRecipes;


            foreach (var rec in _request.Filter(_ingredients).ModelOfRecipes)
            {


                Grid grid = new Grid();
                
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                stack.Height = 190;

                StackPanel stack2 = new StackPanel();

                stack2.Height = 170;

                using (var client = new HttpClient())
                {
                    Image im = new Image();
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(rec.ImageURI, UriKind.RelativeOrAbsolute);
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.EndInit();
                    im.Source = img;
                    im.VerticalAlignment = VerticalAlignment.Center;
                    im.Height = 150;
                    im.Width = 150;

                    stack.Children.Add(im);
                }
                stack.Children.Add(stack2);
                TextBlock txt = new TextBlock();
                txt.Height = 60;
                
                txt.VerticalAlignment = VerticalAlignment.Center;
                txt.Text = rec.Name;
                txt.FontSize = 25;
                txt.FontWeight = FontWeights.Bold;
                stack2.Children.Add(txt);

                TextBlock rating = new TextBlock();
                rating.Height = 60;
                rating.VerticalAlignment = VerticalAlignment.Center;
                rating.Text = $"Rating - {rec.Rating}";
                stack2.Children.Add(rating);

                
           

                grid.Children.Add(stack);

                Button bt = new Button();
                bt.Name = $"Button_{rec.IDOfRecepies}";
                bt.VerticalAlignment = VerticalAlignment.Center;
                bt.Height = 150;
                bt.Opacity = 0;

                bt.Cursor = Cursors.Hand;

                Button Fav = new Button();
                Fav.VerticalAlignment = VerticalAlignment.Center;
                Fav.Name = $"Fav_{rec.IDOfRecepies}";
                Fav.Height = 40;
                Fav.Width = 150;
                Fav.Content = "Add to Recipe Book";
                Fav.Cursor = Cursors.Hand;

                grid.Children.Add(bt);
                grid.Children.Add(Fav);


                

                Scroll.Children.Add(grid);
               
            }

            st.Visibility = Visibility.Visible;

            //Button but = new Button();
            //but.Height = 40;
            //but.VerticalAlignment = VerticalAlignment.Center;
            //Scroll.Children.Add(but);
            //but.Click +=    

        }

        
    }
}
