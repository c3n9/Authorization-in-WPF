using AlphabetAndNumbersCaptcha.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AlphabetAndNumbersCaptcha
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AuthorizationEntities DB = new AuthorizationEntities();
    }
}
