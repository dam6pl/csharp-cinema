using MVVMFirma.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMFirma
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {   
        // to jest funkcja ktora uruchamia sie przy starcie aplikacji
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // laczymy MainWindow z MainWindowViewModel
            MainWindow window = new MainWindow();
            window.DataContext = new MainWindowViewModel();
            window.Show();
        }
    }
}
