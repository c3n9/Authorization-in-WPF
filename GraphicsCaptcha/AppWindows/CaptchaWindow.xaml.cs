using GraphicsCaptcha.Service;
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

namespace GraphicsCaptcha.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        Random random = new Random();
        List<char> chars = new List<char>();
        string captchaText = string.Empty;
        public CaptchaWindow()
        {
            InitializeComponent();
            RefreshCaptcha();
        }
        private void BRefreshCaptcha_Click(object sender, RoutedEventArgs e)
        {
            RefreshCaptcha();
        }
        private void RefreshCaptcha()
        {
            var captcha = new CaptchaGenerator(5);
            captchaText = captcha.CaptchaText;
            var captchaImage = captcha.GenerateCaptcha();
            ICaptcha.Source = MyTools.BytesToImage(captchaImage);
        }
        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if (captchaText == TBisCaptcha.Text)
            {
                this.DialogResult = true;
            }
            else
            {
                TBisCaptcha.Text = String.Empty;
                RefreshCaptcha();
                return;
            }
        }
    }
}

