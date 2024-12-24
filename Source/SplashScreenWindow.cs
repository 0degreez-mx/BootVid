using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;

namespace BootVid
{
    public class SplashScreenWindow : Window
    {
        public SplashScreenWindow(string videoPath)
        {
            // Configurar la ventana
            Width = 1920;
            Height = 1080;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Background = System.Windows.Media.Brushes.Black;
            Topmost = true;

            // Crear y agregar el UserControl
            var splashControl = new SplashScreenControl(videoPath);
            splashControl.SplashScreenEnded += () => this.Close();

            Content = splashControl;
        }
    }
}
