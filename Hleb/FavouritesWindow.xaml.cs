﻿using Hleb.Classes;
using Hleb.Classes.DTO;
using Hleb.Classes.Interfaces;
using Hleb.Classes.MainLogic;
using Hleb.Model;
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
    /// Логика взаимодействия для FavouritesWindow.xaml
    /// </summary>
    public partial class FavouritesWindow : Window
    {
        IRepository _repo = Factory.Instance.GetRepository();
        APIrequest _request = new API();
        ILogic _logic = new Json();
        List<ListOfRecepies> rc = new List<ListOfRecepies>();
        List<Button> _btns = new List<Button>();

        private Recipe Request(object RecipeId)
        {
            return _request.GetRecipe(RecipeId.ToString()).Recipe;
        }

        async private void Print()
        {
            var favourites = _repo.AuthorizedUser.Favourites;
            WindowF.Cursor = Cursors.Wait;
            foreach (var favourite in favourites)
            {
                var task = Task.Factory.StartNew(Request, favourite.RecipeId);
                
                var result = await task;
                
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
                    img.UriSource = new Uri(result.ImageURI, UriKind.RelativeOrAbsolute);
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
                txt.Text = result.Name;
                txt.FontSize = 25;
                txt.FontWeight = FontWeights.Bold;
                stack2.Children.Add(txt);

                TextBlock des = new TextBlock();
                des.Height = 60;
                des.VerticalAlignment = VerticalAlignment.Center;
                des.Text = favourite.Description;
                des.FontSize = 25;
                des.FontWeight = FontWeights.Bold;
                stack2.Children.Add(des);

                TextBlock rating = new TextBlock();
                rating.Height = 60;
                rating.VerticalAlignment = VerticalAlignment.Center;
                rating.Text = $"Rating - {Math.Round(result.Rating)}";
                stack2.Children.Add(rating);

                grid.Children.Add(stack);

                Button bt = new Button();
                bt.Content = $"{result.Id}";
                bt.VerticalAlignment = VerticalAlignment.Center;
                bt.Height = 200;
                bt.Opacity = 0;
                _btns.Add(bt);

                bt.Click += Bt_Click;
                bt.Cursor = Cursors.Hand;

                grid.Children.Add(bt);

                Stack.Children.Add(grid);
            }
        }

        public FavouritesWindow()
        {
            InitializeComponent();
            Print();
            WindowF.Cursor = Cursors.Arrow;

        }

        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            string id = null;
            foreach (var button in _btns)
                if (button.IsMouseOver)
                {
                    id = button.Content.ToString();
                    continue;
                }

            RecipeWindow rw = new RecipeWindow(id, false);
            rw.EditRemove += EditRemoveFinished;
            rw.Show();
        }
        private void EditRemoveFinished()
        {
            Stack.Children.Clear();
            Print();
        }

        private void ButtonCatalog3_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            UserWindow us = new UserWindow();
            us.Show();
            Close();
        }
    }
}
