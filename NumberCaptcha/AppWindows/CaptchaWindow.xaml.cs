using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace NumberCaptcha.AppWindows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        Random random = new Random();
        string captcha = string.Empty;
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
            captcha = string.Empty;
            NumbersCaptcha.Children.Clear();
            for (int i = 0; i < 10; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = random.Next(0, 10).ToString();
                captcha += textBlock.Text;   
                textBlock.FontSize = random.Next(10, 50);
                Color color = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                textBlock.Foreground = new SolidColorBrush(color);
                NumbersCaptcha.Children.Add(textBlock);
            }
        }
        private void BLogin_Click(object sender, RoutedEventArgs e)
        {
            if(captcha == TBisCaptcha.Text)
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
