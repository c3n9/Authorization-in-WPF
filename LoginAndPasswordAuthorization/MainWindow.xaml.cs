﻿using LoginAndPasswordAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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

namespace LoginAndPasswordAuthorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.RememberMe)
            {
                TBLogin.Text = Properties.Settings.Default.Login;
                PBPassword.Password = Properties.Settings.Default.Password;
                CheckBoxRememberMe.IsChecked = Properties.Settings.Default.RememberMe;
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            TBLogin.Text = string.Empty;
            PBPassword.Password = string.Empty;
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(u => u.Login == TBLogin.Text && u.Password == PBPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Invalid login or password");
                return;
            }
            MessageBox.Show("Complete");
            if (CheckBoxRememberMe.IsChecked.Value)
            {
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Login = TBLogin.Text;
                Properties.Settings.Default.Password = PBPassword.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Login = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.Save();

            }
        }
    }
}
