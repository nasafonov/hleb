﻿using Hleb.Classes.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hleb
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var check = new JsRepository();
            InitializeComponent();           
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RegistrationWindow mw = new RegistrationWindow();
            mw.Show();
            Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            UserWindow mw = new UserWindow();
            mw.Show();
            Close();
        }
    }
}
