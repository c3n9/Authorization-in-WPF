using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Drawing;
using System.Drawing.Imaging;

namespace GraphicsCaptcha.Service
{
    public class CaptchaGenerator
    {
        private const int Width = 800;
        private const int Height = 600;
        private const int FontSize = 44;

        private Random random = new Random();
        private string captchaText;

        public CaptchaGenerator(int length)
        {
            captchaText = GenerateRandomString(length);
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijkmnopqrstuvwxyz0123456789";
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }

        public byte[] GenerateCaptcha()
        {
            using (Bitmap bitmap = new Bitmap(Width, Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(System.Drawing.Color.White);

                    // Draw lines
                    for (int i = 0; i < 15; i++)
                    {
                        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)), 5);
                        System.Drawing.Point startPoint = new System.Drawing.Point(random.Next(Width), random.Next(Height));
                        System.Drawing.Point endPoint = new System.Drawing.Point(random.Next(Width), random.Next(Height));
                        graphics.DrawLine(pen, startPoint, endPoint);
                    }

                    // Add text
                    using (Font font = new Font("Arial", FontSize))
                    {
                        for (int i = 1; i <= captchaText.Length; i++)
                        {
                            System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                            System.Drawing.Point location = new System.Drawing.Point((int)(i * (FontSize * 2.8)), random.Next(200, 250));
                            graphics.DrawString(captchaText[i - 1].ToString(), font, brush, location);
                        }
                    }

                    // Add circles
                    for (int i = 0; i < 5; i++)
                    {
                        System.Drawing.Brush brush = new SolidBrush(System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                        graphics.FillEllipse(brush, random.Next(Width - 50), random.Next(Height - 50), 30, 30);
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
        }

        public string CaptchaText
        {
            get { return captchaText; }
        }
    }
}