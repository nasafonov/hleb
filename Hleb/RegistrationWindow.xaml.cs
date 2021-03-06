﻿using Hleb.Classes;
using Hleb.Classes.DTO;
using Hleb.Classes.Interfaces;
using Hleb.Model;
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
        IRepository _repo = Factory.Instance.GetRepository();
        VKAPI _vkClient = new VKAPI();
        CurrentUser current = new CurrentUser();
      
        public event Action RegistrationFinished;

        public RegistrationWindow()
        {
            InitializeComponent();
            
            _vkClient.CheckAuthorization();
        }
        private void Authorize()
        {

            var browserWindow = new BrowserWindow();
            browserWindow.VkUser += VkReg;
            browserWindow.Show();

            browserWindow.NavigateTo(_vkClient.GetAuthUrl(), _vkClient.RedirectPage);
           
        }

        public void VkReg(User user)
        {
            textBoxname.Text = user.Name;
            textBoxname2.Text = user.LastName;
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
        

        private void ButtonVK_Click(object sender, RoutedEventArgs e)
        {
        
            Authorize();
            
        }



        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if(_repo.RegisterUser(textBoxname.Text, textBoxname2.Text, textBoxemail.Text, textBoxpassword.ToString()))
            {
                MessageBox.Show("you're sucsessfully loged in");
                RegistrationFinished?.Invoke();
                Close();
            }  
            else
                MessageBox.Show("User with this email alriedy exist");
        }
    }
}
