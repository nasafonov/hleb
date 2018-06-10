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
        List<Button> _btns = new List<Button>();

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
            if (check3.IsChecked == true)
                _ingredients.Add(check3.Content.ToString());
            if (check4.IsChecked == true)
                _ingredients.Add(check4.Content.ToString());
            if (check5.IsChecked == true)
                _ingredients.Add(check5.Content.ToString());
            
            foreach (var rec in _request.Filter(_ingredients).ModelOfRecipes)
            {


                Grid grid = new Grid();

                Rectangle rect = new Rectangle();
                rect.Stroke = new SolidColorBrush(Colors.Black);
                rect.Height = 200;
                grid.Children.Add(rect);
                
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
                bt.Content = $"{rec.IDOfRecepies}";
                bt.VerticalAlignment = VerticalAlignment.Center;
                bt.Height = 200;
                bt.Opacity = 0;
                _btns.Add(bt);

                bt.Click += Bt_Click;
                bt.Cursor = Cursors.Hand;

                Button Fav = new Button();
                Fav.VerticalAlignment = VerticalAlignment.Center;
                Fav.Name = $"Fav_{rec.IDOfRecepies}";
                Fav.Height = 40;
                Fav.Width = 150;
                Fav.Content = "Add to Recipe Book";
                Fav.Cursor = Cursors.Hand;
                Fav.Click += Fav_Click;

                grid.Children.Add(bt);
                grid.Children.Add(Fav);


                

                Scroll.Children.Add(grid);
                Rectangle space = new Rectangle();
                space.Opacity = 0;
                space.Height = 20;
                Scroll.Children.Add(space);
               
            }

            st.Visibility = Visibility.Visible;
            

            
            

            //Button but = new Button();
            //but.Height = 40;
            //but.VerticalAlignment = VerticalAlignment.Center;
            //Scroll.Children.Add(but);
            //but.Click +=    

        }

        private void Fav_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            string id = null;
            foreach (var button in _btns)
                if(button.IsMouseOver)
                {
                    id = button.Content.ToString();
                    continue;
                }

            RecipeWindow rw = new RecipeWindow(id);
            rw.Show();
            
            //throw new NotImplementedException();
            
        }
    }
}
