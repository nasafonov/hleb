﻿using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            //ReceiptWindow rr = new ReceiptWindow();
            //rr.Show();
            //Close();
            st.Visibility = Visibility.Collapsed;
            st.Visibility = Visibility.Visible;

        }
    }
}
