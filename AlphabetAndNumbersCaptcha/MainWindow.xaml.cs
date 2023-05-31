using NumberCaptcha.AppWindows;
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

namespace AlphabetAndNumbersCaptcha
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
                CheckBoxRememberMe.IsChecked = Properties.Settings.Default.RememberMe;
                TBLoginOrEmailOrPhone.Text = Properties.Settings.Default.Login;
                PBPassword.Password = Properties.Settings.Default.Password;
            }
        }

        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = App.DB.User.FirstOrDefault(u => (u.Login == TBLoginOrEmailOrPhone.Text || u.Email == TBLoginOrEmailOrPhone.Text || u.PhoneNumber == TBLoginOrEmailOrPhone.Text) && u.Password == PBPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Invalid login or password");
                return;
            }
            var result = new CaptchaWindow().ShowDialog();
            MessageBox.Show("Complete");
            if (CheckBoxRememberMe.IsChecked.Value)
            {
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Login = TBLoginOrEmailOrPhone.Text;
                Properties.Settings.Default.Password = PBPassword.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Login = String.Empty;
                Properties.Settings.Default.Password = String.Empty;
                Properties.Settings.Default.Save();
            }
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        {
            TBLoginOrEmailOrPhone.Text = string.Empty;
            PBPassword.Password = string.Empty;
        }
    }
}
